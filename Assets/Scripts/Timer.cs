using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public event Action TimeChanged;

    [SerializeField] private Button _button;

    private float _delay = 0.5f;
    private float _timeToAdd = 1f;
    private bool _isTimerGoing = false;
    private WaitForSecondsRealtime _wait;

    [HideInInspector] public float CurrentTime { get; private set; } = 0f;

    private void Start()
    {
        _wait = new WaitForSecondsRealtime(_delay);
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button?.onClick.AddListener(HandleClick);
    }

    private void OnDisable()
    {
        _button?.onClick.RemoveListener(HandleClick);
    }

    public void HandleClick()
    {
        if (_isTimerGoing)
        {
            ChangeTimerStatementToStop();
            StopCoroutine(IncreaseTime());
        }
        else
        {
            ChangeTimerStatementToStart();
            StartCoroutine(IncreaseTime());
        }
    }

    private IEnumerator IncreaseTime()
    {
        while (_isTimerGoing)
        {
            CurrentTime += _timeToAdd;
            TimeChanged?.Invoke();

            yield return _wait;
        }
    }

    private void ChangeTimerStatementToStop()
    {
        _isTimerGoing = false;
    }

    private void ChangeTimerStatementToStart()
    {
        _isTimerGoing = true;
    }
}