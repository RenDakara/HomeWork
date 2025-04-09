using UnityEngine;
using UnityEngine.Audio;

public class AudioMain : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private BackgroundMusicPlayer _backgroundMusicPlayer;
    [SerializeField] private TrackPlayer _trackPlayer;

    public void PlayBackgroundMusic(AudioClip clip)
    {
        _backgroundMusicPlayer.Play(clip);
    }

    public void PlayTrack(int index)
    {
        _trackPlayer.Play(index);
    }

    public void ToggleMute()
    {
        _trackPlayer.ToggleMute();
        _backgroundMusicPlayer.ToggleMute();
    }

    public void SetOverallVolume(float volume)
    {
        _audioMixer.SetFloat("OverallVolume", volume);
    }

    public void SetBackgroundVolume(float volume)
    {
        _backgroundMusicPlayer.SetVolume(volume);
    }

    public void SetTrackVolume(int index, float volume)
    {
        _trackPlayer.SetTrackVolume(index, volume);
    }
}
