using System.Runtime.CompilerServices;
using NUnit.Framework;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

   public event Action onPlayerJump;


    [Header ("References")]
    [SerializeField] Transform OrientationTransform;

    [Header("CharacterMovementSettings")]
    [SerializeField] private float MovementSpeed = 25;
    [Header("Jump Settings")]
    [SerializeField] private KeyCode JumpKey;
    [SerializeField] private float JumpForce;
    [SerializeField] private float JumpCooldown;
    [SerializeField] private float AirMultiplier;
    [SerializeField] private float AirDrag;
    private bool canJump = true;

    
    [Header("Ground Check Settings")]

    [SerializeField]private float PlayerHeight;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private KeyCode MovementKey;
    [SerializeField] private float GroundDrag;

    [Header("SlideSettings")]
    [SerializeField] private KeyCode SlideKey;
    [SerializeField] private float SlideMultiplier;
    [SerializeField] private float SlideDrag;

    private StateController PlayerStateController; 

    private Rigidbody PlayerRigidBody;
    private float HorizontalInput, VerticalInput;
    private Vector3 MovementDirection;
    private bool IsSliding;

    void Awake()
    {
        PlayerStateController = GetComponent<StateController>();
        PlayerRigidBody = GetComponent<Rigidbody>();
        PlayerRigidBody.freezeRotation = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetInputs();
        SetStates();
        SetPlayerDrag();
        LimitPlayerSpeed();
    }

    void FixedUpdate()
    {
     SetPlayerMovement();
    }

    private void SetStates()
    {
        var movementDirection = GetMovementDirection();
        var isGrounded = IsGrounded();
        var currentStates = PlayerStateController.GetPlayerState();

        var newState = currentStates switch
        {
          _ when movementDirection ==  Vector3.zero && isGrounded && !IsSliding => PlayerState.Idle,
          _ when movementDirection != Vector3.zero && isGrounded && !IsSliding => PlayerState.Run,
          _ when movementDirection != Vector3.zero && isGrounded && IsSliding => PlayerState.Slide,
          _ when movementDirection == Vector3.zero && isGrounded && IsSliding => PlayerState.SlideIdle,
          _ when !canJump && !isGrounded => PlayerState.Jump,
          _ => currentStates   
        };

        if (newState != currentStates)
        {
            PlayerStateController.ChangeState(newState);
        }
    }
    private void SetInputs()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(SlideKey))
        {
            IsSliding = true;
        }
        else if(Input.GetKeyDown(MovementKey))
        {
            IsSliding = false;
        }

        else if(Input.GetKey(JumpKey) && canJump && IsGrounded())
        {
            canJump = false;
            SetPlayerJump();
            Invoke(nameof(ResetJump), JumpCooldown);
        }

    }

    private void SetPlayerMovement()
    {
        MovementDirection = OrientationTransform.forward * VerticalInput 
        + OrientationTransform.right * HorizontalInput;

        float ForceMultiplier = PlayerStateController.GetPlayerState() switch
        {
          PlayerState.Run => 1f,
          PlayerState.Slide => SlideMultiplier,
          PlayerState.Jump => AirMultiplier,
          _ =>1
          

        };
            PlayerRigidBody.AddForce(MovementDirection.normalized * MovementSpeed*ForceMultiplier,ForceMode.Force);

    

    }
    private void SetPlayerJump()
    {

        onPlayerJump?.Invoke();
        PlayerRigidBody.linearVelocity = new Vector3(PlayerRigidBody.linearVelocity.x , 0f,PlayerRigidBody.linearVelocity.z);
        PlayerRigidBody.AddForce(transform.up* JumpForce,ForceMode.Impulse);
        
    }
    
    private void ResetJump()
    {
        canJump = true;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position,Vector3.down,PlayerHeight*0.5f + 0.2f,GroundLayer);

    }
    private void SetPlayerDrag()
    {

        PlayerRigidBody.linearDamping = PlayerStateController.GetPlayerState() switch
        {
          PlayerState.Slide => SlideDrag,
          PlayerState.Run => GroundDrag,
          PlayerState.Jump => AirDrag,
           _ => PlayerRigidBody.linearDamping
            
        };

      
    }

    private void LimitPlayerSpeed()
    {
        Vector3 FlatVelocity = new Vector3(PlayerRigidBody.linearVelocity.x,0,PlayerRigidBody.linearVelocity.z);
        if(FlatVelocity.magnitude > MovementSpeed)
        {
            Vector3 LimitedVelocity = FlatVelocity.normalized * MovementSpeed;
            PlayerRigidBody.linearVelocity = new Vector3(LimitedVelocity.x,LimitedVelocity.y,LimitedVelocity.z);
        }
 
    }
    private Vector3 GetMovementDirection()
    {
        return MovementDirection.normalized;
    }
}

