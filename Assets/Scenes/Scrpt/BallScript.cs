using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //Rigitbodyを扱える変数
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //2)Rigidbodyを取得して代入
        rb = GetComponent<Rigidbody>();

        //3)右奥方向に力を加える(x.y軸)
        //力を加える方向を決める
        Vector3 myDirection = new Vector3(5, 5, 0);
        
        rb.AddForce(myDirection,ForceMode.Impulse);//インパルスモードで瞬間的に力を加える
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
