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

    //当たった時
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
