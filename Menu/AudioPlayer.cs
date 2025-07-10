using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource[] _soundEffects;
    [SerializeField] private UnityEngine.UI.Button _playButton1;
    [SerializeField] private UnityEngine.UI.Button _playButton2;
    [SerializeField] private UnityEngine.UI.Button _playButton3;

    private ToggleMuter _toggleMuter;
    private VolumeChanger _volumeChanger;

    private void Start()
    {
        _toggleMuter = GetComponent<ToggleMuter>();
        _volumeChanger = GetComponent<VolumeChanger>();

        if (_toggleMuter != null)
        {
            _toggleMuter.OnMuteToggle += HandleMuteToggle;
        }

        if (_playButton1 != null) _playButton1.onClick.AddListener(() => PlaySound(0));
        if (_playButton2 != null) _playButton2.onClick.AddListener(() => PlaySound(1));
        if (_playButton3 != null) _playButton3.onClick.AddListener(() => PlaySound(2));
    }

    private void PlaySound(int index)
    {
        if (_soundEffects == null || index < 0 || index >= _soundEffects.Length)
            return;

        if (_toggleMuter == null || !_toggleMuter.isMuted)
        {
            StopAllSounds();
            _soundEffects[index].Play();
        }
    }

    private void OnDestroy()
    {
        if (_toggleMuter != null)
        {
            _toggleMuter.OnMuteToggle -= HandleMuteToggle;
        }

        if (_playButton1 != null)
            _playButton1.onClick.RemoveListener(() => PlaySound(0));
        if (_playButton2 != null)
            _playButton2.onClick.RemoveListener(() => PlaySound(1));
        if (_playButton3 != null)
            _playButton3.onClick.RemoveListener(() => PlaySound(2));
    }

    private void StopAllSounds()
    {
        foreach (var sound in _soundEffects)
        {
            sound.Stop();
        }
    }

    private void HandleMuteToggle(bool isMuted)
    {
        foreach (var sound in _soundEffects)
        {
            if (isMuted)
            {
                sound.Pause();
            }
            else
            {
                if (!sound.isPlaying)
                    sound.UnPause();
            }
        }
    }
}
