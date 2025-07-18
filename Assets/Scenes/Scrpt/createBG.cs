using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBG : MonoBehaviour
{

    [SerializeField] private GameObject BG = null;
    [SerializeField] private Vector3 Pos1;
    [SerializeField] private Vector3 Pos2;
    public static GameObject ba;
    public static Vector3 no;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Copy1 = Instantiate(BG, Pos1, Quaternion.identity);
        GameObject Copy2 = Instantiate(BG, Pos2, Quaternion.identity);
        no = Pos1;
        ba = BG;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CopyBG()
    {
        GameObject Copy = Instantiate(ba, no, Quaternion.identity);
    }
}
