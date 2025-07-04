using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScean : MonoBehaviour
{

    // �X�e�[�W��
    [Header("�X�e�[�W")]
    [SerializeField] string Title;
    [SerializeField] string Stage1;
    [SerializeField] string Stage2;
    [SerializeField] string Stage3;
    [SerializeField] string Stage4;

    private GameObject[] BallTags;
    private GameObject[] BlockTags;

    [Header("�N���A����UI")]
    [SerializeField] GameObject ClearUI;    // �N���A���ɕ\������镶��
    
    [SerializeField] Vector3 UIpos = new Vector3(0.0f, 6.0f, -2.0f); // UI�̕\���ꏊ
    [SerializeField] Vector3 BGpos = new Vector3(0.0f, 0.0f, -1.2f);

    [Header("�Q�[���I�[�o�[����UI")]
    [SerializeField] GameObject OverUI;    // �I�[�o�[���ɕ\������镶��
    [SerializeField] GameObject RetryUI;

    public GameObject ClearBack; //�N���A�A�Q�[���I�[�o�[���̔w�i

    private string NextSceneName;    // ���݃V�[����
    private GameSit NowGame = GameSit.InGame;   // �Q�[���̏��
    private e_Stage e_nowStage = e_Stage.Title; // ���݂̃V�[���ԍ�

    private bool GameMode = false;

    public enum e_Stage     // �X�e�[�W�̎���
    {
        Title,
        Stage1,
        Stage2,
        Stage3,
        Stage4
    }
    public enum GameSit     // �Q�[���̏�Ԃ̎���
    {
        GameClear,
        GameOver,
        InGame
    }
    // Start is called before the first frame update
    void Start()
    {
        NextSceneName = SceneManager.GetActiveScene().name;

        // �X�e�[�W�����玟�̃X�e�[�W���擾
        {
            if (NextSceneName == Stage1)
                e_nowStage = e_Stage.Stage2;
            else if (NextSceneName == Stage2)
                e_nowStage = e_Stage.Stage3;
            else if (NextSceneName == Stage3)
                e_nowStage = e_Stage.Stage4;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (GameMode == true)
        {
            switch (NowGame)
            {

                case GameSit.GameOver:  // �Q�[���I�[�o�[�Ȃ�

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        GameMode = false;
                        Debug.Log("�Q�[���I�[�o�[�ɂȂ��Ă�����x�J�n���܂���");
                        Time.timeScale = 1;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    // ���݂̃V�[����
                    }
                    break;

                case GameSit.GameClear: // �Q�[���N���A�Ȃ�
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        GameMode = false;
                        Debug.Log("�X�e�[�W��clear���܂���");
                        Time.timeScale = 1;
                        SceneChange(e_nowStage);
                    }
                    break;


                default:    // ����ȊO
                    break;
            }
        }
    }
    // �t���[������UpdateS
    private void FixedUpdate()
    {
        BallTags = GameObject.FindGameObjectsWithTag("Ball");
        // Debug.Log(BallTags.Length); //tagObjects.Length�̓I�u�W�F�N�g�̐�
        // �Q�[�����̃{�[�����S�Ė����Ȃ�����
        if (BallTags.Length == 0)
        {
            NowGame = GameSit.GameOver;
            //OverToggle.interactable = true;    // �w�i��s������
            Instantiate(ClearBack, BGpos, Quaternion.identity);//�s�����̔w�i��\��
            Instantiate(OverUI, UIpos, Quaternion.identity);   // �Q�[���I�[�o�[�̕�����\��
            Time.timeScale = 0;     // �Q�[�����~�߂�
            GameMode = true;        // �~�܂������t���O
            Debug.Log("�Q�[�����~�܂���");
        }
        // �Q�[�����̔j��\�I�u�W�F�N�g�������Ȃ�����
        BlockTags = GameObject.FindGameObjectsWithTag("BlockTypeB");
        if (BlockTags.Length == 0)
        {
            NowGame = GameSit.GameClear;
            //ClearToggle.interactable = true;    // �w�i��s������
            Instantiate(ClearBack, BGpos, Quaternion.identity);//�s�����̔w�i��\��
            Instantiate(ClearUI, UIpos, Quaternion.identity);   // �Q�[���I�[�o�[�̕�����\��
            Time.timeScale = 0;     // �Q�[�����~�߂�
            GameMode = true;        // �~�܂������t���O
            Debug.Log("�Q�[�����~�܂���");
        }


    }
    public void SceneChange(e_Stage NowStage)
    {
        Debug.Log("�X�e�[�W���ړ�");
        switch (NowStage)        // �X�e�[�W�ɂ���ėl�X�ȃX�e�[�W�Ɉړ�����悤��
        {
            case e_Stage.Title:
                // SceneManager.LoadScene();
                break;
            case e_Stage.Stage1:
                SceneManager.LoadScene(Stage1);
                break;
            case e_Stage.Stage2:
                SceneManager.LoadScene(Stage2);
                break;
            case e_Stage.Stage3:
                SceneManager.LoadScene(Stage3);
                break;
            case e_Stage.Stage4:
                SceneManager.LoadScene(Stage4);
                break;

            default:

                break;
        }



        //switch(NowStage)        // �X�e�[�W�ɂ���ėl�X�ȃX�e�[�W�Ɉړ�����悤��
        //{
        //    case e_Stage.Title:
        //        // SceneManager.LoadScene();
        //        break;
        //    case e_Stage.Stage1:
        //        SceneManager.LoadScene(Stage1);
        //        break;
        //    case e_Stage.Stage2:

        //        break;
        //    case e_Stage.Stage3:
        //        SceneManager.LoadScene(Stage3);
        //        break;

        //    default:

        //        break;
        //}
    }
}
