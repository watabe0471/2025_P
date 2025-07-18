using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    private bool use = false;
    [SerializeField] float fallSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (use)
            return;

        if(transform.position.y <= 0.0f)
        {
            createBG.CopyBG();
            use = true;
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
