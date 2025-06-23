using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 2000f;

    private Rigidbody rb;

    public AudioClip audioClip; // 効果音
    private AudioSource audioSource; // AudioSource

    private bool GameState = false; // ゲームスタートフラグ


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Audio Source コンポーネントを取得

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
    void OnCollisionEnter(Collision collision)
    {
        // 普通のものに当たったら鳴らない
        if (collision.gameObject.tag == default)
            return;

        audioSource.PlayOneShot(audioClip); // 効果音を鳴らす
    }
}
