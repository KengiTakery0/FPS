using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    PlayerInput input;
    PlayerInput.OnFootActions onFootActions;

    Player _player;

    private void Awake()
    { 
        input = new PlayerInput();
        onFootActions = input.OnFoot;
        _player = GetComponent<Player>();
    }


    private void FixedUpdate()
    {
        _player.Move(onFootActions.Move.ReadValue<Vector2>());
    }


    #region ENABLE/Diable
    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
    #endregion
}
