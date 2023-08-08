using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBtnHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private Sprite lightOffSprite = null;
    [SerializeField] private Sprite lightOnSprite = null;

    [Header("Components Reference")]
    [SerializeField] private Image lightImg = null;
    [SerializeField] private Button lightBtn = null;
    #endregion

    #region MonoBehaviour Functions
    #endregion

    #region Getter And Setter
    // Light button status whether it is on or off
    public LightStatus LightActiveStatus { get; set; }
    #endregion

    #region Public Core Functions
    public void UpdateLightStatus(LightStatus status)
    {
        // Update light status (Called only at start to setup new grid for the player to solve)

        LightActiveStatus = status;
        if (status == LightStatus.On)
        {
            lightImg.sprite = lightOnSprite;
        }
        else
        {
            lightImg.sprite = lightOffSprite;
        }
    }

    public void ToggleLight()
    {
        // Toggle the light on->off and off->on

        if (LightActiveStatus == LightStatus.Off)
        {
            LightActiveStatus = LightStatus.On;
            lightImg.sprite = lightOnSprite;
        }
        else
        {
            LightActiveStatus = LightStatus.Off;
            lightImg.sprite = lightOffSprite;
        }
    }

    public void ActivateBtn(bool value)
    {
        // Activate or deactivate light btn interaction
        lightBtn.interactable = value;
    }
    #endregion
}
