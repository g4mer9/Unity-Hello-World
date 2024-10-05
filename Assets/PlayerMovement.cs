using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int jump_timer = 0;
    int jump_length = 45;
    bool can_jump = true;
    float y_pos_last_frame;
    float y_pos;
    float jump_power = 8.0f;
    float walk_power = 5.0f;
    public GameObject spawnPos;
    public GameObject[] toggleBlue;
    public GameObject[] toggleRed;
    public GameObject[] rotate;

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

        // respawn
        if (y_pos < -5) transform.position = spawnPos.transform.position; 

        //grounded
        if (y_pos == y_pos_last_frame)
        {
            //Debug.Log("jump available");
            can_jump = true;
            jump_timer = 0;
        }
        //length of jump
        else if (jump_timer >= jump_length) can_jump = false;
        y_pos_last_frame = y_pos;


        //INPUTS

        if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log("Left/Right");
            transform.Translate(walk_power * Time.deltaTime * Vector3.right * Input.GetAxis("Horizontal"));
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("Forwards/Backwards");
            transform.Translate(walk_power * Time.deltaTime * Vector3.forward * Input.GetAxis("Vertical"));
        }
        if (Input.GetButton("Jump") && can_jump)
        {
            Debug.Log("Jump");
            jump_timer++;
            transform.Translate(jump_power * Time.deltaTime * Vector3.up);
        }
        if (Input.GetButton("ScaleU") && !Input.GetButton("ScaleD"))
        {
            Debug.Log("ScaleU");
            transform.localScale = new Vector3(.05f, .05f, .05f) + transform.localScale;
        }
        if (Input.GetButton("ScaleD") && !Input.GetButton("ScaleU"))
        {
            Debug.Log("ScaleD");
            transform.localScale = new Vector3(-.05f, -.05f, -.05f) + transform.localScale;
        }
        if (Input.GetButton("RotateR") && !Input.GetButton("RotateL"))
        {
            Debug.Log("RotateR");
            for (int i = 0; i < rotate.Length; i++) { 
                rotate[i].transform.Rotate(new Vector3(0, 0, 2));
            }
        }
        if (Input.GetButton("RotateL") && !Input.GetButton("RotateR"))
        {
            Debug.Log("RotateL");
            for (int i = 0; i < rotate.Length; i++)
            {
                rotate[i].transform.Rotate(new Vector3(0, 0, -2));
            }
        }
        
    }




    private void Update()
    {
        if (Input.GetButtonDown("Toggle"))
        {
            Debug.Log("Toggle");
            for (int i = 0; i < toggleBlue.Length; i++)
            {
                if (toggleBlue[i].activeSelf)
                {
                    toggleBlue[i].SetActive(false);
                    toggleRed[i].SetActive(true);
                }
                else
                {
                    toggleRed[i].SetActive(false);
                    toggleBlue[i].SetActive(true);
                }
            }
        }
    }
}
