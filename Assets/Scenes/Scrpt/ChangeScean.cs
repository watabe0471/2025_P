using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScean : MonoBehaviour
{

    // ステージ名
    [Header("ステージ")]
    //[SerializeField] Scene Stage1;
    [SerializeField] string Stage1;
    [SerializeField] string Stage2;
    [SerializeField] string Stage3;
    [SerializeField] string Stage4;

    private GameObject[] BallTags;
    private GameObject[] BlockTags;

    [SerializeField] GameObject ClearUI;
    [SerializeField] Toggle ClearToggle;

    public enum e_Stage     // ステージの識別
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
    // フレーム毎のUpdateS
    private void FixedUpdate()
    {
        BallTags = GameObject.FindGameObjectsWithTag("Ball");
        Debug.Log(BallTags.Length); //tagObjects.Lengthはオブジェクトの数
        // ゲーム内のボールが全て無くなったら
        if (BallTags.Length == 0)
        {
            Time.timeScale = 0;

            Debug.Log("Ballタグがついたオブジェクトはありません");
            // SceneChange(e_Stage.Stage1);
        }
        // ゲーム内の破壊可能オブジェクトが無くなったら
        BlockTags = GameObject.FindGameObjectsWithTag("BlockTypeB");
        if (BlockTags.Length==0)
        {
            ClearToggle.interactable = true;
            Time.timeScale = 0;   // ゲームを止める
            // SceneChange(e_Stage.Stage3);
        }


    }
    public void SceneChange(e_Stage NowStage)
    {
        // テスト

        switch(NowStage)        // ステージによって様々なステージに移動するように
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
