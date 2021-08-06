using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene遷移を管理するクラス
/// </summary>
public class LoadSceneManager : SingletonMonoBehaviour<LoadSceneManager>
{
    [Header("タイトルのScene")]
    [SerializeField] const string m_titleScene = "Title";
    [Header("プレイするScene")]
    [SerializeField] const string m_mainScene = "Main";
    [Header("リザルトのScene")]
    [SerializeField] const string m_resultScene = "Result";
    [Header("ロード時に要する時間")]
    [SerializeField] float m_LoadTimer = 1.0f;
    [Header("フェード時に使用するImage")]
    [SerializeField] Image fadeImage;
    [Header("フェードの速度")]
    [SerializeField] float fadeSpeedValue = 1.0f;
    [Header("デバッグ用")]
    [SerializeField] bool m_debugMode = false;
    /// <summary> 現在のScene </summary>
    string m_currentScene = "";
    /// <summary> フェードアウトのフラグ </summary>
    public bool isFadeOut = false;
    /// <summary> フェードインのフラグ </summary>
    public bool isFadeIn = false;
    /// <summary> フェードさせるImageのRGBa </summary>
    float red, green, blue, alfa;
    /// <summary> Fade speed </summary>
    const float fadeSpeed = 0.01f;


    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        alfa = 1;
        SetAlfa();
    }

    void Start()
    {
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        SceneManager.sceneLoaded += OnSceneLoaded;

        if (SceneManager.GetActiveScene().name == m_titleScene)
        {
            Debug.Log("Title");
        }
        else if (SceneManager.GetActiveScene().name == m_mainScene)
        {
            Debug.Log("Main");
        }
        else if (SceneManager.GetActiveScene().name == m_resultScene)
        {
            Debug.Log("Result");
        }

        if (alfa > 0) isFadeIn = true;
    }

    void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        isFadeIn = true;

        m_currentScene = SceneManager.GetActiveScene().name;　///現在のSceneを更新する

        switch (SceneManager.GetActiveScene().name)
        {
            case m_titleScene:
                Debug.Log("Title");
                break;
            case m_mainScene:
                Debug.Log("Main");
                break;
            case m_resultScene:
                Debug.Log("Result");
                break;
        }
    }

    private void LateUpdate()
    {
        ///フェードイン
        if (isFadeIn)
        {
            StartFadeIn();///フェードイン開始
        }

        ///フェードアウト
        if (isFadeOut)
        {
            StartFadeOut();　///フェードアウト開始
        }

        if (m_debugMode)
        {

        }
    }

   
    /// <summary> タイトルへ遷移する </summary>
    public void LoadTitleScene()
    {
        Time.timeScale = 1f;
        isFadeOut = true;
        StartCoroutine(LoadScene(m_titleScene, m_LoadTimer));
    }

    /// <summary> ゲームシーンへ遷移する </summary>
    public void LoadMainScene()
    {
        isFadeOut = true;
        StartCoroutine(LoadScene(m_mainScene, m_LoadTimer));
    }

    /// <summary> リザルトへ遷移する </summary>
    public void LoadResultScene()
    {
        isFadeOut = true;
        StartCoroutine(LoadScene(m_resultScene, m_LoadTimer));
    }

    /// <summary> 任意のSceneへ遷移する </summary>
    public void AnyLoadScene(string loadScene)
    {
        isFadeOut = true;
        StartCoroutine(LoadScene(loadScene, m_LoadTimer));
    }

    /// <summary>
    /// Sceneのリスタート
    /// </summary>
    public void Restart()
    {
        isFadeOut = true;
        StartCoroutine(LoadScene(m_currentScene, m_LoadTimer));
    }

    /// <summary>
    /// クレジットへ遷移する
    /// </summary>
    public void LoadCredit()
    {
        isFadeOut = true;
        StartCoroutine(LoadScene("Credit", m_LoadTimer));
    }

    /// <summary>
    /// ゲームを終了する
    /// </summary>
    public void QuitGame()
    {
        isFadeOut = true;
        StartCoroutine(QuitScene(m_LoadTimer));
    }

    /// <summary>
    /// フェードアウトを開始する
    /// </summary>
    void StartFadeOut()
    {
        alfa += fadeSpeedValue * fadeSpeed;
        SetAlfa();

        if (alfa >= 1)
        {
            isFadeOut = false;
        }
    }

    /// <summary>
    /// フェードインを開始する
    /// </summary>
    void StartFadeIn()
    {
        alfa -= fadeSpeedValue * fadeSpeed;
        SetAlfa();

        if (alfa <= 0)
        {
            isFadeIn = false;
        }
    }

    void OffPanel()
    {
        isFadeIn = true;
    }

    void OnPanel()
    {
        isFadeOut = true;
    }
    /// <summary>
    /// アルファ値をImageにセットする
    /// </summary>
    void SetAlfa()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    IEnumerator LoadScene(string name, float timer)
    {
        yield return new WaitForSeconds(timer);

        SceneManager.LoadScene(name);
    }

    IEnumerator QuitScene(float timer)
    {
        yield return new WaitForSeconds(timer);

        Application.Quit();
    }
}
