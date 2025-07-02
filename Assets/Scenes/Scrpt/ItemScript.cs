using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject Ball;
    BallScript ballscript;

    public float fallSpeed = 5f;

    public GameObject ballPrefab;         // 生成するボールPrefab
    public Transform ballSpawnPoint;      // ボール生成位置
    private Transform ballnowPosition = null;   // ボールの今の位置
    private Rigidbody rb;

    private GameObject newBall = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (ballSpawnPoint == null)
        {
            GameObject barObj = GameObject.FindGameObjectWithTag("bar");
            if (barObj != null)
            {
                ballSpawnPoint = barObj.transform;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // 一定速度でY軸下方向に移動
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // 一定高さ以下で消す（地面など）
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // バーに当たった判定（タグ"Bar"）
        if (other.CompareTag("bar"))
        {
            int ItemNum = ItemSpawn.spawnNum;   // アイテム番号を取得
            if (ballPrefab == null)
            {
                return;
            }
                switch (ItemNum)
            {
                case 0:

                    // バーの位置からYを1.0f上げた場所にボール生成
                    Vector3 spawnPos1 = other.transform.position;
                    spawnPos1.y += 1.0f;


                    newBall = Instantiate(ballPrefab, spawnPos1, Quaternion.identity);

                    // アイテムを消す
                    Destroy(gameObject);
                    return;
                case 1:
                    return;
                    Vector3 spawnPos2 = BarScript.newBall.transform.position;

                    var Direction = BallScript.velo;
                    var nomal = new Vector3(0.0f, 1.0f, 0.0f);
                    var result = Vector3.Reflect(Direction, nomal);
                    Instantiate(ballPrefab, spawnPos2, Quaternion.identity);
                    rb.AddForce(result * BallScript.speed, ForceMode.Impulse);

                    // アイテムを消す
                    Destroy(gameObject);
                    return;
            }
        }
    }
}