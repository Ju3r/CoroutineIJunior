using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.TimeChanged += ChangeTime;
    }

    private void OnDisable()
    {
        _timer.TimeChanged -= ChangeTime;
    }

    private void ChangeTime()
    {
        _timerText.text = _timer.CurrentTime.ToString();
    }
}