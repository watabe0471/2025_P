using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    [Header("アイテム")]
    public GameObject ItemPrefab;

    [Header("スポーン間隔（秒）")]
    public float spawnInterval = 5f;

    [Header("スポーンエリア（X）")]
    public Vector2 spawnRangeX = new Vector2(-16.0f, 16.0f);

    [Header("スポーンの高さ")]
    public float spawnHeight = 10f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer = 0f;
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

        Instantiate(ItemPrefab, spawnPos, Quaternion.identity);
    }
}
