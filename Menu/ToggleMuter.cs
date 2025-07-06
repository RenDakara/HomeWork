using UnityEngine;

public class ToggleMuter : MonoBehaviour
{
    public delegate void MuteToggleHandler(bool isMuted);
    public event MuteToggleHandler OnMuteToggle;

    public bool isMuted = false;

    public void ToggleSound()
    {
        isMuted = !isMuted;
        OnMuteToggle?.Invoke(isMuted);
    }

    public bool IsMuted()
    {
        return isMuted; 
    }
}
