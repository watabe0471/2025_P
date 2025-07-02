using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public static float speed = 10f;

    private static Rigidbody rb;
    public static Vector3 velo;

    [SerializeField] private AudioClip audioClip = null; // ���ʉ�
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
        rb = GetComponent<Rigidbody>();
        velo = rb.velocity;
        Debug.Log(velo);
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

//        rb = GetComponent<Rigidbody>();
        //if (rb != null)
        //{

        //    var Directionz     = rb.velocity;
        //    var nomal = new Vector3(0.0f, 1.0f, 0.0f);
        //        //collision.gameObject.transform.up;
        //    var result = Vector3.Reflect(Direction, nomal);
        //    Debug.Log("result" + result + "Direction" + Direction);


            
        //    if (collision.gameObject.tag == "bar")
        //    {

        //            rb.AddForce(result, ForceMode.Impulse);
        //    }
        //}
        //else
        //{
        //    Debug.Log("null�ɂȂ��Ă�");
        //}
        // ����炷
        if(audioClip != null)
        {
            // �u���b�NA�ɓ���������
            if (collision.gameObject.tag == "BlockTypeA")
            {
                Debug.Log("�u���b�N�ɓ�������");
                audioSource.PlayOneShot(audioClip); // ���ʉ���炷
            }
            // �u���b�NB�ɓ���������
            if (collision.gameObject.tag == "BlockTypeB")
            {
                Debug.Log("�u���b�N�ɓ�������");
                audioSource.PlayOneShot(audioClip); // ���ʉ���炷
            }
        }
    }
}
