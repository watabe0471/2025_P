using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kanichange : MonoBehaviour
{
    [SerializeField] private string Stage1;

    // フェード処理
    [SerializeField] private Image _fadePanel = null;
    [SerializeField] private float _fadeTime = 1.0f;

    private float _fadeAlpha = 0.0f;
    private bool _isfadeIn = false;
    private bool _isfadeOut = false;

    private bool FadeNow = false;
    private bool StartFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        _fadeAlpha = 1.0f;
        _isfadeIn = true;
        FadeNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    FadeNow = true;
        //    _fadeAlpha = 1.0f;
        //    Debug.Log("フェード始めました");
        //    _isfadeIn = true;
        //}
        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    _fadeAlpha = 0.0f;
        //    Debug.Log("フェード始めました");
        //    _isfadeOut = true;
        //}

        if (_isfadeIn)
        {
            FadeIn();
        }
        if (_isfadeOut)
        {
            FadeOut();
        }


        // ステージ切替
        if (Input.anyKey && FadeNow == false)
        {
            _fadeAlpha = 0.0f;
            Debug.Log("フェード始めました");
            _isfadeOut = true;
        }

        if(StartFlg == true)
        {
            SceneManager.LoadScene(Stage1);
        }
    }

    private void FadeIn()
    {
        Debug.Log(_fadeAlpha);
        // 透明になったら
        if (_fadeAlpha <= 0.0f)
        {
            _fadeAlpha = 0.0f;
            _isfadeIn = false;
            FadeNow = false;
            return;
        }
        float fademin = Time.deltaTime / _fadeTime;
        _fadeAlpha = _fadeAlpha - fademin;
        _fadePanel.color = new Color(_fadePanel.color.r, _fadePanel.color.g, _fadePanel.color.b, _fadeAlpha);
        Debug.Log(_fadeAlpha);
    }

    private void FadeOut()
    {
        if (_fadeAlpha >= 1.0f)
        {
            _fadeAlpha = 1.0f;
            _isfadeIn = false;
            StartFlg = true;
            FadeNow = false;
            return;
        }
        float fademin = Time.deltaTime / _fadeTime;
        _fadeAlpha = _fadeAlpha + fademin;
        _fadePanel.color = new Color(_fadePanel.color.r, _fadePanel.color.g, _fadePanel.color.b, _fadeAlpha);
    }

}
