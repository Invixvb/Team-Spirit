using UnityEngine;

public class TimerWarning : MonoBehaviour
{
    private float _timeLeft;
    private bool _gameStarted, _gameIsOver;

    private float _timeAmount;

    private void Start()
    {
        _timeLeft = _timeAmount;
    }

    private void Update()
    {
        if (_gameStarted && !_gameIsOver)
        {
            _timeLeft -= 1 * Time.deltaTime;
        }

        if (_timeLeft <= 0)
        {
            
        }
    }
}
