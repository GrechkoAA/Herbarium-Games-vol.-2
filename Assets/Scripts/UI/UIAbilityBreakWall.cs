using UnityEngine;

public class UIAbilityBreakWall : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _breakWall;
    [SerializeField] private AbilityBreakWall _abilityBreakWall;

    private void Update()
    {
        _breakWall.fillAmount = _abilityBreakWall.CurrentTime / _abilityBreakWall.DelayTime;
    }
}