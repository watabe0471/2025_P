using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20.0f;   // バーの移動速度
    public static bool shoot = false;           // 球が射出されているか

    public static GameObject newBall = null;    // 

    GameObject[] balls;
    [Header("画面上限")]
    [SerializeField] private float XLimit = 15.5f;
    [SerializeField] private float YLimit = 9.0f;

    [Header("球のオブジェクト")]
    [SerializeField] private GameObject ballPrefab;

    public static Transform BarPos;

    void Start()
    {

        // ボールを生成
        Vector3 ballShootPos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        newBall = Instantiate(ballPrefab, ballShootPos, Quaternion.identity);
        newBall.tag = "Ball";   // クローンにタグBallを追加
        shoot = false;

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime; // 水平方向の移動量
        float moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;   // 垂直方向の移動
        transform.position += new Vector3(moveX, moveY, 0);
        // 画面から飛び出ない様に
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -XLimit, XLimit), Mathf.Clamp(transform.position.y, -YLimit, YLimit-1.0f), 0);
        // Mathf.Clamp(制限したい値、最小値、最大値)
        BarPos = transform;

        // 打っていなければ追従
        if (shoot != false) return;

        if (Input.GetKeyDown(KeyCode.Space))    // スペースで打つ
        {
            shoot = true;
            LaunchBall();
        }
        newBall.transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);
    }
    private void LaunchBall()
    {
        Vector3 randomDirection = new Vector3(Random.Range(1f, 3f), 1f, 0f).normalized; // 射出方向を決定
        BallScript.rb.AddForce(randomDirection * BallScript.speed, ForceMode.Impulse);  // 射出
    }
}

