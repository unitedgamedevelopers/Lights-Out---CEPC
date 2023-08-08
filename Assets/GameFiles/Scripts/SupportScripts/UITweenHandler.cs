using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenHandler : MonoBehaviour
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float tweenTime = 0f;
    [SerializeField] private float scaleUpMultiplier = 0f;
    [SerializeField] private float targetScale = 0f;
    #endregion

    #region MonoBehaviour Functions
    private void OnEnable()
    {
        Tween();
    }
    #endregion

    #region Public Core Functions
    //Tween ui on call
    public void Tween()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one * targetScale;

        LeanTween.scale(gameObject, transform.localScale * scaleUpMultiplier, tweenTime).setEasePunch();
    }
    #endregion
}
