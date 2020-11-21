using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider))]
public class AbilityBreakWall : MonoBehaviour
{
    [SerializeField] private CellPool _cellPool;
    [SerializeField] private Animator _characterMovementAnimator;
    [SerializeField] private Collider _characterCollider;
    [SerializeField, Range(0, 30)] private float _delayTime;

    private float _currentTime = 0;

    private void Start()
    {
        _currentTime = _delayTime;
    }

    private void Update()
    {
        if ((CanUse() == true) && (Input.GetKeyDown(KeyCode.Space)))
        {
            Use();
        }
    }

    private bool CanUse()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _delayTime)
        {
            return true;
        }

        return false;
    }

    private void Use()
    {
        _currentTime = 0;
        Enable(true);
    }

    private void OnDisableAbility()
    {
        Enable(false);
    }

    private void Enable(bool enable)
    {
        _characterMovementAnimator.SetBool("WallBreak", enable);
        _characterCollider.enabled = enable;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Wall wall))
        {
            DestroyWall(wall);
        }
    }

    private void DestroyWall(Wall wall)
    {
        _cellPool.Enqueue(wall.transform);
    }
}