using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScean : MonoBehaviour
{

    // �X�e�[�W��
    [Header("�X�e�[�W")]
    //[SerializeField] Scene Stage1;
    [SerializeField] string Stage1;
    [SerializeField] string Stage2;
    [SerializeField] string Stage3;
    [SerializeField] string Stage4;

    private GameObject[] BallTag;

    public enum e_Stage     // �X�e�[�W�̎���
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    // �t���[������UpdateS
    private void FixedUpdate()
    {
        BallTag = GameObject.FindGameObjectsWithTag("Ball");
        Debug.Log(BallTag.Length); //tagObjects.Length�̓I�u�W�F�N�g�̐�
        if (BallTag.Length == 0)
        {
            Debug.Log("Ball�^�O�������I�u�W�F�N�g�͂���܂���");
            SceneChange();
        }
    }
    public void SceneChange()
    {
        // �e�X�g
        e_Stage NowStage = e_Stage.Stage1;

        switch(NowStage)        // �X�e�[�W�ɂ���ėl�X�ȃX�e�[�W�Ɉړ�����悤��
        {
            case e_Stage.Stage1:
                SceneManager.LoadScene(Stage1);
                break;
            case e_Stage.Stage2:

                break;

            default:

                break;
        }
        

    }
}
