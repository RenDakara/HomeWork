using UnityEngine;

public class Rotater : MonoBehaviour
{
    public void CharacterRotater(float direction)
    {
        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }
}

