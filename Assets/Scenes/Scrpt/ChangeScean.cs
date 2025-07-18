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

    // 入れ物
    private GameObject[] BallTags;
    private GameObject[] BlockTags;

    // UIの表示場所
    [Header("UIの表示位置")]
    [SerializeField] Vector3 UIpos = new Vector3(0.0f, 6.0f, -2.0f);
    [SerializeField] Vector3 RETRYpos = new Vector3(0.0f, -6, -2.0f);
    [SerializeField] Vector3 BGpos = new Vector3(0.0f, 0.0f, -1.2f);

    [Header("クリア時のUI")]
    [SerializeField] GameObject ClearUI;    // クリア時に表示される文字



    [Header("ゲームオーバー時のUI")]
    [SerializeField] GameObject OverUI;    // オーバー時に表示される文字
    [SerializeField] GameObject RetryUI;    

    [Header("背景")]
    public GameObject ClearBack; //クリア、ゲームオーバー時の背景


    private string NowSceneName;    // 現在シーン名
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
        NowSceneName = SceneManager.GetActiveScene().name;

        // ステージ名から次のステージを取得
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
        // ゲームが止まっているか
        if (GameMode != true) return;

        // ゲームがどの状態なのか
        switch (NowGame)
        {
            case GameSit.GameOver:  // ゲームオーバーなら
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameMode = false;   // ゲームが動くように
                    Time.timeScale = 1; // ゲーム時間を進める
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);    // 現在のシーンへ
                }
                break;

            case GameSit.GameClear: // ゲームクリアなら
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameMode = false;   // ゲームが動くように
                    Time.timeScale = 1; // ゲーム時間を進める
                    SceneChange(e_nowStage);        // 次のシーンへ
                }
                break;
                
            default:    // それ以外
                break;
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
            // Instantiate(RetryUI, RETRYpos, Quaternion.identity);   // リトライの文字を表示

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
                SceneManager.LoadScene(Title);
                break;

            default:
                break;
        }
    }
}
