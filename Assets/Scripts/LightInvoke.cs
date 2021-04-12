using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInvoke : MonoBehaviour
{
    public float lightIntensity = 1;
    public float multiplier = 10;
    Light lantern;
    public float time = 119;
    // Start is called before the first frame update
    void Start()
    {
        lantern = GetComponent<Light>();
        Invoke("LightIntensityIncrease", time);
    }

    // Update is called once per frame
    void Update()
    {


    }
    void LightIntensityIncrease()
    {
        lantern.intensity = lightIntensity * multiplier;
    }
}
