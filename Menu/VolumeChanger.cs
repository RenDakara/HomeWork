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
        float minDb = -80f;
        float maxDb = 0f;
        float currentVolume;

        if (audioMixer.GetFloat(parameterName, out currentVolume))
        {
            volumeSlider.value = Mathf.InverseLerp(minDb, maxDb, currentVolume);
        }

        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        float minDb = -80f;
        float maxDb = 0f;

        float safeValue = Mathf.Clamp(value, 0.0001f, 1f);

        float dB = Mathf.Log10(safeValue) * 20f;

        dB = Mathf.Clamp(dB, minDb, maxDb);

        audioMixer.SetFloat(parameterName, dB);
    }
}