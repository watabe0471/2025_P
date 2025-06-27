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

    private Rigidbody rb;

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
            // バーの位置からYを1.0f上げた場所にボール生成
            Vector3 spawnPos = other.transform.position;
            spawnPos.y += 1.0f;

            if (ballPrefab != null)
            {
                Instantiate(ballPrefab, spawnPos, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("ballPrefabが設定されていません！");
            }

            // アイテムを消す
            Destroy(gameObject);
        }
    }
}
