using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName ="PlayerInputs")]
public class InputReaderSO : ScriptableObject, PlayerInputs.IPlayerActionsActions
{
    private PlayerInputs _inputs;
    #region Delegates
    public event Action<Vector2> MoveEvent;
    #endregion
    private void OnEnable()
    {
        if(_inputs==null)
        {
            _inputs= new PlayerInputs();
            _inputs.PlayerActions.SetCallbacks(this);
        }
    }
    #region Inputs Call Backs
    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }
    #endregion
    #region Inputs Enables
    public void EnablePlayerActions()
    {
        _inputs.PlayerActions.Enable();
    }
    public void DisablePlayerActions()
    {
        _inputs.PlayerActions.Disable();
    }
    #endregion
}
