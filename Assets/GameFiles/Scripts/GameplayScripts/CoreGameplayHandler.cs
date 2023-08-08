using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Grid row class to store all elements present in the row
[System.Serializable]
public class GridRow
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private List<LightBtnHandler> lightBtnHandlers = new List<LightBtnHandler>();
    #endregion

    #region Getter And Setter
    public List<LightBtnHandler> GetLightBtnHandlers { get => lightBtnHandlers; }
    #endregion
}

public class CoreGameplayHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private List<GridRow> lightGrid = new List<GridRow>();
    [SerializeField] private GridPatterns gridPatterns = null;
    [SerializeField] private TextMeshProUGUI gameTimerTMP = null;
    [SerializeField] private TextMeshProUGUI playerMoveCounterTMP = null;
    #endregion

    #region MonoBeahviour Functions
    #endregion

    #region Private Core Functions
    private void CheckForVictory()
    {
        // Count player move count and update it on UI
        GameManager.Instance.MoveCounter++;
        playerMoveCounterTMP.SetText(GameManager.Instance.MoveCounter.ToString());

        // Force check whether all lights are off
        bool victory = true;
        for (int i = 0; i < lightGrid.Count; i++)
        {
            for (int j = 0; j < lightGrid[i].GetLightBtnHandlers.Count; j++)
            {
                if (lightGrid[i].GetLightBtnHandlers[j].LightActiveStatus == LightStatus.On)
                {
                    victory = false;
                    break;
                }
            }
        }

        // If all lights are off
        if (victory)
        {
            // Stops game timer
            GameManager.Instance.ActivateGameTimer(false);
            // Display victory message on screen
            UIManager.Instance.DisplayGameOverUIElements();

            //Save user level
            PlayerPrefs.SetInt("UserLevel", (PlayerPrefs.GetInt("UserLevel") + 1));

            print(PlayerPrefs.GetInt("UserLevel"));
        }
    }
    #endregion

    #region Btn Events Functions
    public void OnClick_ToggleLightBtn_Row_1(int col)
    {
        // Toggle button function for row - 1 of the grid
        lightGrid[0].GetLightBtnHandlers[col].ToggleLight();
        lightGrid[0 + 1].GetLightBtnHandlers[col].ToggleLight();

        if (col > 0)
        {
            lightGrid[0].GetLightBtnHandlers[col - 1].ToggleLight();
        }

        if (col < 4)
        {
            lightGrid[0].GetLightBtnHandlers[col + 1].ToggleLight();
        }

        // Force check whether all lights are off
        CheckForVictory();

        // Play button click audioclip/SFX
        AudioHandler.Instance.PlayLightToggleBtnClickSFX();
    }

    public void OnClick_ToggleLightBtn_Row_2(int col)
    {
        // Toggle button function for row - 2 of the grid
        lightGrid[1].GetLightBtnHandlers[col].ToggleLight();
        lightGrid[1 - 1].GetLightBtnHandlers[col].ToggleLight();
        lightGrid[1 + 1].GetLightBtnHandlers[col].ToggleLight();

        if (col > 0)
        {
            lightGrid[1].GetLightBtnHandlers[col - 1].ToggleLight();
        }

        if (col < 4)
        {
            lightGrid[1].GetLightBtnHandlers[col + 1].ToggleLight();
        }

        // Force check whether all lights are off
        CheckForVictory();

        // Play button click audioclip/SFX
        AudioHandler.Instance.PlayLightToggleBtnClickSFX();
    }

    public void OnClick_ToggleLightBtn_Row_3(int col)
    {
        // Toggle button function for row - 3 of the grid
        lightGrid[2].GetLightBtnHandlers[col].ToggleLight();
        lightGrid[2 - 1].GetLightBtnHandlers[col].ToggleLight();
        lightGrid[2 + 1].GetLightBtnHandlers[col].ToggleLight();

        if (col > 0)
        {
            lightGrid[2].GetLightBtnHandlers[col - 1].ToggleLight();
        }

        if (col < 4)
        {
            lightGrid[2].GetLightBtnHandlers[col + 1].ToggleLight();
        }

        // Force check whether all lights are off
        CheckForVictory();

        // Play button click audioclip/SFX
        AudioHandler.Instance.PlayLightToggleBtnClickSFX();
    }

    public void OnClick_ToggleLightBtn_Row_4(int col)
    {
        // Toggle button function for row - 4 of the grid
        lightGrid[3].GetLightBtnHandlers[col].ToggleLight();
        lightGrid[3 - 1].GetLightBtnHandlers[col].ToggleLight();
        lightGrid[3 + 1].GetLightBtnHandlers[col].ToggleLight();

        if (col > 0)
        {
            lightGrid[3].GetLightBtnHandlers[col - 1].ToggleLight();
        }

        if (col < 4)
        {
            lightGrid[3].GetLightBtnHandlers[col + 1].ToggleLight();
        }

        // Force check whether all lights are off
        CheckForVictory();

        // Play button click audioclip/SFX
        AudioHandler.Instance.PlayLightToggleBtnClickSFX();
    }

    public void OnClick_ToggleLightBtn_Row_5(int col)
    {
        // Toggle button function for row - 5 of the grid
        lightGrid[4].GetLightBtnHandlers[col].ToggleLight();
        lightGrid[4 - 1].GetLightBtnHandlers[col].ToggleLight();

        if (col > 0)
        {
            lightGrid[4].GetLightBtnHandlers[col - 1].ToggleLight();
        }

        if (col < 4)
        {
            lightGrid[4].GetLightBtnHandlers[col + 1].ToggleLight();
        }

        // Force check whether all lights are off
        CheckForVictory();

        // Play button click audioclip/SFX
        AudioHandler.Instance.PlayLightToggleBtnClickSFX();
    }
    #endregion

    #region Public Core Functions
    public void UpdateGameTimerTMP(string txt)
    {
        // Update game timer txt on UI
        gameTimerTMP.SetText(txt);
    }

    public void InitialSetup()
    {
        // Initial random grid pattern or puzzle to solve
        Grid grid = gridPatterns.GetRandomGridPattern();
        for (int i = 0; i < lightGrid.Count; i++)
        {
            for (int j = 0; j < lightGrid[i].GetLightBtnHandlers.Count; j++)
            {
                if (grid.GetGridRowPatterns[i].GetGridLightsStatus[j].IsLightOn)
                {
                    lightGrid[i].GetLightBtnHandlers[j].UpdateLightStatus(LightStatus.On);
                }
                else
                {
                    lightGrid[i].GetLightBtnHandlers[j].UpdateLightStatus(LightStatus.Off);
                }
            }
        }

        if (GameManager.Instance.ForceRandomizeGrid)
        {
            // Force randomize grid pattern
            OnClick_ToggleLightBtn_Row_1(Random.Range(0, 5));
            OnClick_ToggleLightBtn_Row_2(Random.Range(0, 5));
            OnClick_ToggleLightBtn_Row_3(Random.Range(0, 5));
            OnClick_ToggleLightBtn_Row_4(Random.Range(0, 5));
            OnClick_ToggleLightBtn_Row_5(Random.Range(0, 5));
        }

        // Turn on interaction with the grid buttons
        ActivateGridBtns(true);

        // Reset move counter
        GameManager.Instance.MoveCounter = 0;
        // Reset move counter on UI
        playerMoveCounterTMP.SetText(GameManager.Instance.MoveCounter.ToString());
        
        // Activate game timer
        GameManager.Instance.ActivateGameTimer(true);
    }

    public void ActivateGridBtns(bool value)
    {
        // Activate or deactivate all grid buttons
        for (int i = 0; i < lightGrid.Count; i++)
        {
            for (int j = 0; j < lightGrid[i].GetLightBtnHandlers.Count; j++)
            {
                lightGrid[i].GetLightBtnHandlers[j].ActivateBtn(value);
            }
        }
    }
    #endregion
}