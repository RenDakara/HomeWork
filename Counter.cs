using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _coroutine;
    private bool _isOnTimer = false;
    private int _counter = 0;
    public event Action<int> CounterView;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_isOnTimer == false || _coroutine == null)
            {
                _coroutine = StartCoroutine(Countdown(0.5f));
                _isOnTimer = true;                
            }
            else
            {
                StopCoroutine(_coroutine);
                _isOnTimer = false;
            }
        }
    }

    public IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            _counter++;
            CounterView?.Invoke(_counter);
            yield return wait;
        }
    }
}
