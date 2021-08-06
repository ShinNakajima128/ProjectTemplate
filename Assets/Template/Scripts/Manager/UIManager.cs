using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボタンを押した時の機能を持つクラス
/// </summary>
public class UIManager : MonoBehaviour
{
    Slider m_masterSlider;
    Slider m_bgmSlider;
    Slider m_seSlider;
    Slider m_voiceSlider;

    void Awake()
    {
        m_masterSlider = GameObject.FindGameObjectWithTag("Master").GetComponent<Slider>();
        m_bgmSlider = GameObject.FindGameObjectWithTag("BGM").GetComponent<Slider>();
        m_seSlider = GameObject.FindGameObjectWithTag("SE").GetComponent<Slider>();
        m_voiceSlider = GameObject.FindGameObjectWithTag("VOICE").GetComponent<Slider>();

        if (m_masterSlider) 
        { 
            m_masterSlider.value = SoundManager.Instance.GetMasterVolume; 
            Debug.Log("マスター音量：" + m_masterSlider.value); 
        }
        if (m_bgmSlider) 
        { 
            m_bgmSlider.value = SoundManager.Instance.GetBgmVolume; 
            Debug.Log("BGM音量：" + m_bgmSlider.value); 
        }
        if (m_seSlider) 
        { 
            m_seSlider.value = SoundManager.Instance.GetSeVolume; 
            Debug.Log("SE音量：" + m_seSlider.value); 
        }
        if (m_voiceSlider) 
        { 
            m_voiceSlider.value = SoundManager.Instance.GetVoiceVolume; 
            Debug.Log("ボイス音量：" + m_voiceSlider.value); 
        }
    }

    /// <summary>
    /// ゲームを開始する
    /// </summary>
    public void GamePlay()
    {
        LoadSceneManager.Instance.LoadMainScene();
    }

    /// <summary> 
    /// タイトル画面へ遷移する 
    /// </summary>
    public void GameQuit()
    {
        LoadSceneManager.Instance.QuitGame();
    }

    /// <summary>
    /// マスター音量を設定する
    /// </summary>
    public void SetMasterVolume()
    {
        SoundManager.Instance.MasterVolChange(m_masterSlider.value);
    }
    /// <summary>
    /// BGM音量を設定する
    /// </summary>
    public void SetBgmVolume()
    {
        SoundManager.Instance.BgmVolChange(m_bgmSlider.value);
    }
    /// <summary>
    /// SE音量を設定する
    /// </summary>
    public void SetSeVolume()
    {
        SoundManager.Instance.SeVolChange(m_seSlider.value);
    }
    /// <summary>
    /// ボイス音量を設定する
    /// </summary>
    public void SetVoiceVolume()
    {
        SoundManager.Instance.VoiceVolChange(m_voiceSlider.value);
    }
}
