using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _overallVolumeSlider;
    [SerializeField] private Slider _backgroundVolumeSlider;
    [SerializeField] private Slider[] _trackVolumeSliders; 
    [SerializeField] private AudioSource[] _trackSources;
    [SerializeField] private AudioSource _backgroundMusicSource;

    private void Start()
    {
        SetInitialSliderValues();

        _overallVolumeSlider.onValueChanged.AddListener(SetOverallVolume);
        _backgroundVolumeSlider.onValueChanged.AddListener(SetBackgroundVolume);

        for (int i = 0; i < _trackVolumeSliders.Length; i++)
        {
            int index = i;
            _trackVolumeSliders[i].onValueChanged.AddListener(value => SetTrackVolume(index, value));
        }
    }

    private void SetInitialSliderValues()
    {
        float overallVolume;
        if (_audioMixer.GetFloat("OverallVolume", out overallVolume))
        {
            _overallVolumeSlider.value = overallVolume;
        }

        float backgroundVolume;
        if (_audioMixer.GetFloat("BackgroundMusic", out backgroundVolume))
        {
            _backgroundVolumeSlider.value = backgroundVolume;
        }

        for (int i = 0; i < _trackSources.Length; i++)
        {
            if (_trackSources[i] != null)
            {
                _trackSources[i].volume = 1.0f;
              
                if (_trackVolumeSliders[i] != null)
                {
                    _trackVolumeSliders[i].value = _trackSources[i].volume;
                }
            }
        }
    }

    public void SetOverallVolume(float volume)
    {
        _audioMixer.SetFloat("OverallVolume", volume);
    }

    public void SetBackgroundVolume(float volume)
    {
        if (_backgroundMusicSource != null)
            _backgroundMusicSource.volume = volume;
    }

    public void SetTrackVolume(int index, float volume)
    {
        if (index < _trackSources.Length && index < _trackVolumeSliders.Length)
        {
            if (_trackSources[index] != null)
            {
                _trackSources[index].volume = volume; 
            }
        }
    }
}