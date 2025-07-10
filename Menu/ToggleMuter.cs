using UnityEngine;
using UnityEngine.Audio;

public class ToggleMuter : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    public delegate void MuteToggleHandler(bool isMuted);
    public event MuteToggleHandler OnMuteToggle;

    public bool isMuted {  get;  set; }

    public void ToggleSound()
    {
        float minDb = -80f;
        float maxDb = 0f;
        isMuted = !isMuted;
        float volume = isMuted ? minDb : maxDb; 
        bool result = _audioMixer.SetFloat("MasterVolume", volume);
        OnMuteToggle?.Invoke(isMuted);
    }
}
