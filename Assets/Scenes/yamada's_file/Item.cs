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

        Debug.Log("�A�C�e�������܂���");
        Debug.Log("�A�C�e���ԍ�" + ItemNum);

        switch (ItemNum)
        {
            case 0:


                break;

            default:
                break;

        }
    }
}
