using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource[] _soundEffects;

    public void SetGlobalVolume(float volume)
    {
        AudioListener.volume = volume; 
    }

    public void SetBackgroundVolume(float volume)
    {
        _backgroundMusic.volume = volume; 
    }

    public void SetCurrentSoundVolume(float volume)
    {
        foreach (var sound in _soundEffects)
        {
            if (sound.isPlaying)
            {
                sound.volume = volume;
                break; 
            }
        }
    }
}
