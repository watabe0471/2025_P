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
    [SerializeField] string Stage1 = "Stage1";
    [SerializeField] string Stage2 = "Stage2";
    [SerializeField] string Stage3 = "Stage3";
    [SerializeField] string Stage4 = "Stage4";
    [SerializeField] string Stage5 = "Stage5";
    [SerializeField] string Stage6 = "Stage6";
    [SerializeField] string Stage7 = "Stage7";

    // ���ꕨ
    private GameObject[] BallTags;
    private GameObject[] BlockTags;

    // UI�̕\���ꏊ
    [Header("UI�̕\���ʒu")]
    [SerializeField] Vector3 UIpos = new Vector3(0.0f, 6.0f, -2.0f);
    [SerializeField] Vector3 RETRYpos = new Vector3(0.0f, -6, -2.0f);
    [SerializeField] Vector3 BGpos = new Vector3(0.0f, 0.0f, -1.2f);

    [Header("�N���A����UI")]
    [SerializeField] GameObject ClearUI;    // �N���A���ɕ\������镶��



    [Header("�Q�[���I�[�o�[����UI")]
    [SerializeField] GameObject OverUI;    // �I�[�o�[���ɕ\������镶��
    [SerializeField] GameObject RetryUI;    

    [Header("�w�i")]
    public GameObject ClearBack; //�N���A�A�Q�[���I�[�o�[���̔w�i


    private string NowSceneName;    // ���݃V�[����
    private GameSit NowGame = GameSit.InGame;   // �Q�[���̏��
    private e_Stage e_nowStage = e_Stage.Title; // ���݂̃V�[���ԍ�

    private bool GameMode = false;

    public enum e_Stage     // �X�e�[�W�̎���
    {
        Title,
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Stage5,
        Stage6,
        Stage7,
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
        // ���݂̃V�[�������擾
        NowSceneName = SceneManager.GetActiveScene().name;

        // �X�e�[�W�����玟�̃X�e�[�W���擾
        {
            if (NowSceneName == Stage1)
                e_nowStage = e_Stage.Stage2;
            else if (NowSceneName == Stage2)
                e_nowStage = e_Stage.Stage3;
            else if (NowSceneName == Stage3)
                e_nowStage = e_Stage.Stage4;
            else if (NowSceneName == Stage4)
                e_nowStage = e_Stage.Stage5;
            else if (NowSceneName == Stage5)
                e_nowStage = e_Stage.Stage6;
            else if (NowSceneName == Stage6)
                e_nowStage = e_Stage.Stage7;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[�����~�܂��Ă��邩
        if (GameMode != true) return;

        // �Q�[�����ǂ̏�ԂȂ̂�
        switch (NowGame)
        {
            case GameSit.GameOver:  // �Q�[���I�[�o�[�Ȃ�
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameMode = false;   // �Q�[���������悤��
                    Time.timeScale = 1; // �Q�[�����Ԃ�i�߂�
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);    // ���݂̃V�[����
                }
                break;

            case GameSit.GameClear: // �Q�[���N���A�Ȃ�
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameMode = false;   // �Q�[���������悤��
                    Time.timeScale = 1; // �Q�[�����Ԃ�i�߂�
                    SceneChange(e_nowStage);        // ���̃V�[����
                }
                break;
                
            default:    // ����ȊO
                break;
        }
    }
    // �t���[������UpdateS
    private void FixedUpdate()
    {
        // �{�[����S�Ď擾
        BallTags = GameObject.FindGameObjectsWithTag("Ball");
        // �j��\�u���b�N���擾
        BlockTags = GameObject.FindGameObjectsWithTag("BlockTypeB");

        // �Q�[�����̃{�[�����S�Ė����Ȃ�����
        if (BallTags.Length <= 0)
        {
            // �Q�[���I�[�o�[�ݒ�
            NowGame = GameSit.GameOver;
            
            // �Q�[���I�[�o��ʂ�\��
            Instantiate(ClearBack, BGpos, Quaternion.identity);//�s�����̔w�i��\��
            Instantiate(OverUI, UIpos, Quaternion.identity);   // �Q�[���I�[�o�[�̕�����\��
            // Instantiate(RetryUI, RETRYpos, Quaternion.identity);   // ���g���C�̕�����\��

            // �Q�[���I�[�o�[����
            Time.timeScale = 0;     // �Q�[�����~�߂�
            GameMode = true;        // �~�܂������t���O
        }

        // �Q�[�����̔j��\�I�u�W�F�N�g�������Ȃ�����
        if (BlockTags.Length <= 0)
        {
            // �Q�[���N���A�ݒ�
            NowGame = GameSit.GameClear;

            //  �Q�[���N���A���
            Instantiate(ClearBack, BGpos, Quaternion.identity);//�s�����̔w�i��\��
            Instantiate(ClearUI, UIpos, Quaternion.identity);   // �Q�[���I�[�o�[�̕�����\��

            // �Q�[���N���A����
            Time.timeScale = 0;     // �Q�[�����~�߂�
            GameMode = true;        // �~�܂������t���O
        }


    }


    // �X�e�[�W�J��
    // ���݂̃X�e�[�W���Q�Ƃ��Ď��̃X�e�[�W�Ɉړ�����
    public void SceneChange(e_Stage NowStage)
    {
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
            case e_Stage.Stage5:
                SceneManager.LoadScene(Stage5);
                break;
            case e_Stage.Stage6:
                SceneManager.LoadScene(Stage6);
                break;
            case e_Stage.Stage7:
                SceneManager.LoadScene(Title);
                break;

            default:
                break;
        }
    }
}
