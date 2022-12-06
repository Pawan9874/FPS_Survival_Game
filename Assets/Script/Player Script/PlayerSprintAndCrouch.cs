using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{

    private Player_Movement Player_Movement;

    public float Sprit_Speed = 10f;
    public float move_Speed = 5;
    public float Crouch_Speed = 2;

    private Transform look_Root;
    private float stand_Height = 1.6f;
    private float crouch_Height = 1f;

    private bool is_Crouching;
    // Start is called before the first frame update
    void Awake()
    {
        Player_Movement = GetComponent<Player_Movement>();

        look_Root = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();

    }

    void Sprint()
    {

        if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching)
        {
            Player_Movement.Speed = Sprit_Speed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            Player_Movement.Speed = move_Speed;
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(is_Crouching)
            {
                look_Root.localPosition = new Vector3(0f, stand_Height, 0f);
                Player_Movement.Speed = move_Speed;
                is_Crouching = false;
            }
            else
            {
                look_Root.localPosition = new Vector3(0f, crouch_Height, 0f);
                Player_Movement.Speed = Crouch_Speed;
                is_Crouching = true;
            }
        }
    }

}
