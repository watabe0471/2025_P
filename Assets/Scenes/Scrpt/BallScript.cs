using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 2000f;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // 毎フレーム速度をチェックする
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(-0.3f, 0.3f),
            1f,
            0f
        ).normalized;

        rb.AddForce(randomDirection * speed, ForceMode.Impulse);
    }
}
