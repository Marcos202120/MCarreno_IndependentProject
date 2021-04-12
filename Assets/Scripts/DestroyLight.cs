using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLight : MonoBehaviour
{
    public float time = 119;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyLight", time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void destroyLight()
    {
        Destroy(gameObject);
    }
}
