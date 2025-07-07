using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource[] _soundEffects;

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
    }

    public void PlaySound(int index)
    {
        if (_soundEffects == null || index < 0 || index >= _soundEffects.Length)
            return;

        if (_toggleMuter == null || !_toggleMuter.IsMuted())
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
