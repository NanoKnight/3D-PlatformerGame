using UnityEngine;

public class HolyWheats : MonoBehaviour,ICollectible
{
   [SerializeField] WheatDesignSO wheatDesignSO;
   [SerializeField] private PlayerController playerController;
  

   public void Collect()
    {
        playerController.IncreaseJumpForce(wheatDesignSO.MultiplierVal,wheatDesignSO.MultiplierTime);
        Destroy(gameObject);
        
    }
}
