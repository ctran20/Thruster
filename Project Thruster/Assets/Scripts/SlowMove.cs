using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMove : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float speedZ;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (speedX * Time.deltaTime),
                                         transform.position.y + (speedY * Time.deltaTime),
                                         transform.position.z + (speedZ * Time.deltaTime));
    }
}
