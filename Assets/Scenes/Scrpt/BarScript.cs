using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    // 移動時の加算用変数
    float vx = 0;
    float vy = 0;

    // 移動スピード
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1左右の入力を取得
        //float myX = Input.GetAxis("Horizontal");
        //位置情報の変更
        //transform.position += new Vector3(myX * 10, 0, 0) * Time.deltaTime;

        // 毎フレーム数値を初期化
        vx = 0;
        vy = 0;

        // 横移動
        if (Input.GetKey(KeyCode.A))
        {
            vx = -speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            vx = speed;
        }

        // 縦移動
        if (Input.GetKey(KeyCode.W))
        {
            vy = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vy = -speed;
        }

        // 実際の移動処理
        this.transform.Translate(vx / 50, vy / 50, 0);
    }
}
