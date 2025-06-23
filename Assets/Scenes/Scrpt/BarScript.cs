using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    public float moveSpeed = 20.0f; // �ړ����x
    public float speed = 10.0f; // ���̈ړ����x

    private bool shoot = false;
    GameObject newBall = null;

    [Header("��ʏ��")]
    [SerializeField] private float XLimit = 10.0f;
    [SerializeField] private float YLimit = 10.0f;

    [Header("���̃I�u�W�F�N�g")]
    [SerializeField] private GameObject ballPrefab;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // �{�[���𐶐�
        Vector3 ballShootPos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        newBall = Instantiate(ballPrefab, ballShootPos, Quaternion.identity);
        newBall.tag = "Ball";   // �N���[���Ƀ^�OBall��ǉ�

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime; // ���������̈ړ���
        float moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;   // ���������̈ړ�
        transform.position += new Vector3(moveX, moveY, 0);
        // ��ʂ����яo�Ȃ��l��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -XLimit, XLimit), Mathf.Clamp(transform.position.y, -YLimit, YLimit-1.0f), 0);   
        // Mathf.Clamp(�����������l�A�ŏ��l�A�ő�l)

        // �X�y�[�X�őł�
        if (Input.GetKeyDown(KeyCode.Space))
            shoot = true;
        // �ł��Ă��Ȃ���ΒǏ]
        if (shoot == false)
        {
            newBall.transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);
        }

    }
//    public void LaunchBall(GameObject newBall)
//    {
        
//        // ���𐶐�
//        Vector3 ballShootPos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
//        newBall = Instantiate(ballPrefab,ballShootPos, Quaternion.identity);
//        newBall.tag = "Ball";   // �N���[���Ƀ^�OBall��ǉ�
    
//        Vector3 randomDirection = new Vector3(
//    Random.Range(0f, 3f),
//    1f,
//    0f
//).normalized;
//    }


}

