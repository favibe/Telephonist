using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    public int MaxCharge
    {
        get => _maxCharge;
        set
        {
            _maxCharge = value;
            Recharge();
        }
    }

    public float ChargeLossSpeed
    {
        get => _chargeLossSpeed;
        set
        {
            _chargeLossSpeed = value;
            RestartTimer();
        }
    }

    public int CurrentCharge
    {
        get => _curCharge;
        set => SetCharge(value);
    }

    private void FixedUpdate()
    {
        if (_curCharge == 0)
            return;

        if (_timer > 0)
        {
            _timer -= Time.fixedDeltaTime;
        }
        else if (_timer <= 0)
        {
            SetCharge(_curCharge - 1);
            ChargeChanged.Invoke(_curCharge);
            RestartTimer();
        }
    }

    private void Awake()
    {
        SetCharge(_maxCharge);
        RestartTimer();
    }
    public void SetCharge(int value)
    {
        if (value > _maxCharge)
        {
            value = _maxCharge;
        }

        _curCharge = value;
        float width = Mathf.Ceil((_curCharge /(float) _maxCharge) * 10);

        var size = new Vector2(width, _chargeRect.sizeDelta.y);
        _chargeRect.sizeDelta = size;

        if (value == 0)
            FullyDischarged.Invoke();
    }

    private void RestartTimer()
    {
        _timer = 1 / _chargeLossSpeed;
    }

    public void Recharge()
    {
        _curCharge = _maxCharge;
        RestartTimer();
    }

    [SerializeField]
    private RectTransform _chargeRect;

    [Header("Energy amount")]
    [SerializeField]
    private int _maxCharge;
    [SerializeField]
    private int _curCharge;

    [Header("Charge parameters")]
    [SerializeField]
    private float _chargeLossSpeed = 1f;

    private float _timer;
    [Space]
    public UnityEvent<int> ChargeChanged;
    public UnityEvent FullyDischarged;
}
