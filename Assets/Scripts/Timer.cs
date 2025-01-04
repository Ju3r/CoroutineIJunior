using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action TimeChanged;

    private float _delay = 0.5f;
    private float _timeToAdd = 1f;
    private bool _isTimerGoing = false;
    private WaitForSecondsRealtime _wait;

    [HideInInspector] public float CurrentTime { get; private set; } = 0f;

    private IEnumerator IncreaseTime()
    {
        while (_isTimerGoing)
        {
            CurrentTime += _timeToAdd;
            TimeChanged?.Invoke();
            yield return _wait;
        }
    }

    private void Start()
    {
        _wait = new WaitForSecondsRealtime(_delay);
    }

    public void HandleClick()
    {
        ChangeTimerStatement();

        if (_isTimerGoing)
        {
            StartCoroutine(IncreaseTime());
        }
        else
        {
            StopCoroutine(IncreaseTime());
        }
    }

    private void ChangeTimerStatement()
    {
        _isTimerGoing = !_isTimerGoing;
    }
}