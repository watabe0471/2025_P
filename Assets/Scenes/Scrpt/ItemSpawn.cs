using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    [Header("�A�C�e��")]
    public GameObject ItemPrefab;

    [Header("�X�|�[���Ԋu�i�b�j")]
    public float spawnInterval = 5f;

    [Header("�X�|�[���G���A�iX�j")]
    public Vector2 spawnRangeX = new Vector2(-16.0f, 16.0f);

    [Header("�X�|�[���̍���")]
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
