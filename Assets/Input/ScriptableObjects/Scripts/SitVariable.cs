using System;
using UnityEngine;
using UnityEngine.Events;

public enum SitState { Sitting, Standing }

public class SitStateEvent : UnityEvent<SitState> { }

[CreateAssetMenu(fileName = "SitStateVariable", menuName = "DataParsers/SitStateVariable", order = 1)]

public class SitVariable : ScriptableObject
{
    #region Variables
    [SerializeField]
    private SitState InitialValue;

    [NonSerialized]
    public SitState RuntimeValue;

    public SitStateEvent OnChange = new SitStateEvent();
    #endregion

    #region Event Methods
    public void ChangeValue(SitState newValue)
    {
        RuntimeValue = newValue;
        if (OnChange != null)
        {
            OnChange.Invoke(RuntimeValue);
        }
    }

    public void AddListener(UnityAction<SitState> action)
    {
        OnChange.AddListener(action);
    }

    public void RemoveListener(UnityAction<SitState> action)
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
