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

    [SerializeField] GameObject ClearUI;
    [SerializeField] Toggle ClearToggle;

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
        ClearToggle.interactable = false;   // UI�𓧖���
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
            Time.timeScale = 1;
            switch (NowGame)
            {

                case GameSit.GameOver:  // �Q�[���I�[�o�[�Ȃ�
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        GameMode = false;
                        Debug.Log(GameMode);
                        Debug.Log("�Q�[���I�[�o�[�ɂȂ��Ă�����x�J�n���܂���");
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    // ���݂̃V�[����
                    }
                    break;

                case GameSit.GameClear: // �Q�[���N���A�Ȃ�
                    GameMode = false;
                    Debug.Log("�X�e�[�W��clear���܂���");
                    SceneChange(e_nowStage);

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
            Time.timeScale = 0; // �Q�[�����~�߂�
            GameMode = true;
        }
        // �Q�[�����̔j��\�I�u�W�F�N�g�������Ȃ�����
        BlockTags = GameObject.FindGameObjectsWithTag("BlockTypeB");
        if (BlockTags.Length==0)
        {
            NowGame = GameSit.GameClear;
            ClearToggle.interactable = true;
            Time.timeScale = 0;   // �Q�[�����~�߂�
            GameMode = true;
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
