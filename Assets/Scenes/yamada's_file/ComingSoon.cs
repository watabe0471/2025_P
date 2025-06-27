using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComingSoon : MonoBehaviour
{
    [SerializeField] private string Title = null;

    [SerializeField] private float Timer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer - Time.deltaTime;
        Debug.Log(Timer);
        if(Timer < 0.0f)
        {
            SceneManager.LoadScene(Title);
        }
    }
}
