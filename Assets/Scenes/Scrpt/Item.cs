using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [Header("球のオブジェクト")]
    [SerializeField] private GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        int ItemNum = Random.Range(0, 3);

        Debug.Log("アイテムが壊れました");
        Debug.Log("アイテム番号" + ItemNum);

        switch (ItemNum)
        {
            case 0:         // 分裂球
                // ボールを生成
                Vector3 ballShootPos = new Vector3(/*ボールの現在位置*/0,0, transform.position.z);
                GameObject newBall = Instantiate(ballPrefab, ballShootPos, Quaternion.identity);
                newBall.tag = "Ball";   // クローンにタグBallを追加
                // ボールを発射

                break;
                 
            default:
                break;

        }
    }
}
