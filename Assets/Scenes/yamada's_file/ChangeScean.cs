using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScean : MonoBehaviour
{

    // ステージ名
    [Header("ステージ")]
    [SerializeField] Scene Stage1;

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

    public void SceneChange(e_Stage NowStage)
    {

        switch(NowStage)
        {
            case e_Stage.Stage1:
                SceneManager.LoadScene(Stage1.name);
                break;
            case e_Stage.Stage2:

                break;

            default:

                break;
        }
        

    }
}
