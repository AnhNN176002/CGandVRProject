using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Animator anim;

    public FreeMovement motor;
    public Transform playerTransform;

    private Quaternion screenMovementSpace;
    private Vector3 screenMovementForward;
    private Vector3 screenMovementRight;

    private string AXIS_Y = "Vertical";
    private string AXIS_X = "Horizontal";
    private string ANIMATION_RUN = "Run";
    private string ANIMATION_JUMP = "Jump";
    private string ANIMATION_DOUBLEJUMP = "DoubleJump";
    private string ANIMATION_TWERK = "LevelUp";

    private bool isGrounded;
    private bool playerJump;
    private bool canDoubleJump;

    [HideInInspector]
    public static bool isLeveledUp;

    void Awake()
    {
        anim = GetComponent<Animator>();
        motor.movementDirection = Vector3.zero;
    }

    void Start()
    {
        screenMovementSpace = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y, 0);
        screenMovementForward = screenMovementSpace * Vector3.forward;
        screenMovementRight = screenMovementSpace * Vector3.right;
    }

    void Update()
    {
        motor.movementDirection = Input.GetAxis(AXIS_X) * screenMovementRight + 
            Input.GetAxis(AXIS_Y) * screenMovementForward;

        if (Input.GetAxis(AXIS_X) != 0 || Input.GetAxis(AXIS_Y) != 0)
        {
            anim.SetBool(ANIMATION_RUN, true);
        } else {
            anim.SetBool(ANIMATION_RUN, false);
        }

        if (motor.movementDirection.sqrMagnitude > 1)
            motor.movementDirection.Normalize();

        PlayerJump();
    }

    private void FixedUpdate()
    {
        PlayerGrounded();
    }

    public void PlayerGrounded()
    {
        isGrounded = Physics.OverlapSphere(motor.groundCheckPosition.position, motor.radius, motor.layerGround).Length > 0;
        //Debug.Log(isGrounded);

        if(isGrounded && playerJump) playerJump = false;
        anim.SetBool(ANIMATION_JUMP, false);
        anim.SetBool(ANIMATION_DOUBLEJUMP, false);
    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && canDoubleJump)
        {
            motor.myBody.AddForce(new Vector3(0, motor.secondJumpPower, 0));
            anim.SetBool(ANIMATION_DOUBLEJUMP, true);
            anim.SetBool(ANIMATION_JUMP, false);
            canDoubleJump = false;
            //Debug.Log("jump 2");
        }
        else if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            motor.myBody.AddForce(new Vector3(0, motor.jumpPower, 0));
            anim.SetBool(ANIMATION_JUMP, true);
            //anim.SetBool(ANIMATION_RUN, false);
            playerJump = true;
            canDoubleJump = true;
            Debug.Log("jump 1");
        }
    }

    public void StartTwerking()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            isLeveledUp = true;
            anim.SetBool(ANIMATION_TWERK, true);
        }
    }
}
