using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// 音関連を管理するクラス
/// </summary>
public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [Header("タイトル画面のScene名")]
    [SerializeField] const string m_titleScene = "Title";
    [Header("プレイ画面のScene名")]
    [SerializeField] const string m_gameScene = "GameScene";
    [Header("リザルト画面のScene名")]
    [SerializeField] const string m_resultScene = "Result";
    [Header("マスター音量")]
    [SerializeField, Range(0f, 1f)] float m_masterVolume = 1.0f;
    [Header("BGMの音量")]
    [SerializeField, Range(0f, 1f)] float m_bgmVolume = 0.1f;
    [Header("SEの音量")]
    [SerializeField, Range(0f, 1f)] float m_seVolume = 1.0f;
    [Header("VOICEの音量")]
    [SerializeField, Range(0f, 1f)] float m_voiceVolume = 1.0f;
    [Header("BGMリスト")]
    [SerializeField] AudioClip[] m_bgms = null;
    [Header("SEリスト")]
    [SerializeField] AudioClip[] m_ses = null;
    [Header("VOICEリスト")]
    [SerializeField] AudioClip[] m_voices = null;
    [Header("BGMのAudioSource")]
    [SerializeField] AudioSource m_bgmAudioSource = null;
    [Header("SEのAudioSource")]
    [SerializeField] AudioSource m_seAudioSource = null;
    [Header("VOICEのAudioSource")]
    [SerializeField] AudioSource m_voiceAudioSource = null;
    [SerializeField] bool m_debug = false;
    Dictionary<string, int> bgmIndex = new Dictionary<string, int>();
    Dictionary<string, int> seIndex = new Dictionary<string, int>();
    Dictionary<string, int> voiceIndex = new Dictionary<string, int>();

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < m_bgms.Length; i++)
        {
            bgmIndex.Add(m_bgms[i].name, i);
        }

        for (int i = 0; i < m_ses.Length; i++)
        {
            seIndex.Add(m_ses[i].name, i);
        }

        for (int i = 0; i < m_voices.Length; i++)
        {
            voiceIndex.Add(m_ses[i].name, i);
        }
    }

    private void Start()
    {
        if (Instance && !m_debug)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            if (SceneManager.GetActiveScene().name == m_titleScene)
            {
                PlayBgmByName("Title");
            }
            else if (SceneManager.GetActiveScene().name == m_gameScene)
            {
                PlayBgmByName("");
            }
            else if (SceneManager.GetActiveScene().name == m_resultScene)
            {
                PlayBgmByName("");
            }
        }  
    }

    /// <summary>
    /// Sceneが遷移した時にBGMを変更する
    /// </summary>
    /// <param name="nextScene">遷移後のScene</param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case m_titleScene:
                PlayBgmByName("Title");
                break;
            case m_gameScene:
                PlayBgmByName("");
                break;
            case m_resultScene:
                PlayBgmByName("");
                break;
        }
    }

    void Update()
    {
        m_bgmAudioSource.volume = m_bgmVolume * m_masterVolume;
        m_seAudioSource.volume = m_seVolume * m_masterVolume;
        m_voiceAudioSource.volume = m_voiceVolume * m_masterVolume;
    }

    public void PlayBgmByName(string name)
    {
        PlayBgm(GetBgmIndex(name));
    }

    public void PlaySeByName(string name)
    {
        PlaySe(GetSeIndex(name));
    }

    public void StopBgm()
    {
        m_bgmAudioSource.Stop();
        m_bgmAudioSource.clip = null;
    }

    public void StopSe()
    {
        m_seAudioSource.Stop();
        m_seAudioSource.clip = null;
    }

    int GetBgmIndex(string name)
    {
        if (bgmIndex.ContainsKey(name))
        {
            return bgmIndex[name];
        }
        else
        {
            return 0;
        }
    }

    int GetSeIndex(string name)
    {
        if (seIndex.ContainsKey(name))
        {
            return seIndex[name];
        }
        else
        {
            return 0;
        }
    }

    void PlayBgm(int index)
    {
        if (Instance != null)
        {
            index = Mathf.Clamp(index, 0, m_bgms.Length);

            m_bgmAudioSource.clip = m_bgms[index];
            m_bgmAudioSource.loop = true;
            m_bgmAudioSource.volume = m_bgmVolume * m_masterVolume;
            m_bgmAudioSource.Play();
        }
    }

    void PlaySe(int index)
    {
        index = Mathf.Clamp(index, 0, m_ses.Length);

        m_seAudioSource.PlayOneShot(m_ses[index], m_seVolume * m_masterVolume);
    }

    

    public void MasterVolChange()
    {
        m_masterVolume = GameObject.FindGameObjectWithTag("Master").GetComponent<Slider>().value;
        Debug.Log(m_masterVolume);
    }
    public void BGMVolChange()
    {
        m_bgmVolume = GameObject.FindGameObjectWithTag("BGM").GetComponent<Slider>().value;
        Debug.Log(m_bgmVolume);
    }
    public void SEVolChange()
    {
        m_seVolume = GameObject.FindGameObjectWithTag("SE").GetComponent<Slider>().value;
        Debug.Log(m_seVolume);
    }
}