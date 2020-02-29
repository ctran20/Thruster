using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControl : MonoBehaviour
{
    private void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * 150 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * 150 * Time.deltaTime);
        }
    }
}
