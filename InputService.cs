using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public float GetHorizontalInput()
    {
        return Input.GetAxis(InputAxis.Horizontal);
    }

    public bool GetJumpInput()
    {
        return Input.GetButtonDown(InputAxis.Jump);
    }
}
