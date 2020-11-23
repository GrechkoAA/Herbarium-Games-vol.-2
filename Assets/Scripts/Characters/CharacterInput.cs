using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _doubleClickInterval;

    private float _previousClickTime;
    private int _clickCount;

    public event System.Action<bool> TurnedLeft;
    public event System.Action<bool> TurnedRight;
    public event System.Action RushedForward;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (IsHitInterval() == true)
        {
            DoubleClick();

            return;
        }

        if (eventData.position.x > Screen.width / 2)
        {
            TurnedLeft?.Invoke(true);
        }

        if (eventData.position.x < Screen.width / 2)
        {
            TurnedRight?.Invoke(true);
        }

        _previousClickTime = Time.time;
    }

    private bool IsHitInterval()
    {
        return _clickCount++ > 1 && _previousClickTime + _doubleClickInterval > Time.time;
    }

    private void DoubleClick()
    {
        RushedForward?.Invoke();

        _clickCount = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TurnedLeft?.Invoke(false);
        TurnedRight?.Invoke(false);
    }  
}