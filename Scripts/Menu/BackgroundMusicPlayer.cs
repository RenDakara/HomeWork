using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusicSource;

    private bool _isMuted;

    public void Play(AudioClip clip)
    {
        if (clip != null)
        {
            _backgroundMusicSource.clip = clip;
            _backgroundMusicSource.Play();
        }
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;
        _backgroundMusicSource.mute = _isMuted;
    }

    public void SetVolume(float volume)
    {
        if (_backgroundMusicSource != null)
            _backgroundMusicSource.volume = volume;
    }
}