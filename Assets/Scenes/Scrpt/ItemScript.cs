using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] float fallSpeed = 5f;

    public GameObject ballPrefab;         // ��������{�[��Prefab
    public Transform ballSpawnPoint;      // �{�[�������ʒu

    // private Transform ballnowPosition = null;   // �{�[���̍��̈ʒu
    private Rigidbody rb;

    [SerializeField]private Vector3 BallShootPoint = new Vector3(16.5f,5.0f,0.0f);

    private GameObject newBall = null;
    private GameObject newBall2 = null;
    private bool on = false;

    private Rigidbody ballrb1;
    private Rigidbody ballrb2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (ballSpawnPoint != null) return;

         ballSpawnPoint = BarScript.BarPos;

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
                Debug.Log("���̐����G���[");
                return;
            }
                switch (ItemNum)
            {
                case 0:

                    // �o�[�̈ʒu����Y��1.0f�グ���ꏊ�Ƀ{�[������
                    Vector3 spawnPos1 = other.transform.position;
                    spawnPos1.y += 1.0f;

                    newBall = Instantiate(ballPrefab, spawnPos1, Quaternion.identity);
                    newBall.tag = "Ball";
                    on = true;
                    // �A�C�e��������
                    Destroy(gameObject);
                    return;
                case 1:
                //    if (BallShootPoint == null) return;


                //        BallScript.rb = GetComponent<Rigidbody>();
                    BallShootPoint = new Vector3(16.4f, 5.0f, 0.0f);
                    newBall = Instantiate(ballPrefab, BallShootPoint, Quaternion.identity);
                    newBall.tag = "Ball";
                    ballrb1 = newBall.GetComponent<Rigidbody>();
                    Vector3 randomDirection = new Vector3(Random.Range(1f, 3f), 1f, 0f).normalized;
                    ballrb1.AddForce(randomDirection * BallScript.speed, ForceMode.Impulse);

                    Debug.Log("������");
                    BallShootPoint = new Vector3(-16.4f, 5.0f, 0.0f);
                    newBall2 = Instantiate(ballPrefab, BallShootPoint, Quaternion.identity);
                    newBall2.tag = "Ball";
                    ballrb2 = newBall2.GetComponent<Rigidbody>();

                    randomDirection.x *= -1;    
                    ballrb2.AddForce(randomDirection * BallScript.speed, ForceMode.Impulse);

                    Debug.Log("������");

                    //on = true;

                    // �A�C�e��������
                    Destroy(gameObject);
                    return;
                case 2:
                    break;

                    //Vector3 spawnPos2 = BarScript.newBall.transform.position;

                    //var Direction = BallScript.velo;
                    //var nomal = new Vector3(0.0f, 1.0f, 0.0f);
                    //var result = Vector3.Reflect(Direction, nomal);
                    //Instantiate(ballPrefab, spawnPos2, Quaternion.identity);
                    //rb.AddForce(result * BallScript.speed, ForceMode.Impulse);

                    // //�A�C�e��������
                    //Destroy(gameObject);
                    //return;
            }
        }
    }

    private void OnDestroy()
    {
        if (on != true) return; // 

        BallScript.LaunchBall();
        on = false;
    }

}