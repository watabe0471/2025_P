using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeSample : MonoBehaviour
{
    [SerializeField] private Image _fadePanel;
    [SerializeField] private float _fadeTime;

    private float _fadeAlpha = 0.0f;
    private bool _isfadeIn = false;
    private bool _isfadeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        _fadeAlpha = 1.0f;
        Debug.Log("�t�F�[�h�n�߂܂���");
        _isfadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�t�F�[�h����

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _fadeAlpha = 1.0f;
            Debug.Log("�t�F�[�h�n�߂܂���");
            _isfadeIn = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _fadeAlpha = 0.0f;
            Debug.Log("�t�F�[�h�n�߂܂���");
            _isfadeOut = true;
        }





        if (_isfadeIn)
        {
            FadeIn();
        }
        if (_isfadeOut)
        {
            FadeOut();
        }

        // �t�F�[�h
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    _fadeAlpha = 1.0f;
        //    _isfadeIn = true;
        //    _isfadeOut = false;
        //}

        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    _fadeAlpha = 0.0f;
        //    _isfadeOut = true;
        //    _isfadeIn = false;
        //}
        //// �t�F�[�h
        //if(_isfadeIn)
        //{
        //    FadeIn();
        //}

        //if (_isfadeOut)
        //{
        //    FadeOut();
        //}

    }

    private void FadeIn()
    {
        Debug.Log(_fadeAlpha);
        // �����ɂȂ�����
        if (_fadeAlpha <= 0.0f)
        {
            _fadeAlpha = 0.0f;
            _isfadeIn = false;
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
            return;
        }
        float fademin = Time.deltaTime / _fadeTime;
        _fadeAlpha = _fadeAlpha + fademin;
        _fadePanel.color = new Color(_fadePanel.color.r, _fadePanel.color.g, _fadePanel.color.b, _fadeAlpha);
    }
}
