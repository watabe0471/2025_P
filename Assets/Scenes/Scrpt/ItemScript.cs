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
    private Transform ballnowPosition = null;   // �{�[���̍��̈ʒu
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
            int ItemNum = ItemSpawn.spawnNum;   // �A�C�e���ԍ����擾
            if (ballPrefab == null)
            {
                return;
            }
                switch (ItemNum)
            {
                case 0:

                    // �o�[�̈ʒu����Y��1.0f�グ���ꏊ�Ƀ{�[������
                    Vector3 spawnPos1 = other.transform.position;
                    spawnPos1.y += 1.0f;


                    newBall = Instantiate(ballPrefab, spawnPos1, Quaternion.identity);

                    // �A�C�e��������
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

                    // �A�C�e��������
                    Destroy(gameObject);
                    return;
            }
        }
    }
}