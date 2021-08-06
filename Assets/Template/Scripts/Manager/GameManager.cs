using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームを管理するクラス
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("タイトル画面のシーン名")]
    [SerializeField] string m_titleScene = "Title";
    [Header("メインゲーム画面のシーン名")]
    [SerializeField] string m_mainScene = "Main";
    [Header("リザルト画面のシーン名")]
    [SerializeField] string m_reslutScene = "Result";
    [Header("ゲームの状態")]
    [SerializeField] bool m_inGame = false;

    public bool InGame { get => m_inGame; }

    private void Awake()
    {
        if (Instance!= null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (SceneManager.GetActiveScene().name == "Title")
        {

        }
        else if (SceneManager.GetActiveScene().name == "Main")
        {

        }
        else if (SceneManager.GetActiveScene().name == "Result")
        {

        }
    }

    /// <summary>
    /// 各Sceneへ遷移した時に処理を実行する
    /// </summary>
    /// <param name="nextScene"> 遷移後のScene </param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Title":
                break;
            case "Main":
                break;
            case "Result":
                break;
            default:
                break;
        }
    }
}
