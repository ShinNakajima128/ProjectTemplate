using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// 音関連を管理するクラス
/// </summary>
public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [Tooltip("BGMのAudioSource")]
    [SerializeField]
    AudioSource m_bgmAudioSource = default;

    [Tooltip("SEのAudioSource")]
    [SerializeField]
    AudioSource m_seAudioSource = default;

    [Tooltip("VOICEのAudioSource")]
    [SerializeField]
    AudioSource m_voiceAudioSource = default;

    [Tooltip("BGMの音量を管理するAudioMixerGroup")]
    [SerializeField]
    AudioMixerGroup m_bgmMixer = default;

    [Tooltip("SEの音量を管理するAudioMixerGroup")]
    [SerializeField]
    AudioMixerGroup m_seMixer = default;

    [Tooltip("BOICEの音量を管理するAudioMixerGroup")]
    [SerializeField]
    AudioMixerGroup m_voiceMixer = default;

    [Tooltip("同時に鳴らすSEの数")]
    [SerializeField]
    int m_maxSeNum = 10;

    [Tooltip("同時に鳴らすVOICEの数")]
    [SerializeField]
    int m_maxVoiceNum = 3;

    [SerializeField]
    Transform m_bgmSourceParent = default;

    [SerializeField]
    Transform m_seSourceParent = default;

    [SerializeField]
    Transform m_voiceSourceParent = default;

    [Header("デバッグ用")]
    [SerializeField]
    bool m_debug = false;


    [Tooltip("BGMのAudioSources")]
    AudioSource[] m_bgmAudioSources = default;

    [Tooltip("SEのAudioSources")]
    AudioSource[] m_seAudioSources = default;

    [Tooltip("VOICEのAudioSources")]
    AudioSource[] m_voiceAudioSources = default;

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Setup();
    }

    /// <summary>
    /// BGMを再生する
    /// </summary>
    /// <param name="clip"> 再生するBGM </param>
    public static void PlayBGM(AudioClip clip)
    {
        if (!Instance.m_bgmAudioSources[0].isPlaying && Instance.m_bgmAudioSources[1].isPlaying)
        {
            
        }
        else if (!Instance.m_bgmAudioSources[1].isPlaying && Instance.m_bgmAudioSources[0].isPlaying)
        {

        }
        else
        {
            Instance.m_bgmAudioSources[0].clip = clip;
            Instance.m_bgmAudioSources[0].loop = true;
            Instance.m_bgmAudioSources[0].Play();
        }
    }

    /// <summary>
    /// SEを再生する
    /// </summary>
    /// <param name="clip"> 再生するSE </param>
    public static void PlaySE(AudioClip clip)
    {
        foreach (var s in Instance.m_seAudioSources)
        {
            if (s.isPlaying)
            {
                continue;
            }
            else
            {
                s.clip = clip;
                s.PlayOneShot(clip);
                return;
            }
        }
        Debug.LogError("現在のSEの再生数が最大のため再生できませんでした");
    }

    /// <summary>
    /// ゲーム実行時にセットアップする
    /// </summary>
    void Setup()
    {
        m_bgmAudioSources = new AudioSource[2];

        for (int i = 0; i < m_bgmAudioSources.Length; i++)
        {
            m_bgmAudioSources[i] = Instantiate(m_bgmAudioSource, m_bgmSourceParent);
        }

        m_seAudioSources = new AudioSource[m_maxSeNum];

        for (int i = 0; i < m_seAudioSources.Length; i++)
        {
            m_seAudioSources[i] = Instantiate(m_seAudioSource, m_seSourceParent);
        }

        m_voiceAudioSources = new AudioSource[m_maxVoiceNum];

        for (int i = 0; i < m_voiceAudioSources.Length; i++)
        {
            m_voiceAudioSources[i] = Instantiate(m_voiceAudioSource, m_voiceSourceParent);
        }
    }
}