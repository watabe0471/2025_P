using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //Rigitbody��������ϐ�
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //2)Rigidbody���擾���đ��
        rb = GetComponent<Rigidbody>();

        //3)�E�������ɗ͂�������(x.y��)
        //�͂���������������߂�
        Vector3 myDirection = new Vector3(5, 5, 0);
        
        rb.AddForce(myDirection,ForceMode.Impulse);//�C���p���X���[�h�ŏu�ԓI�ɗ͂�������
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
