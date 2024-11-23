using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class homework : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _coroutine;
    private bool _onTimer = false;
    private int _counter = 0;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_onTimer == false || _coroutine == null)
            {
                _coroutine = StartCoroutine(Countdown(0.5f));
                _onTimer = true;
            }
            else
            {
                StopCoroutine(_coroutine);
                _onTimer = false;
            }
        }
    }

    private IEnumerator Countdown(float delay, int start = 10)
    {
        var wait = new WaitForSeconds(delay);

        while(true)
        {
            _counter++;
            DisplayCountdown(_counter);
            yield return wait;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }
}
