using System;
using UnityEngine;
using UnityEngine.Events;

//Special event that sends a Vector3 on invocation.
public class Vector3Event : UnityEvent<Vector3>{ }

[CreateAssetMenu(fileName = "Vector3Variable", menuName = "DataParsers/Vector3Variable", order = 1)]
public class Vector3Variable : ScriptableObject, ISerializationCallbackReceiver
{
    #region Variables
    /// <summary>
    /// The initial value for this SO.
    /// </summary>
    [SerializeField] private Vector3 InitialValue;
    
    /// <summary>
    /// The current value for this SO.
    /// </summary>
    [NonSerialized] public Vector3 RuntimeValue;

    /// <summary>
    /// Event that is called whenever the runtime value is changed.
    /// </summary>
    [HideInInspector] public Vector3Event OnChange = new Vector3Event();
    #endregion

    #region Event Methods
    /// <summary>
    /// Lets the SO know the value has changed.
    /// </summary>
    /// <param name="newValue">The new value for the SO to let all it's listeners know. </param>
    public void ChangeValue(Vector3 newValue)
    {
        RuntimeValue = newValue;
        if (OnChange != null)
        {
            OnChange.Invoke(RuntimeValue);
        }
    }

    /// <summary>
    /// Adds a listener to this SO's event.
    /// </summary>
    /// <param name="action">Function to call on invoking the SO's event.</param>
    public void AddListener(UnityAction<Vector3> action)
    {
        OnChange.AddListener(action);
    }

    /// <summary>
    /// Removes a listener from this SO's event.
    /// </summary>
    /// <param name="action">Previous used function used by AddListener.</param>
    public void RemoveListener(UnityAction<Vector3> action)
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
