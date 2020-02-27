using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    [SerializeField] private GameObject dirLight;
    [SerializeField] private float valuee;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.ambientIntensity = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
