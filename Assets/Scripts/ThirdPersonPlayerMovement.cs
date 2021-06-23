using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayerMovement : MonoBehaviour
{
     public Transform cam;
     public string weaponAnimTrig;

     [Header("Movement")]
     public CharacterController controller;
     public float speed = 2f;
     public float turnSmoothTime = .1f;

     [Header("Gravity")]
     public LayerMask groundMask;
     public Transform groundCheck;
     public float gravity = -9.81f;
     public float groundDistance = .4f;
     

     private Animator animator;
     private float turnSmoothVelocity;
     private int velocityHash;
     private bool isGrounded;
     private Vector3 velocity;

     private void Start()
     {
          animator = GetComponentInChildren<Animator>();
          velocityHash = Animator.StringToHash("Velocity");
     }
     private void Update()
     {
          isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

          if (isGrounded && velocity.y < 0)
               velocity.y = -2f;

          if (Input.GetButtonDown("Fire1") && weaponAnimTrig != "")
               animator.SetTrigger(weaponAnimTrig);

          float horizontal = Input.GetAxisRaw("Horizontal");
          float vertical = Input.GetAxisRaw("Vertical");
          Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

          if (direction.magnitude >= .1f)
          {
               float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
               float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

               transform.rotation = Quaternion.Euler(0f, angle, 0f);
               Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

               if (ShouldMove())
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
          }

          animator.SetFloat(velocityHash, direction.magnitude * speed);
          
          velocity.y += gravity * Time.deltaTime;
          controller.Move(velocity * Time.deltaTime);
     }

     private bool ShouldMove()
     {
          AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

          if (animatorStateInfo.IsName("Move"))
               return true;

          return false;
     }
}
