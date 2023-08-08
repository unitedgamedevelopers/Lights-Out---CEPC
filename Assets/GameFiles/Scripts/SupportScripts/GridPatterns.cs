using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to store initial grid patterns and get any random one to solve

[System.Serializable]
public class GridLightStatus
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private bool isLightOn = false;
    #endregion

    #region Getter And Setter
    public bool IsLightOn { get => isLightOn; }
    #endregion
}

[System.Serializable]
public class GridRowPattern
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private List<GridLightStatus> gridLightsStatus = new List<GridLightStatus>();
    #endregion

    #region Getter And Setter
    public List<GridLightStatus> GetGridLightsStatus { get => gridLightsStatus; }
    #endregion
}

[System.Serializable]
public class Grid
{
    #region Properties
    [Header("GridRowPatterns")]
    [SerializeField] private List<GridRowPattern> gridRowPatterns = new List<GridRowPattern>(); 
    #endregion

    #region Getter And Setter
    public List<GridRowPattern> GetGridRowPatterns { get => gridRowPatterns; }
    #endregion
}

[CreateAssetMenu(fileName = "GridPatterns", menuName = "ScriptableObjects/GridPatterns")]
public class GridPatterns : ScriptableObject
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private List<Grid> pattern = new List<Grid>();
    #endregion

    #region MonoBehaviour Functions
    #endregion

    #region Public Core Functions
    public Grid GetRandomGridPattern()
    {
        // Get random grid pattern to solve
        return pattern[Random.Range(0, pattern.Count)];
    }
    #endregion
}
