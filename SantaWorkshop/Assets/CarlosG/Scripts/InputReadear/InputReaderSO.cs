using System;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "PlayerInputs")]

public class InputReaderSO : ScriptableObject, PlayerInputs.IPlayerActionsActions, PlayerInputs.IPlayerCameraActions
{
    private PlayerInputs _inputs;
    #region Delegates
    public event Action<Vector2> MoveEvent;
    public event Action OnInteractEvent;

    public event Action<float> OnRotateEvent;
    public event Action<Vector2> OnZoomEvent;

    #endregion
    private void OnEnable()
    {
        if (_inputs == null)
        {
            _inputs = new PlayerInputs();
            _inputs.PlayerActions.SetCallbacks(this);
            _inputs.PlayerCamera.SetCallbacks(this);
        }
    }
    #region Inputs Call Backs
    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            OnInteractEvent?.Invoke();
    }
    #endregion
    #region Inputs Enables
    public void EnablePlayerActions()
    {
        _inputs.PlayerActions.Enable();
        _inputs.PlayerCamera.Enable();
    }
    public void DisablePlayerActions()
    {
        _inputs.PlayerActions.Disable();
		_inputs.PlayerCamera.Disable();
	}

	public void OnRotateLeft(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			OnRotateEvent?.Invoke(-1.0f);
		else
			OnRotateEvent?.Invoke(0.0f);
	}

	public void OnRotateRight(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			OnRotateEvent?.Invoke(1.0f);
		else
			OnRotateEvent?.Invoke(0.0f);
	}

    public void OnZoom(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			OnZoomEvent?.Invoke(context.ReadValue<Vector2>());
	}

	#endregion
}
