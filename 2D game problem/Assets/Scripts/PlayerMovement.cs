using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runspeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()  //use this to get input from player
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
                                         //Horizontal, value between +1 and -1

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
             crouch = true;
        }else if(Input.GetButtonUp("Crouch"))  //until release will keep crouching
        {
            crouch = false;
        }
    }

    void FixedUpdate()   //use this to apply input in character
    {                    //fixed amount of time per sec, thus fixedupdate
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        //move character
        jump = false;
        //doesnt keep jumping
    }
}
