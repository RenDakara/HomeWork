using UnityEngine;
using UnityEngine.UI;

public class MusicUI : MonoBehaviour
{
    [SerializeField] private AudioMain _audioMain;
    [SerializeField] private Slider _overallVolumeSlider;
    [SerializeField] private Slider _backgroundVolumeSlider;
    [SerializeField] private Slider[] _trackVolumeSliders;

    private void OnEnable()
    {
        _overallVolumeSlider.onValueChanged.AddListener(_audioMain.SetOverallVolume);
        _backgroundVolumeSlider.onValueChanged.AddListener(_audioMain.SetBackgroundVolume);

        for (int i = 0; i < _trackVolumeSliders.Length; i++)
        {
            int index = i; 
            _trackVolumeSliders[i].onValueChanged.AddListener(value => _audioMain.SetTrackVolume(index, value));
        }
    }

    private void OnDisable()
    {
        _overallVolumeSlider.onValueChanged.RemoveListener(_audioMain.SetOverallVolume);
        _overallVolumeSlider.onValueChanged.RemoveListener(_audioMain.SetBackgroundVolume);

        for (int i = 0; i < _trackVolumeSliders.Length; i++)
        {
            int index = i; 
            _trackVolumeSliders[i].onValueChanged.RemoveListener(value => _audioMain.SetTrackVolume(index, value));
        }
    }
}