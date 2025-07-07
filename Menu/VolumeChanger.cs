using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string parameterName;

    private void Start()
    {
        float currentVolume;
        if (audioMixer.GetFloat(parameterName, out currentVolume))
        {     
            volumeSlider.value = Mathf.InverseLerp(-80f, 0f, currentVolume);
        }

        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        float dB = Mathf.Lerp(-80f, 0f, value);
        audioMixer.SetFloat(parameterName, dB);
    }
}

