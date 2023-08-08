using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    #region Properties
    public static AudioHandler Instance = null;

    [Header("Audioclips Reference")]
    [SerializeField] private AudioClip uiButtonClickSFX = null;
    [SerializeField] private AudioClip lightToggleBtnClickSFX = null;

    [Header("Components Reference")]
    [SerializeField] private AudioSource audioSource = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        // Singleton setup for AudioHandler component
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    #endregion

    #region Public Core Functions
    public void PlayUIBtnClickSFX()
    {
        // Play audioclip
        audioSource.PlayOneShot(uiButtonClickSFX);
    }

    public void PlayLightToggleBtnClickSFX()
    {
        // Play audioclip
        audioSource.PlayOneShot(lightToggleBtnClickSFX);
    }
    #endregion
}
