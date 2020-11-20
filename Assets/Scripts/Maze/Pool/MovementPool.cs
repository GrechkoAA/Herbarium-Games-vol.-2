using UnityEngine;

public class MovementPool : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private float offsetPosition;

    private void Start()
    {
        offsetPosition = _camera.position.z;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, _camera.position.z - offsetPosition);
    }
}