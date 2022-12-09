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

    private PlayerFootSteps Player_FootSteps;

    private float sprint_Volume = 1f;
    private float crouch_Volume = 0.1f;
    private float walk_Volume_Min = 0.2f, walk_Volume_Max = 0.6f;

    private float walk_Step_Distance = 0.4f;
    private float sprint_Step_Distance = 0.25f;
    private float crouch_Step_Distance = 0.5f;


    
    void Awake()
    {
        Player_Movement = GetComponent<Player_Movement>();

        Player_FootSteps = GetComponentInChildren<PlayerFootSteps>();

        look_Root = transform.GetChild(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        Player_FootSteps.volume_Min = walk_Volume_Min;
        Player_FootSteps.volume_Max = walk_Volume_Max;
        Player_FootSteps.step_Distance = walk_Step_Distance;
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

            Player_FootSteps.volume_Min = sprint_Volume;
            Player_FootSteps.volume_Max = sprint_Volume;
            Player_FootSteps.step_Distance = sprint_Step_Distance;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            Player_Movement.Speed = move_Speed;

            Player_FootSteps.volume_Min = walk_Volume_Min;
            Player_FootSteps.volume_Max = walk_Volume_Max;
            Player_FootSteps.step_Distance = walk_Step_Distance;
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

                Player_FootSteps.volume_Min = walk_Volume_Min;
                Player_FootSteps.volume_Max = walk_Volume_Max;
                Player_FootSteps.step_Distance = walk_Step_Distance;
            }
            else
            {
                look_Root.localPosition = new Vector3(0f, crouch_Height, 0f);
                Player_Movement.Speed = Crouch_Speed;
                is_Crouching = true;

                Player_FootSteps.volume_Min = crouch_Volume;
                Player_FootSteps.volume_Max = crouch_Volume;
                Player_FootSteps.step_Distance = crouch_Step_Distance;
            }
        }
    }

}
