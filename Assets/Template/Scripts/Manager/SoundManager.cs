﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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

    void Start()
    {
       
    }

    /// <summary>
    /// Sceneが遷移した時にBGMを変更する
    /// </summary>
    /// <param name="nextScene">遷移後のScene</param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
       
    }

    public static void PlayBGM(AudioClip clip)
    {
        if (!Instance.m_bgmAudioSources[0].isPlaying)
        {
            Instance.m_bgmAudioSources[0].clip = clip;
            Instance.m_bgmAudioSources[0].loop = true;
            Instance.m_bgmAudioSources[0].Play();
        }
        else
        {
            Instance.m_bgmAudioSources[1].clip = clip;
            Instance.m_bgmAudioSources[1].loop = true;
            Instance.m_bgmAudioSources[1].Play();

            Instance.m_bgmAudioSources[0].Stop();
            Instance.m_bgmAudioSources[0].clip = default;
        }
    }
}