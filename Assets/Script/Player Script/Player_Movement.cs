using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private CharacterController Player_Controller;

    public Vector3 Move_Direction;

    public float Speed = 5f;
    private float gravity = 20f;

    public float Jump_Force = 10f;
    private float Vertical_Velocity;
 


    // Start is called before the first frame update
    void Awake()
    {
        Player_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        player_move();
        

    }

    void player_move()
    {

        Move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        Move_Direction = transform.TransformDirection(Move_Direction);
        Move_Direction *= Speed * Time.deltaTime;

        apply_gravity();

        Player_Controller.Move(Move_Direction);
    }

    void apply_gravity()
    {
            Vertical_Velocity -= gravity * Time.deltaTime;

            player_jump();

        Move_Direction.y = Vertical_Velocity * Time.deltaTime;
    }

    void player_jump()
    {
        if (Player_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            Vertical_Velocity = Jump_Force;
        }
    }

}
