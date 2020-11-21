using UnityEngine;

public class GlobalAcceleration : MonoBehaviour
{
    [SerializeField] private float _secondsUntilNextAcceleration;
    [SerializeField, Min(0)] private float _stepAcceleration;

    private float _currnetTime;

    public event System.Action<float> StepAccelerated;

    private void Update()
    {
        _currnetTime += Time.deltaTime;

        if (_currnetTime >= _secondsUntilNextAcceleration)
        {
            SpeedUpStep();
        }
    }

    private void SpeedUpStep()
    {
        StepAccelerated?.Invoke(_stepAcceleration);

        _currnetTime = 0;
    }
}