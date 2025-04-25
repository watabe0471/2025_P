using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrockScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //“–‚½‚Á‚½Žž
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
