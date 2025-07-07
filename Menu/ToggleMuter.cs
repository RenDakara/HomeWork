using UnityEngine;
using UnityEngine.Audio;

public class ToggleMuter : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    public delegate void MuteToggleHandler(bool isMuted);
    public event MuteToggleHandler OnMuteToggle;

    private bool isMuted = false;

    public void ToggleSound()
    {
        isMuted = !isMuted;
        float volume = isMuted ? -80f : 0f; 
        bool result = _audioMixer.SetFloat("MasterVolume", volume);
        OnMuteToggle?.Invoke(isMuted);
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}
