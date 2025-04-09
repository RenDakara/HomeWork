using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource[] _trackSources;

    private bool _isMuted;

    public void Play(int index)
    {
        if (index < _trackSources.Length)
        {
            StopAllTracksExcept(index);
            _trackSources[index].Play();
        }
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;

        foreach (var track in _trackSources)
        {
            track.mute = _isMuted;
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

    public void SetTrackVolume(int index, float volume)
    {
        if (index < _trackSources.Length)
        {
            _trackSources[index].volume = volume;
        }
    }
}