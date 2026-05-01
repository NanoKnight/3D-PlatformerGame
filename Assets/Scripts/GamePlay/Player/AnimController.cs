using System;
using UnityEngine;

public class AnimController : MonoBehaviour
{
   [SerializeField] private Animator PlayerAnimator;

   private PlayerController playerController;
   private StateController stateController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        stateController = GetComponent <StateController>();

    }

    void Update()
    {
        SetPlayerAnimations();
    }
    void Start()
    {
        
     playerController.onPlayerJump += playerController_OnPlayerJumped; 
    }

    private void playerController_OnPlayerJumped()
    {
        PlayerAnimator.SetBool(Consts.playerAnimations.IS_JUMPING,true);
        Invoke(nameof(ResetJumping),0.5f);


    }
    private void ResetJumping()
    {
        PlayerAnimator.SetBool(Consts.playerAnimations.IS_JUMPING,false);

    }

    private void SetPlayerAnimations()
    {
        var currentState = stateController.GetPlayerState();
        switch(currentState)
        {
            case PlayerState.Idle:
            PlayerAnimator.SetBool(Consts.playerAnimations.IS_MOVING,false);
            PlayerAnimator.SetBool(Consts.playerAnimations.IS_SLIDING,false);
            break;

            case PlayerState.Run:
            PlayerAnimator.SetBool(Consts.playerAnimations.IS_MOVING,true);
            PlayerAnimator.SetBool(Consts.playerAnimations.IS_SLIDING,false);
            break;


            case PlayerState.SlideIdle:
            PlayerAnimator.SetBool(Consts.playerAnimations.IS_SLIDING_ACTIVE,false);
            PlayerAnimator.SetBool(Consts.playerAnimations.IS_SLIDING,true);
            break;

              case PlayerState.Slide:
            PlayerAnimator.SetBool(Consts.playerAnimations.IS_SLIDING_ACTIVE,true);
            PlayerAnimator.SetBool(Consts.playerAnimations.IS_SLIDING,true);
            break;
            
            
            



        }
    }


}
