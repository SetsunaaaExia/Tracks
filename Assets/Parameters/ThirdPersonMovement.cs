using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 1.2f;
    public Animator animator;
    public float verticalPrev;
    public float horizontalPrev;

    public float gravity = -9.81f;
    public float verticalVelocity;

    
    // Update is called once per frame
    void Update()
    {
    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");
    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

    animator.SetFloat("Horizontal", horizontal);
    animator.SetFloat("Vertical", vertical);
    animator.SetFloat("Speed", direction.magnitude);

    if (controller.isGrounded)
    {
        verticalVelocity = 0f; // If grounded, reset the vertical velocity
    }
    else
    {
        // Apply gravity to the vertical velocity
        verticalVelocity += gravity * Time.deltaTime;
    }

    if(direction.magnitude >= 0.1f)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.y);

            controller.Move(direction * speed * Time.deltaTime);
        
        
        controller.Move(new Vector3(direction.x, verticalVelocity, direction.z) * speed * Time.deltaTime);
        float verticalPrev = vertical;
        float horizontalPrev = horizontal;
    }


    animator.SetFloat("HorizontalPrev", horizontalPrev);
    animator.SetFloat("VerticalPrev", verticalPrev);
    
    }
}

/* [SerializeField]
    public CinemachineVirtualCamera 
        
    } */

    /* [SerializeField]
    float roofheight;

    physics.Raycast wallDetector = Physics2D.Raycast(Player.position,  (0, 1, 0) , 4 , wallLayers);

    if (wallDetector)
    {
        cinemachineFreeLook.GetRig(2).GetCinemachineComponent<CinemachineComposer>().m_ScreenX = f;

    }
    else {
        if(speed >= 10) 
        {
            cinemachineFreeLook.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_ScreenX = f;

        } 
        else {

            cinemachineFreeLook.GetRig(0).GetCinemachineComponent<CinemachineComposer>().m_ScreenX = f;
        }
    } */


/*
change rig when enter building, change rig when running :


- create a height camera trigger (Raycast3D)
- analise the height above player

.if

- If the height is less than 2m AND the detected object is a plan/wall then :
- set rig to bottom

.Else

- analise player speed

    if  player speed > 3
    - then set rig to middle

    else
    - set rig to default (top)
*/