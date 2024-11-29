using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _coroutine;
    private int _number = 0;
    private float _interval = 0.5f;
    public event Action<int> CounterViewing;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_coroutine == null)
            {
                _coroutine = StartCoroutine(Countdown(_interval));               
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    public IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            _number++;
            CounterViewing?.Invoke(_number);
            yield return wait;
        }
    }
}
