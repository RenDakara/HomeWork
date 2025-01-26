using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _increaseDuration = 2f;
    [SerializeField] private float _decreaseDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            StartCoroutine(IncreaseVolume());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            StartCoroutine(DecreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        _alarmSound.volume = 0;
        _alarmSound.Play();

        float elapsedTime = 0f;

        while (elapsedTime < _increaseDuration)
        {
            _alarmSound.volume = Mathf.Lerp(0, _maxVolume, elapsedTime / _increaseDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _alarmSound.volume = _maxVolume;
    }

    private IEnumerator DecreaseVolume()
    {
        float elapsedTime = 0f;
        float initialVolume = _alarmSound.volume;

        while (elapsedTime < _decreaseDuration)
        {
            _alarmSound.volume = Mathf.Lerp(initialVolume, 0, elapsedTime / _decreaseDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _alarmSound.volume = 0;
        _alarmSound.Stop();
    }
}
