using System.Collections;
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
        float initialVolume = _alarmSound.volume;
        float targetVolume = 1f;

        while (elapsedTime < _increaseDuration)
        {
            float maxVolumeChange = (targetVolume - initialVolume) * (Time.deltaTime / _increaseDuration);
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, maxVolumeChange);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _alarmSound.volume = _maxVolume;
    }

    private IEnumerator DecreaseVolume()
    {
        float elapsedTime = 0f;
        float initialVolume = _alarmSound.volume;
        float targetVolume = 0f;

        while (elapsedTime < _decreaseDuration)
        {
            float maxVolumeChange = (initialVolume - targetVolume) * (Time.deltaTime / _decreaseDuration);
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, maxVolumeChange);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _alarmSound.volume = 0;
        _alarmSound.Stop();
    }
}
