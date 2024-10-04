using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int jump_timer = 0;
    int jump_length = 90;
    bool can_jump = true;
    float y_pos_last_frame;
    float y_pos;
    float jump_power = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        y_pos_last_frame = transform.position.y;
        y_pos = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        y_pos = transform.position.y;
        if (y_pos == y_pos_last_frame)
        {
            Debug.Log("jump available");
            can_jump = true;

        }
        else if (jump_timer >= jump_length) can_jump = false;
        y_pos_last_frame = y_pos;

        if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log("Left/Right");
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("Forwards/Backwards");
        }
        if (Input.GetButton("Jump") && can_jump)
        {
            Debug.Log("Jump");
            jump_timer++;
            transform.Translate(jump_power * Time.deltaTime * transform.up);
        }
        if (Input.GetButton("ScaleU") && !Input.GetButton("ScaleD"))
        {
            Debug.Log("ScaleU");
        }
        if (Input.GetButton("ScaleD") && !Input.GetButton("ScaleU"))
        {
            Debug.Log("ScaleD");
        }
        if (Input.GetButton("RotateR") && !Input.GetButton("RotateL"))
        {
            Debug.Log("RotateR");
        }
        if (Input.GetButton("RotateL") && !Input.GetButton("RotateR"))
        {
            Debug.Log("RotateL");
        }
        if (Input.GetButtonDown("Toggle"))
        {
            Debug.Log("Toggle");
        }
    }
}
