using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScean : MonoBehaviour
{

    // ステージ名
    [Header("ステージ")]
    //[SerializeField] Scene Stage1;
    [SerializeField] string Stage1;
    [SerializeField] string Stage2;
    [SerializeField] string Stage3;
    [SerializeField] string Stage4;

    private GameObject[] BallTag;

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
    }

    // Update is called once per frame
    void Update()
    {

    }
    // フレーム毎のUpdateS
    private void FixedUpdate()
    {
        BallTag = GameObject.FindGameObjectsWithTag("Ball");
        Debug.Log(BallTag.Length); //tagObjects.Lengthはオブジェクトの数
        if (BallTag.Length == 0)
        {
            Debug.Log("Ballタグがついたオブジェクトはありません");
            SceneChange();
        }
    }
    public void SceneChange()
    {
        // テスト
        e_Stage NowStage = e_Stage.Stage1;

        switch(NowStage)        // ステージによって様々なステージに移動するように
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
