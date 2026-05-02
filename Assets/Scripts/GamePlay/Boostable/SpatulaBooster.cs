using System;
using UnityEngine;

public class SpatulaBooster : MonoBehaviour, IBoostable
{
     [Header("References")]
     [SerializeField] private Animator SpatulaAnimator;

    [Header("Settings")]
    [SerializeField] float JumpForce;

    private bool Isactivated;

    public void Boost(PlayerController playerController)
    {
        if(Isactivated == true) return;
       PlayBoostAnimation();
       Rigidbody playerRigidbody = playerController.GetRigidbody();
      
      playerRigidbody.linearVelocity = new Vector3(playerRigidbody.linearVelocity.x,0f,playerRigidbody.linearVelocity.z);
      playerRigidbody.AddForce(transform.up * JumpForce,ForceMode.Impulse);
      Isactivated = true;
      Invoke(nameof(ResetActivation),0.2f);
    }

    private void PlayBoostAnimation()
    {
        SpatulaAnimator.SetTrigger(Consts.OtherAnimations.IS_SPATULA_JUMPING);
    }

    private void ResetActivation()
    {
        Isactivated = false;

    }
}
