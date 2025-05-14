using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    // �ړ����̉��Z�p�ϐ�
    float vx = 0;
    float vy = 0;

    // �ړ��X�s�[�h
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1���E�̓��͂��擾
        //float myX = Input.GetAxis("Horizontal");
        //�ʒu���̕ύX
        //transform.position += new Vector3(myX * 10, 0, 0) * Time.deltaTime;

        // ���t���[�����l��������
        vx = 0;
        vy = 0;

        // ���ړ�
        if (Input.GetKey(KeyCode.A))
        {
            vx = -speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            vx = speed;
        }

        // �c�ړ�
        if (Input.GetKey(KeyCode.W))
        {
            vy = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vy = -speed;
        }

        // ���ۂ̈ړ�����
        this.transform.Translate(vx / 50, vy / 50, 0);
    }
}
