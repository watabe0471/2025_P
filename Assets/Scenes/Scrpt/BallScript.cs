using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 2000f;

    private Rigidbody rb;
    private bool GameState = false; // �Q�[���X�^�[�g�t���O


    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // ���t���[�����x���`�F�b�N����
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameState == false)
        {
            LaunchBall();
            GameState = true; // �Q�[�����X�^�[�g����

        }
    }

    void LaunchBall()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(0f, 3f),
            1f,
            0f
        ).normalized;

        rb.AddForce(randomDirection * speed, ForceMode.Impulse);
    }
    // �J�����O�ɏo����쓮����֐�
    void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }
}
