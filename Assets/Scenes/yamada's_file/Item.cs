using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

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
            case 0:


                break;

            default:
                break;

        }
    }
}
