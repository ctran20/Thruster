using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player = new GameObject();
    [SerializeField] GameObject fx;
    int MoveSpeed = 18;
    int MaxDist = 0;
    int MinDist = 0;

    void Update()
    {
        transform.LookAt(player.transform);

        if (Vector3.Distance(transform.position, player.transform.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, player.transform.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(fx, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        AudioManager.PlaySound("explosion", 0.1f);
        Destroy(gameObject,0.2f);
    }
}
