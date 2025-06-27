using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject Ball;
    BallScript ballscript;

    public float fallSpeed = 5f;

    public GameObject ballPrefab;         // ��������{�[��Prefab
    public Transform ballSpawnPoint;      // �{�[�������ʒu

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
        // ��葬�x��Y���������Ɉړ�
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // ��荂���ȉ��ŏ����i�n�ʂȂǁj
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �o�[�ɓ�����������i�^�O"Bar"�j
        if (other.CompareTag("bar"))
        {
            // �o�[�̈ʒu����Y��1.0f�グ���ꏊ�Ƀ{�[������
            Vector3 spawnPos = other.transform.position;
            spawnPos.y += 1.0f;

            if (ballPrefab != null)
            {
                Instantiate(ballPrefab, spawnPos, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("ballPrefab���ݒ肳��Ă��܂���I");
            }

            // �A�C�e��������
            Destroy(gameObject);
        }
    }
}
