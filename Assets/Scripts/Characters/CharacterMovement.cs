using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private GlobalAcceleration _globalAcceleration;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _rotationSpeed;

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
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
    }

    private void Move()
    {
        _characterController.Move(transform.forward *_forwardSpeed * Time.deltaTime);
    }

    private void OnSetSpeedMove(float speed)
    {
        _forwardSpeed += speed;
    }

    private void OnEnable()
    {
        _globalAcceleration.StepAccelerated += (stepAcceleration) => OnSetSpeedMove(stepAcceleration);
    }
}