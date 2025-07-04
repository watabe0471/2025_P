using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    [Header("アイテム")]
    public GameObject ItemPrefab1;
    public GameObject ItemPrefab2;


    [Header("スポーン間隔（秒）")]
    public float spawnInterval = 5f;

    [Header("スポーンエリア（X）")]
    public Vector2 spawnRangeX = new Vector2(-16.0f, 16.0f);

    [Header("スポーンの高さ")]
    public float spawnHeight = 10f;

    private float timer = 0f;
    public static int spawnNum = 0;

    void Update()
    {
        // 始まっていなければ動かない
        if(BarScript.shoot != true)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer = 0f;
            spawnInterval = Random.Range(3f, 8f);
        }

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void SpawnItem()
    {
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, 0.0f);
        // spawnNum = Random.Range(0, 3);
        switch (spawnNum)
        {
            case 0:
                Instantiate(ItemPrefab1, spawnPos, Quaternion.identity);
                return;
            case 1:
                Instantiate(ItemPrefab2, spawnPos, Quaternion.identity);
                return;
            default:
                return;
        }
    }
}
