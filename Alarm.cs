using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _increaseDuration = 2f;
    [SerializeField] private float _decreaseDuration = 2f;
    private Coroutine _coroutine;

    public void TriggerAlarm()
    {
        StartChangingVolume(_maxVolume, _increaseDuration);
    }

    public void StopAlarm()
    {
        StartChangingVolume(0, _decreaseDuration);
    }

    private void StartChangingVolume(float targetVolume, float duration)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(ChangeVolume(targetVolume, duration));
    }

    private IEnumerator ChangeVolume(float targetVolume, float duration)
    {
        float elapsedTime = 0f;
        float initialVolume = _alarmSound.volume;

        if (targetVolume > 0)
        {
            _alarmSound.volume = 0;
            _alarmSound.Play();
        }

        while (elapsedTime < duration)
        {
            float maxVolumeChange = Mathf.Abs(targetVolume - initialVolume) * (Time.deltaTime / _increaseDuration);
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, maxVolumeChange);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _alarmSound.volume = targetVolume;

        if (targetVolume == 0)
            _alarmSound.Stop();
    }
}
