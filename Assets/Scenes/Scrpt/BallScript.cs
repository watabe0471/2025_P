using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 2000f;

    private Rigidbody rb;
    private bool GameState = false; // ゲームスタートフラグ


    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // 毎フレーム速度をチェックする
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameState == false)
        {
            LaunchBall();
            GameState = true; // ゲームがスタートした

        }
    }

    void LaunchBall()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(0f, 3f),
            1f,
            0f
        ).normalized;

        rb.AddForce(randomDirection * speed, ForceMode.Impulse);
    }
    // カメラ外に出たら作動する関数
    void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }
}
