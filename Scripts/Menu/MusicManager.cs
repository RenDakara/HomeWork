using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private AudioSource[] _trackSources;
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private Slider _overallVolumeSlider;
    [SerializeField] private Slider _backgroundVolumeSlider;
    [SerializeField] private Slider[] _trackVolumeSliders;

    private bool _isMuted;

    private void OnEnable()
    {
        _overallVolumeSlider.onValueChanged.AddListener(SetOverallVolume);
        _backgroundVolumeSlider.onValueChanged.AddListener(SetBackgroundVolume);

        for (int i = 0; i < _trackVolumeSliders.Length; i++)
        {
            int index = i;
            _trackVolumeSliders[i].onValueChanged.AddListener(value => SetTrackVolume(index, value));
        }
    }

    private void OnDisable()
    {
        _overallVolumeSlider.onValueChanged.RemoveListener(SetOverallVolume);
        _backgroundVolumeSlider.onValueChanged.RemoveListener(SetBackgroundVolume);

        for (int i = 0; i < _trackVolumeSliders.Length; i++)
        {
            int index = i;
            _trackVolumeSliders[i].onValueChanged.RemoveListener(value => SetTrackVolume(index, value));
        }
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (clip != null)
        {
            _backgroundMusicSource.clip = clip;
            _backgroundMusicSource.Play();
        }
    }

    public void PlayTrack(int index)
    {
        if (index < _audioClips.Length)
        {
            StopAllTracksExcept(index);
            PlayTrack(index, _audioClips[index]);
        }
    }

    public void PlayTrack(int index, AudioClip clip)
    {
        if (index < _trackSources.Length && clip != null)
        {
            StopAllTracksExcept(index);
            _trackSources[index].clip = clip;
            _trackSources[index].Play();
        }
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;
        _backgroundMusicSource.mute = _isMuted;

        foreach (var track in _trackSources)
        {
            track.mute = _isMuted;
        }
    }

    private void StopAllTracksExcept(int index)
    {
        for (int i = 0; i < _trackSources.Length; i++)
        {
            if (i != index)
            {
                _trackSources[i].Stop();
            }
        }
    }

    private void SetOverallVolume(float volume)
    {
        AudioListener.volume = volume;

        foreach (var track in _trackSources)
        {
            track.volume = volume; 
        }

        if (_backgroundMusicSource != null)
            _backgroundMusicSource.volume = volume;
    }

    private void SetBackgroundVolume(float volume)
    {
        if (_backgroundMusicSource != null)
            _backgroundMusicSource.volume = volume;
    }

    private void SetTrackVolume(int index, float volume)
    {
        if (index < _trackSources.Length)
        {
            _trackSources[index].volume = volume;
        }
    }
}



