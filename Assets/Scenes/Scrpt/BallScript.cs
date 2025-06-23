using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 2000f;

    private Rigidbody rb;

    public AudioClip audioClip; // ���ʉ�
    private AudioSource audioSource; // AudioSource

    private bool GameState = false; // �Q�[���X�^�[�g�t���O


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Audio Source �R���|�[�l���g���擾

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
    void OnCollisionEnter(Collision collision)
    {
        // ���ʂ̂��̂ɓ����������Ȃ�
        if (collision.gameObject.tag == default)
            return;

        audioSource.PlayOneShot(audioClip); // ���ʉ���炷
    }
}
