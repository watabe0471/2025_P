using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    public float moveSpeed = 20.0f; // �ړ����x
    public float speed = 10.0f; // ���̈ړ����x
    private bool StartGame = true;
    GameObject newBall = null;

    [Header("���̃I�u�W�F�N�g")]
    [SerializeField] private GameObject ballPrefab;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // LaunchBall(ballPrefab);   // ��������ݒu

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime; // ���������̈ړ�
        float moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;   // ���������̈ړ�

        transform.position += new Vector3(moveX, moveY, 0); // �I�u�W�F�N�g�̈ʒu���X�V

        if (Input.GetKeyDown(KeyCode.B))
        {
            LaunchBall(ballPrefab);
        }

        Vector3 ballShootPos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        if (StartGame == true)
        {
            newBall = Instantiate(ballPrefab, ballShootPos, Quaternion.identity);
            newBall.tag = "Ball";   // �N���[���Ƀ^�OBall��ǉ�
            // newBall.transform.parent = transform;

            StartGame = false;
        }
        
         newBall.transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);

        }
    public void LaunchBall(GameObject newBall)
    {
        
        // ���𐶐�
        Vector3 ballShootPos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        newBall = Instantiate(ballPrefab,ballShootPos, Quaternion.identity);
        newBall.tag = "Ball";   // �N���[���Ƀ^�OBall��ǉ�
    
        Vector3 randomDirection = new Vector3(
    Random.Range(0f, 3f),
    1f,
    0f
).normalized;
        

    }


}

