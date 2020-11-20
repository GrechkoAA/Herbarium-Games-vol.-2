using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField, Min(0)] private float _speed;

    private void Update()
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
    }
}