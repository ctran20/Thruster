using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject fx;
    int MoveSpeed = 18;
    int MaxDist = 0;
    int MinDist = 0;

    void Update()
    {
        if (player)
        {
            transform.LookAt(player.transform);

            if (Vector3.Distance(transform.position, player.transform.position) >= MinDist)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(fx, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        AudioManager.PlaySound("explosion", 0.2f);
        Destroy(gameObject,0.05f);
    }
}
