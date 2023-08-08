using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Properties
    public static GameManager Instance = null;

    //Game timer attributes
    private int minutes = 0;
    private float seconds = 0;

    //Components Reference
    private CoreGameplayHandler coreGameplayHandler = null;
    #endregion

    #region Delegate
    private delegate void UpdateCore();

    private UpdateCore updateCore = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        // Get reference of CoreGameplayHandler component
        coreGameplayHandler = UIManager.Instance.GetCoreGameplayHandler;

        // Deactiavte gametimer at start of the new game until player starts the game
        ActivateGameTimer(false);

        // Setup user level
        PlayerLocalDataSetup();
    }

    private void Update()
    {
        // Delegate to run multiple functions in an update function
        if (updateCore != null)
        {
            updateCore();
        }
    }
    #endregion

    #region Getter And Setter
    // Move counter variable
    public int MoveCounter { get; set; }

    // Randomize grid boolean
    public bool ForceRandomizeGrid { get; set; }
    #endregion

    #region Private Core Functions
    private void PlayerLocalDataSetup()
    {
        if (!PlayerPrefs.HasKey("UserLevel"))
        {
            PlayerPrefs.SetInt("UserLevel", 0);
        }
        else if (PlayerPrefs.GetInt("UserLevel") > 3)
        {
            ForceRandomizeGrid = true;
        }
    }

    private void GameTimer()
    {
        // Game timer core mechanism
        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }
        else
        {
            seconds += Time.deltaTime;
        }

        // Game timer string formatting "MM:SS"
        coreGameplayHandler.UpdateGameTimerTMP(minutes.ToString("00") + ":" + ((int)seconds).ToString("00"));
    }

    private void ResetGameTimer()
    {
        //Reset game timer variables

        minutes = 0;
        seconds = 0;
    }
    #endregion

    #region Public Core Functions
    public void ActivateGameTimer(bool value)
    {
        // Activate or deactivate game timer

        if (value)
        {
            ResetGameTimer();
            updateCore += GameTimer;
        }
        else
        {
            print("Called!");
            updateCore -= GameTimer;
        }
    }
    #endregion
}
