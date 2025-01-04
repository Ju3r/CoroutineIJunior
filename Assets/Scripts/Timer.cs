using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action TimeChanged;

    [SerializeField] private Input _input;

    private float _delay = 0.5f;
    private float _timeToAdd = 1f;
    private bool _isTimerGoing = false;
    private WaitForSecondsRealtime _wait;

    [HideInInspector] public float CurrentTime { get; private set; } = 0f;

    private IEnumerator IncreaseTime()
    {
        while(_isTimerGoing)
        {
            CurrentTime += _timeToAdd;
            TimeChanged?.Invoke();
            yield return _wait;
        }
    }

    private void OnEnable()
    {
        _input.ButtonClicked += StartStopCoroutine;
    }

    private void OnDisable()
    {
        _input.ButtonClicked -= StartStopCoroutine;
    }

    private void Start()
    {
        _wait = new WaitForSecondsRealtime(_delay);
    }

    private void StartStopCoroutine()
    {
        _isTimerGoing = !_isTimerGoing;

        if (_isTimerGoing)
        {
            StartCoroutine(IncreaseTime());
        }
        else
        {
            StopCoroutine(IncreaseTime());
        }
    }
}