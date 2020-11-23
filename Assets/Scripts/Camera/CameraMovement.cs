using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GlobalAcceleration _globalAcceleration;
    [SerializeField, Min(0)] private float _speed;
    [SerializeField] Camera _camera;
    [SerializeField] private Vector2 _defaultResolution;

    private void Start()
    {
        SetFieldOfView();
    }

    // Не смог рассчитать постоянную ширину для разных разрешений.
    // Подсмотрено https://gist.github.com/Glavak/ada99b57023db3c941c5caebe42a70c5.
    private void SetFieldOfView()
    {
        float targetAspect = _defaultResolution.x / _defaultResolution.y;
        float initialFov = _camera.fieldOfView;
        float horizontalFov = CalcVerticalFov(initialFov, 1 / targetAspect);
        float constantWidthFov = CalcVerticalFov(horizontalFov, _camera.aspect);

        _camera.fieldOfView = constantWidthFov;
    }

    private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        var hFovInRads = hFovInDeg * Mathf.Deg2Rad;
        var vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);

        return vFovInRads * Mathf.Rad2Deg;
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        _globalAcceleration.StepAccelerated += (stepAcceleration) => { _speed += stepAcceleration; };
    }
}