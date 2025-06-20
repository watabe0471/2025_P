using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScean : MonoBehaviour
{

    // �X�e�[�W��
    [Header("�X�e�[�W")]
    //[SerializeField] Scene Stage1;
    [SerializeField] string Stage1;
    [SerializeField] string Stage2;
    [SerializeField] string Stage3;
    [SerializeField] string Stage4;

    private GameObject[] BallTags;
    private GameObject[] BlockTags;

    [SerializeField] GameObject ClearUI;
    [SerializeField] Toggle ClearToggle;

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
        ClearToggle.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    // �t���[������UpdateS
    private void FixedUpdate()
    {
        BallTags = GameObject.FindGameObjectsWithTag("Ball");
        Debug.Log(BallTags.Length); //tagObjects.Length�̓I�u�W�F�N�g�̐�
        // �Q�[�����̃{�[�����S�Ė����Ȃ�����
        if (BallTags.Length == 0)
        {
            Time.timeScale = 0;

            Debug.Log("Ball�^�O�������I�u�W�F�N�g�͂���܂���");
            // SceneChange(e_Stage.Stage1);
        }
        // �Q�[�����̔j��\�I�u�W�F�N�g�������Ȃ�����
        BlockTags = GameObject.FindGameObjectsWithTag("BlockTypeB");
        if (BlockTags.Length==0)
        {
            ClearToggle.interactable = true;
            Time.timeScale = 0;   // �Q�[�����~�߂�
            // SceneChange(e_Stage.Stage3);
        }


    }
    public void SceneChange(e_Stage NowStage)
    {
        // �e�X�g

        switch(NowStage)        // �X�e�[�W�ɂ���ėl�X�ȃX�e�[�W�Ɉړ�����悤��
        {
            case e_Stage.Stage1:
                SceneManager.LoadScene(Stage1);
                break;
            case e_Stage.Stage2:

                break;
            case e_Stage.Stage3:
                SceneManager.LoadScene(Stage3);
                break;
                
            default:

                break;
        }
        

    }
}
