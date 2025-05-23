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
        BallTag = GameObject.FindGameObjectsWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < BallTag.Length; i++)
        {
            if (BallTag[i] != null)
            {
                break;
            }
            SceneChange();
        }
    }







    public void SceneChange()
    {
        // テスト
        e_Stage NowStage = e_Stage.Stage1;


        switch(NowStage)
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
