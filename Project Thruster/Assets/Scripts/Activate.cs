using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private string colliderTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(colliderTag))
        {
            AudioManager.PlaySound("win", 0.4f);
            target.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
