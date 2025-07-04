using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20.0f;   // �o�[�̈ړ����x
    public static bool shoot = false;           // �����ˏo����Ă��邩

    public static GameObject newBall = null;    // 

    GameObject[] balls;
    [Header("��ʏ��")]
    [SerializeField] private float XLimit = 15.5f;
    [SerializeField] private float YLimit = 9.0f;

    [Header("���̃I�u�W�F�N�g")]
    [SerializeField] private GameObject ballPrefab;

    public static Transform BarPos;

    void Start()
    {

        // �{�[���𐶐�
        Vector3 ballShootPos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        newBall = Instantiate(ballPrefab, ballShootPos, Quaternion.identity);
        newBall.tag = "Ball";   // �N���[���Ƀ^�OBall��ǉ�
        shoot = false;

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime; // ���������̈ړ���
        float moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;   // ���������̈ړ�
        transform.position += new Vector3(moveX, moveY, 0);
        // ��ʂ����яo�Ȃ��l��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -XLimit, XLimit), Mathf.Clamp(transform.position.y, -YLimit, YLimit-1.0f), 0);
        // Mathf.Clamp(�����������l�A�ŏ��l�A�ő�l)
        BarPos = transform;

        // �ł��Ă��Ȃ���ΒǏ]
        if (shoot != false) return;

        if (Input.GetKeyDown(KeyCode.Space))    // �X�y�[�X�őł�
        {
            shoot = true;
            LaunchBall();
        }
        newBall.transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);
    }
    private void LaunchBall()
    {
        Vector3 randomDirection = new Vector3(Random.Range(1f, 3f), 1f, 0f).normalized; // �ˏo����������
        BallScript.rb.AddForce(randomDirection * BallScript.speed, ForceMode.Impulse);  // �ˏo
    }
}

