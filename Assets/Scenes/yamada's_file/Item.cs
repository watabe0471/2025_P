using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [Header("���̃I�u�W�F�N�g")]
    [SerializeField] private GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        int ItemNum = Random.Range(0, 3);

        Debug.Log("�A�C�e�������܂���");
        Debug.Log("�A�C�e���ԍ�" + ItemNum);

        switch (ItemNum)
        {
            case 0:         // ����
                // �{�[���𐶐�
                Vector3 ballShootPos = new Vector3(/*�{�[���̌��݈ʒu*/0,0, transform.position.z);
                GameObject newBall = Instantiate(ballPrefab, ballShootPos, Quaternion.identity);
                newBall.tag = "Ball";   // �N���[���Ƀ^�OBall��ǉ�
                // �{�[���𔭎�

                break;
                 
            default:
                break;

        }
    }
}
