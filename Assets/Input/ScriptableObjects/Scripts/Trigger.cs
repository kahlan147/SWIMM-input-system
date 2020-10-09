using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Trigger", menuName = "DataParsers/Trigger", order = 1)]
public class Trigger : ScriptableObject
{
    #region Variables
    [HideInInspector] public UnityEvent OnChange = new UnityEvent();
    #endregion

    #region Event Methods
    public void Invoke()
    {
        OnChange.Invoke();
    }

    public void AddListener(UnityAction action)
    {
        OnChange.AddListener(action);
    }

    public void RemoveListener(UnityAction action)
    {
        OnChange.RemoveListener(action);
    }
    #endregion
}
