using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource[] _soundEffects; 

    private ToggleMuter toggleMuter;
    private VolumeChanger volumeChanger;

    void Start()
    {
        toggleMuter = FindObjectOfType<ToggleMuter>();
        volumeChanger = FindObjectOfType<VolumeChanger>();

        toggleMuter.OnMuteToggle += HandleMuteToggle;
    }

    public void PlaySound(int index)
    {
        if (toggleMuter != null && !toggleMuter.isMuted)
        {
            if (index >= 0 && index < _soundEffects.Length)
            {
                StopAllSounds();
                _soundEffects[index].Play(); 
            }
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
                sound.Play();
            }
            else
            {
                if (sound.isPlaying) sound.Pause();
            }
        }
    }
}
