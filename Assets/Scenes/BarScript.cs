using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1¶‰E‚Ì“ü—Í‚ğæ“¾
        float myX = Input.GetAxis("Horizontal");
        //ˆÊ’uî•ñ‚Ì•ÏX
        transform.position += new Vector3(myX * 10, 0, 0) * Time.deltaTime;
    }
}
