using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTest : MonoBehaviour
{
    [SerializeField]
    Button m_playBGMButton = default;

    [SerializeField]
    Button m_playSEButton = default;

    [SerializeField]
    AudioClip m_bgm = default;

    [SerializeField]
    AudioClip[] m_ses = default;

    void Start()
    {
        m_playBGMButton.onClick.AddListener(() =>
        {
            SoundManager.PlayBGM(m_bgm);
        });

        m_playBGMButton.onClick.AddListener(() =>
        {
            SoundManager.PlaySE(m_ses[0]);
        });
    }

}
