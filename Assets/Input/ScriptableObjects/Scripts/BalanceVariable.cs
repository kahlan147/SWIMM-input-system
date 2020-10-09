using System;
using UnityEngine;
using UnityEngine.Events;

public enum Balance { LeanLeft, InBalance, LeanRight }

public class BalanceEvent : UnityEvent<Balance> { } 

[CreateAssetMenu(fileName = "BalanceVariable", menuName = "DataParsers/BalanceVariable", order = 1)]
public class BalanceVariable : ScriptableObject
{

    #region Variables
    [SerializeField]
    private Balance InitialValue;

    [NonSerialized]
    public Balance RuntimeValue;

    public BalanceEvent OnChange = new BalanceEvent();
    #endregion

    #region Event Methods
    public void ChangeValue(Balance newValue)
    {
        RuntimeValue = newValue;
        if (OnChange != null)
        {
            OnChange.Invoke(RuntimeValue);
        }
    }

    public void AddListener(UnityAction<Balance> action)
    {
        OnChange.AddListener(action);
    }

    public void RemoveListener(UnityAction<Balance> action)
    {
        OnChange.RemoveListener(action);
    }
    #endregion

    #region Serialization
    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }
    #endregion
}
