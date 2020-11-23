using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider))]
public class AbilityBreakWall : MonoBehaviour
{
    [SerializeField] private CharacterInput _characterInput;
    [SerializeField] private CellPool _cellPool;
    [SerializeField] private Animator _characterMovementAnimator;
    [SerializeField] private Collider _characterCollider;
    [SerializeField, Range(0, 30)] private float _delayTime;

    private bool _canLeapForward;

    public float CurrentTime { get; private set; }

    public float DelayTime => _delayTime;

    private void Start()
    {
        CurrentTime = _delayTime;
    }

    private void Update()
    {
        if ((IsRechargeComplete() == true) && (_canLeapForward == true))
        {
            Use();
        }
    }

    private bool IsRechargeComplete()
    {
        CurrentTime += Time.deltaTime;

        if (CurrentTime >= _delayTime)
        {
            return true;
        }

        return false;
    }

    private void Use()
    {
        _canLeapForward = false;
        CurrentTime = 0;

        ToSwitch(true);
    }

    private void OnDisableAbility()
    {
        ToSwitch(false);
    }

    private void ToSwitch(bool enable)
    {
        _characterMovementAnimator.SetBool("WallBreak", enable);
        _characterCollider.enabled = enable;
    }

    private void DestroyWall(Transform wall)
    {
        _cellPool.Enqueue(wall);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Wall wall))
        {
            DestroyWall(wall.transform);
        }
    }

    private void OnEnable()
    {
        _characterInput.RushedForward += () => _canLeapForward = CurrentTime > _delayTime ? true : false;
    }
}