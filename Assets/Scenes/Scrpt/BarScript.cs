using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    public float moveSpeed = 20.0f; // 移動速度
    public float speed = 10.0f; // 球の移動速度


    [Header("球のオブジェクト")]
    [SerializeField] private GameObject ballPrefab;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime; // 水平方向の移動
        float moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;   // 垂直方向の移動

        transform.position += new Vector3(moveX, moveY, 0); // オブジェクトの位置を更新

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }


        }
    void LaunchBall()
    {
        Vector3 ballShootPos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        GameObject newBall = Instantiate(ballPrefab,ballShootPos, Quaternion.identity);
        newBall.tag = "Ball";
        
        Vector3 randomDirection = new Vector3(
    Random.Range(0f, 3f),
    1f,
    0f
).normalized;
        

    }


}

