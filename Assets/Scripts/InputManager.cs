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
    public bool run = false;
    public bool runKeyUp = false;
    public bool escape = false;
    public bool interact = false;
    public bool toggleHold = false;

    void Update()
    {
        right = Input.GetKey(KeyCode.D) ? true : false;
        left = Input.GetKey(KeyCode.A) ? true : false;
        down = Input.GetKey(KeyCode.S) ? true : false;
        up = Input.GetKey(KeyCode.W) ? true : false;
        run = Input.GetKey(KeyCode.LeftShift) ? true : false;
        runKeyUp = Input.GetKeyUp(KeyCode.LeftShift) ? true : false;

        jump = Input.GetKeyDown(KeyCode.Space) ? true : false;
        escape = Input.GetKeyDown(KeyCode.Escape) ? true : false;
        interact = Input.GetKeyDown(KeyCode.E) ? true : false;
        toggleHold = Input.GetKeyDown(KeyCode.R) ? true : false;

    }
}
