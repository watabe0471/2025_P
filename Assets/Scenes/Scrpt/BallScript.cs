using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // �{�[���̈ړ����x
    [SerializeField] public static float speed = 10f;

    public static Rigidbody rb;
    public static Vector3 velo;

    [SerializeField] private AudioClip audioClip = null; // ���ʉ�
    private AudioSource audioSource; // AudioSource

    public static bool GameState = false; // �Q�[���X�^�[�g�t���O


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Audio Source �R���|�[�l���g���擾

    }

    // ���t���[�����x���`�F�b�N����
    void Update()
    {
        // rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            if (rb.velocity != Vector3.zero)
            {
                rb.velocity = rb.velocity.normalized * speed;
                velo = rb.velocity;
            }
        }
    }

    public static void LaunchBall()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(0f, 3f),
            1f,
            0f
        ).normalized;
        Debug.Log(rb);
        
        rb.AddForce(randomDirection * speed, ForceMode.Impulse);
    }
    // �J�����O�ɏo����쓮����֐�
    void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }
    void OnCollisionEnter(Collision collision)
    {
        if (audioClip != null)
        {
            // �u���b�N�n�I�u�W�F�N�g�ɓ�����������ʉ���炷
            if (collision.gameObject.tag == "BlockTypeA" || collision.gameObject.tag == "BlockTypeB")
            {
                audioSource.PlayOneShot(audioClip);
            }
        }

        // ���˃x�N�g�����擾�i�ՓˑO�̑��x�j
        if (rb == null) return;
        Vector3 incident = rb.velocity.normalized;

        // �ڐG�_�̖@���x�N�g�����擾
        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;

        // ���˃x�N�g�����v�Z
        Vector3 reflected = Vector3.Reflect(incident, normal);

        // ���O�o�́i�p�x���v�Z���Ă݂�j
        float angleOfIncidence = Vector3.Angle(-normal, incident);   // ���ˊp
        float angleOfReflection = Vector3.Angle(normal, reflected);  // ���ˊp

    //    Debug.Log($"���˃x�N�g��: {incident}, �@��: {normal}, ���˃x�N�g��: {reflected}");
    //    Debug.Log($"���ˊp: {angleOfIncidence:F2}��, ���ˊp: {angleOfReflection:F2}��");

        // �����K�v�Ȃ�A���˕����ɑ��x�������I�ɕύX
        //rb.velocity = reflected * rb.velocity.magnitude;
    }
}
