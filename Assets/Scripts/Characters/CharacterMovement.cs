using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterInput _characterInput;
    [SerializeField] private GlobalAcceleration _globalAcceleration;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _rotationSpeed;

    private bool _canLeftTurn = false;
    private bool _canRightTurn = false;

    private void Update()
    {
        Turn();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Turn()
    {
        transform.Rotate(0, GetAxisRaw() * _rotationSpeed * Time.deltaTime, 0);
    }

    private float GetAxisRaw()
    {
        int axis = 0;

        if (_canLeftTurn && _canRightTurn)
        {
            axis = 0;
        }
        else if (_canRightTurn)
        {
            axis = -1;
        }
        else if (_canLeftTurn)
        {
            axis = 1;
        }

        return axis;
    }

    private void Move()
    {
        _characterController.Move(transform.forward * _forwardSpeed * Time.deltaTime);
    }

    private void OnSetSpeedMove(float speed)
    {
        _forwardSpeed += speed;
    }

    private void OnEnable()
    {
        _globalAcceleration.StepAccelerated += (stepAcceleration) => OnSetSpeedMove(stepAcceleration);
        _characterInput.TurnedLeft += (turnAllowed) => _canLeftTurn = turnAllowed;
        _characterInput.TurnedRight += (turnAllowed) => _canRightTurn = turnAllowed;
    }
}