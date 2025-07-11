using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // ボールの移動速度
    [SerializeField] public static float speed = 10f;

    public static Rigidbody rb;
    public static Vector3 velo;

    [SerializeField] private AudioClip audioClip = null; // 効果音
    private AudioSource audioSource; // AudioSource

    public static bool GameState = false; // ゲームスタートフラグ


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Audio Source コンポーネントを取得

    }

    // 毎フレーム速度をチェックする
    void Update()
    {
        // rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            if (rb.velocity != Vector3.zero)
            {
                rb.velocity = rb.velocity.normalized * speed;
                velo = rb.velocity;
            }
        }
    }

    public static void LaunchBall()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(0f, 3f),
            1f,
            0f
        ).normalized;
        Debug.Log(rb);
        
        rb.AddForce(randomDirection * speed, ForceMode.Impulse);
    }
    // カメラ外に出たら作動する関数
    void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }
    void OnCollisionEnter(Collision collision)
    {
        if (audioClip != null)
        {
            // ブロック系オブジェクトに当たったら効果音を鳴らす
            if (collision.gameObject.tag == "BlockTypeA" || collision.gameObject.tag == "BlockTypeB")
            {
                audioSource.PlayOneShot(audioClip);
            }
        }

        // 入射ベクトルを取得（衝突前の速度）
        if (rb == null) return;
        Vector3 incident = rb.velocity.normalized;

        // 接触点の法線ベクトルを取得
        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;

        // 反射ベクトルを計算
        Vector3 reflected = Vector3.Reflect(incident, normal);

        // ログ出力（角度も計算してみる）
        float angleOfIncidence = Vector3.Angle(-normal, incident);   // 入射角
        float angleOfReflection = Vector3.Angle(normal, reflected);  // 反射角

    //    Debug.Log($"入射ベクトル: {incident}, 法線: {normal}, 反射ベクトル: {reflected}");
    //    Debug.Log($"入射角: {angleOfIncidence:F2}°, 反射角: {angleOfReflection:F2}°");

        // もし必要なら、反射方向に速度を強制的に変更
        //rb.velocity = reflected * rb.velocity.magnitude;
    }
}
