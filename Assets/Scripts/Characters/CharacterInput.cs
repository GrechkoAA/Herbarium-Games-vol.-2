using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action<bool> TurnedLeft;
    public event Action<bool> TurnedRight;
    public event Action RushedForward;

    private float _interval = 0.2f;
    private float _doubleClickTime;
    private int _clickCount;

    public void OnPointerDown(PointerEventData eventData)
    {
        DoubleClick();

        if (eventData.position.x > Screen.width / 2)
        {
            TurnedLeft?.Invoke(true);
        }

        if(eventData.position.x < Screen.width / 2)
        {
            TurnedRight?.Invoke(true);
        }
    }

    private void DoubleClick()
    {
        _clickCount++;

        if (HitInterval() == true)
        {
            RushedForward?.Invoke();

            _clickCount = 0;

            return;
        }

        _doubleClickTime = Time.time;

        if (_clickCount > 1)
        {
            _clickCount = 0;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TurnedLeft?.Invoke(false);
        TurnedRight?.Invoke(false);
    }

    private bool HitInterval()
    {
        return _clickCount > 1 && _doubleClickTime + _interval > Time.time;
    }
}