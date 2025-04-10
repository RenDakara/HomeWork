using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private AudioSource[] _trackSources;
    [SerializeField] private AudioClip _backgroundMusicClip; 
    [SerializeField] private AudioClip[] _trackClips; 

    public void PlayBackgroundMusic()
    {
        PlayBackgroundMusic(_backgroundMusicClip);
    }

    public void PlayTrack(int index)
    {
        if (index < 0 || index >= _trackClips.Length)
        {
            return;
        }
        PlayTrack(index, _trackClips[index]);
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (clip != null)
        {
            _backgroundMusicSource.clip = clip;
            _backgroundMusicSource.Play();
        }
    }

    public void PlayTrack(int index, AudioClip clip)
    {
        if (index < 0 || index >= _trackSources.Length)
        {
            return;
        }

        if (clip != null)
        {
            StopAllTracksExcept(index);
            _trackSources[index].clip = clip;
            _trackSources[index].Play();
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
}
