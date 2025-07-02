using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public static float speed = 10f;

    private static Rigidbody rb;
    public static Vector3 velo;

    [SerializeField] private AudioClip audioClip = null; // 効果音
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
        rb = GetComponent<Rigidbody>();
        velo = rb.velocity;
        Debug.Log(velo);
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

//        rb = GetComponent<Rigidbody>();
        //if (rb != null)
        //{

        //    var Directionz     = rb.velocity;
        //    var nomal = new Vector3(0.0f, 1.0f, 0.0f);
        //        //collision.gameObject.transform.up;
        //    var result = Vector3.Reflect(Direction, nomal);
        //    Debug.Log("result" + result + "Direction" + Direction);


            
        //    if (collision.gameObject.tag == "bar")
        //    {

        //            rb.AddForce(result, ForceMode.Impulse);
        //    }
        //}
        //else
        //{
        //    Debug.Log("nullになってる");
        //}
        // 音を鳴らす
        if(audioClip != null)
        {
            // ブロックAに当たったら
            if (collision.gameObject.tag == "BlockTypeA")
            {
                Debug.Log("ブロックに当たった");
                audioSource.PlayOneShot(audioClip); // 効果音を鳴らす
            }
            // ブロックBに当たったら
            if (collision.gameObject.tag == "BlockTypeB")
            {
                Debug.Log("ブロックに当たった");
                audioSource.PlayOneShot(audioClip); // 効果音を鳴らす
            }
        }
    }
}
