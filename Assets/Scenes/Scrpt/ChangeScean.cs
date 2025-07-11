using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScean : MonoBehaviour
{

    // ステージ名
    [Header("ステージ")]
    [SerializeField] string Title;
    [SerializeField] string Stage1 = "Stage1";
    [SerializeField] string Stage2 = "Stage2";
    [SerializeField] string Stage3 = "Stage3";
    [SerializeField] string Stage4 = "Stage4";
    [SerializeField] string Stage5 = "Stage5";
    [SerializeField] string Stage6 = "Stage6";
    [SerializeField] string Stage7 = "Stage7";

    private GameObject[] BallTags;
    private GameObject[] BlockTags;

    [Header("クリア時のUI")]
    [SerializeField] GameObject ClearUI;    // クリア時に表示される文字

    // UIの表示場所
    [SerializeField] Vector3 UIpos = new Vector3(0.0f, 6.0f, -2.0f);
    [SerializeField] Vector3 BGpos = new Vector3(0.0f, 0.0f, -1.2f);

    [Header("ゲームオーバー時のUI")]
    [SerializeField] GameObject OverUI;    // オーバー時に表示される文字
    [SerializeField] GameObject RetryUI;

    public GameObject ClearBack; //クリア、ゲームオーバー時の背景

    private string NextSceneName;    // 現在シーン名
    private GameSit NowGame = GameSit.InGame;   // ゲームの状態
    private e_Stage e_nowStage = e_Stage.Title; // 現在のシーン番号

    private bool GameMode = false;

    public enum e_Stage     // ステージの識別
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
    public enum GameSit     // ゲームの状態の識別
    {
        GameClear,
        GameOver,
        InGame
    }
    // Start is called before the first frame update
    void Start()
    {
        // 現在のシーン名を取得
         NextSceneName = SceneManager.GetActiveScene().name;

        // ステージ名から次のステージを取得
        {
            if (NextSceneName == Stage1)
                e_nowStage = e_Stage.Stage2;
            else if (NextSceneName == Stage2)
                e_nowStage = e_Stage.Stage3;
            else if (NextSceneName == Stage3)
                e_nowStage = e_Stage.Stage4;
            else if (NextSceneName == Stage4)
                e_nowStage = e_Stage.Stage5;
            else if (NextSceneName == Stage5)
                e_nowStage = e_Stage.Stage6;
            else if (NextSceneName == Stage6)
                e_nowStage = e_Stage.Stage7;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (GameMode == true)
        {
            switch (NowGame)
            {

                case GameSit.GameOver:  // ゲームオーバーなら

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        GameMode = false;
                        Debug.Log("ゲームオーバーになってもう一度開始しました");
                        Time.timeScale = 1;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    // 現在のシーンへ
                    }
                    break;

                case GameSit.GameClear: // ゲームクリアなら
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        GameMode = false;
                        Debug.Log("ステージをclearしました");
                        Time.timeScale = 1;
                        SceneChange(e_nowStage);
                    }
                    break;


                default:    // それ以外
                    break;
            }
        }
    }
    // フレーム毎のUpdateS
    private void FixedUpdate()
    {
        // ボールを全て取得
        BallTags = GameObject.FindGameObjectsWithTag("Ball");
        // 破壊可能ブロックを取得
        BlockTags = GameObject.FindGameObjectsWithTag("BlockTypeB");

        // ゲーム内のボールが全て無くなったら
        if (BallTags.Length <= 0)
        {
            // ゲームオーバー設定
            NowGame = GameSit.GameOver;
            
            // ゲームオーバ画面を表示
            Instantiate(ClearBack, BGpos, Quaternion.identity);//不透明の背景を表示
            Instantiate(OverUI, UIpos, Quaternion.identity);   // ゲームオーバーの文字を表示

            // ゲームオーバー処理
            Time.timeScale = 0;     // ゲームを止める
            GameMode = true;        // 止まった時フラグ
        }

        // ゲーム内の破壊可能オブジェクトが無くなったら
        if (BlockTags.Length <= 0)
        {
            // ゲームクリア設定
            NowGame = GameSit.GameClear;

            //  ゲームクリア画面
            Instantiate(ClearBack, BGpos, Quaternion.identity);//不透明の背景を表示
            Instantiate(ClearUI, UIpos, Quaternion.identity);   // ゲームオーバーの文字を表示

            // ゲームクリア処理
            Time.timeScale = 0;     // ゲームを止める
            GameMode = true;        // 止まった時フラグ
        }


    }


    // ステージ遷移
    // 現在のステージを参照して次のステージに移動する
    public void SceneChange(e_Stage NowStage)
    {
        switch (NowStage)        // ステージによって様々なステージに移動するように
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
                SceneManager.LoadScene(Stage7);
                break;

            default:

                break;
        }



        //switch(NowStage)        // ステージによって様々なステージに移動するように
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
