using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GlobalAcceleration _globalAcceleration;
    [SerializeField, Min(0)] private float _speed;

    private void Update()
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
    }


    private void OnEnable()
    {
        _globalAcceleration.StepAccelerated += (stepAcceleration) => { _speed += stepAcceleration; };
    }
}