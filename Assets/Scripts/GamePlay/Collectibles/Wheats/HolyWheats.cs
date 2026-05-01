using UnityEngine;

public class HolyWheats : MonoBehaviour
{
   
   [SerializeField] private PlayerController playerController;
   [SerializeField] private float JumpBoost;
   [SerializeField] private float JumpTime;

   public void Collect()
    {
        playerController.IncreaseJumpForce(JumpBoost,JumpTime);
        Destroy(gameObject);
    }
}
