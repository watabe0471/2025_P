using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate5 : MonoBehaviour
{
    //初期値
    float x = 0.6f;
    float y = -2.0f;

    public GameObject BreakBlock;
    public GameObject NoBreakBlock;

    // Start is called before the first frame update
    void Start()
    {
        //1段目
        Instantiate(BreakBlock, new Vector3(x, y, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 1.2f, y, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 2.4f, y, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 3.6f, y, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 4.8f, y, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 6.0f, y, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 7.2f, y, 0.0f), Quaternion.identity);

        Instantiate(BreakBlock, new Vector3(x - 1.2f, y, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 2.4f, y, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 3.6f, y, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 4.8f, y, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 6.0f, y, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 7.2f, y, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 8.4f, y, 0.0f), Quaternion.identity);

        //2段目
        Instantiate(BreakBlock, new Vector3(x, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 1.2f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 2.4f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 3.6f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 4.8f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 6.0f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 7.2f, y + 1.2f, 0.0f), Quaternion.identity);

        Instantiate(BreakBlock, new Vector3(x - 1.2f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 2.4f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 3.6f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 4.8f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 6.0f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 7.2f, y + 1.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 8.4f, y + 1.2f, 0.0f), Quaternion.identity);

        //3段目
        Instantiate(NoBreakBlock, new Vector3(x, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 1.2f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 2.4f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 3.6f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 4.8f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 6.0f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 7.2f, y + 2.4f, 0.0f), Quaternion.identity);

        Instantiate(NoBreakBlock, new Vector3(x - 1.2f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 2.4f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 3.6f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 4.8f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 6.0f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 7.2f, y + 2.4f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 8.4f, y + 2.4f, 0.0f), Quaternion.identity);


        //4段目
        Instantiate(NoBreakBlock, new Vector3(x, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 1.2f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 2.4f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 3.6f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 4.8f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 6.0f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 7.2f, y + 3.6f, 0.0f), Quaternion.identity);

        Instantiate(NoBreakBlock, new Vector3(x - 1.2f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 2.4f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 3.6f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 4.8f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 6.0f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 7.2f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 7.2f, y + 3.6f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 8.4f, y + 3.6f, 0.0f), Quaternion.identity);

        //5段目
        Instantiate(NoBreakBlock, new Vector3(x, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 1.2f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 2.4f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 3.6f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 4.8f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 6.0f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 7.2f, y + 4.8f, 0.0f), Quaternion.identity);

        Instantiate(NoBreakBlock, new Vector3(x - 1.2f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 2.4f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 3.6f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 4.8f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 6.0f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 7.2f, y + 4.8f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 8.4f, y + 4.8f, 0.0f), Quaternion.identity);

        //6段目
        Instantiate(BreakBlock, new Vector3(x, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 1.2f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 2.4f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 3.6f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 4.8f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 6.0f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 7.2f, y + 6.0f, 0.0f), Quaternion.identity);

        Instantiate(BreakBlock, new Vector3(x - 1.2f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 2.4f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 3.6f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 4.8f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 6.0f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 7.2f, y + 6.0f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 8.4f, y + 6.0f, 0.0f), Quaternion.identity);

        //7段目
        Instantiate(BreakBlock, new Vector3(x, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 1.2f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 2.4f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 3.6f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 4.8f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x + 6.0f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x + 7.2f, y + 7.2f, 0.0f), Quaternion.identity);

        Instantiate(BreakBlock, new Vector3(x - 1.2f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 2.4f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 3.6f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 4.8f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 6.0f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(NoBreakBlock, new Vector3(x - 7.2f, y + 7.2f, 0.0f), Quaternion.identity);
        Instantiate(BreakBlock, new Vector3(x - 8.4f, y + 7.2f, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
