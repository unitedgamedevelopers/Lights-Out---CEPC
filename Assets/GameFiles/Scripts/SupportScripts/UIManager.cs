using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Properties
    public static UIManager Instance = null;

    [Header("UI Panel Reference")]
    [SerializeField] private GameObject mainMenuUIElementsHolderObj = null;
    [SerializeField] private GameObject gameOverUIElementsHolderObj = null;

    [Header("Components Reference")]
    [SerializeField] private CoreGameplayHandler coreGameplayHandler = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        // Singleton setup for UIManager Component
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        // Display main menu screen
        LoadMainMenu();
    }
    #endregion

    #region Getter And Setter
    public CoreGameplayHandler GetCoreGameplayHandler { get => coreGameplayHandler; }
    #endregion

    #region Private Core Functions
    #endregion

    #region Btn Events Functions
    public void OnClick_StartNewGameBtn()
    {
        // Initial game setup called when user press StartNewGame button
        coreGameplayHandler.InitialSetup();

        // Play button click audioclip/SFX
        AudioHandler.Instance.PlayUIBtnClickSFX();
    }

    public void OnClick_QuitBtn()
    {
        Application.Quit();
    }

    public void OnClick_RestartBtn()
    {
        // Restart the whole game when user press PlayAgain button
        SceneManager.LoadScene(0);

        // Play button click audioclip/SFX
        AudioHandler.Instance.PlayUIBtnClickSFX();
    }
    #endregion

    #region Public Core Functions
    public void LoadMainMenu()
    {
        // Main menu setup
        mainMenuUIElementsHolderObj.SetActive(true);
        gameOverUIElementsHolderObj.SetActive(false);
        coreGameplayHandler.ActivateGridBtns(false);
    }

    public void DisplayGameOverUIElements()
    {
        // Game over screen setup
        mainMenuUIElementsHolderObj.SetActive(false);
        gameOverUIElementsHolderObj.SetActive(true);
        coreGameplayHandler.ActivateGridBtns(false);
    }
    #endregion
}
