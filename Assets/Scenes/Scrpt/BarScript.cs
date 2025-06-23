using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    public float moveSpeed = 20.0f; // 移動速度
    public float speed = 10.0f; // 球の移動速度

    private bool shoot = false;
    GameObject newBall = null;

    [Header("画面上限")]
    [SerializeField] private float XLimit = 10.0f;
    [SerializeField] private float YLimit = 10.0f;

    [Header("球のオブジェクト")]
    [SerializeField] private GameObject ballPrefab;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 ballShootPos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        newBall = Instantiate(ballPrefab, ballShootPos, Quaternion.identity);
        newBall.tag = "Ball";   // クローンにタグBallを追加

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime; // 水平方向の移動量
        float moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;   // 垂直方向の移動
        Debug.Log(moveX);
        // Vector3 movement =  new Vector3(Mathf.Clamp(moveX,-XLimit,XLimit),Mathf.Clamp(moveY,-YLimit,YLimit), 0); // オブジェクトの位置を更新
        transform.position += new Vector3(moveX, moveY, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -XLimit, XLimit), Mathf.Clamp(transform.position.y, -YLimit, YLimit-1.0f), 0);

        if (Input.GetKeyDown(KeyCode.Space))
            shoot = true;
        if (shoot == false)
        {
            newBall.transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);
        }

    }
//    public void LaunchBall(GameObject newBall)
//    {
        
//        // 球を生成
//        Vector3 ballShootPos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
//        newBall = Instantiate(ballPrefab,ballShootPos, Quaternion.identity);
//        newBall.tag = "Ball";   // クローンにタグBallを追加
    
//        Vector3 randomDirection = new Vector3(
//    Random.Range(0f, 3f),
//    1f,
//    0f
//).normalized;
//    }


}

