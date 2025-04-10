using UnityEngine;
using UnityEngine.UI;

public class ToggleMute : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private AudioSource[] _trackSources;

    private bool _isMuted = false; 

    public void ToggleSound()
    {
        _isMuted = !_isMuted; 

        if (_isMuted)
        {
            _backgroundMusicSource.Pause(); 
        }
        else
        {
            _backgroundMusicSource.UnPause();
        }

        foreach (var track in _trackSources)
        {
            track.mute = _isMuted;
        }
    }
}
