using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalControl : MonoBehaviour
{
    [SerializeField] private GameObject dirLight;
    [SerializeField] private GameObject redBlock;
    [SerializeField] private GameObject rLauncher;
    [SerializeField] private GameObject backdrop;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject onLast;
    [SerializeField] private GameObject offLast;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "LandPad1":
                dirLight.SetActive(false);
                redBlock.GetComponent<Oscillator>().enabled = true;
                break;
            case "LandPad2":
                RenderSettings.ambientIntensity = 0f;
                rLauncher.GetComponent<SpawnObjects>().enabled = true;
                break;
            case "LandPad3":
                backdrop.GetComponent<SlowMove>().enabled = true;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                break;
            case "LandPad4":
                cam.gameObject.transform.position = new Vector3(transform.position.x,
                                                                transform.position.y,
                                                                -5);
                cam.GetComponent<CameraFollow>().enabled = true;
                onLast.SetActive(true);
                offLast.SetActive(false);
                break;
            default:
                break;
        }
    }


}
