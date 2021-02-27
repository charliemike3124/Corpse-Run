using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool right = false;
    public bool left = false;
    public bool down = false;
    public bool up = false;
    public bool jump = false;
    public bool dash = false;

    void Update()
    {
        right = Input.GetKey(KeyCode.D) ? true : false;
        left = Input.GetKey(KeyCode.A) ? true : false;
        down = Input.GetKey(KeyCode.S) ? true : false;
        up = Input.GetKey(KeyCode.W) ? true : false;

        jump = Input.GetKeyDown(KeyCode.Space) ? true : false;
        dash = Input.GetKeyDown(KeyCode.LeftShift) ? true : false;

    }
}
