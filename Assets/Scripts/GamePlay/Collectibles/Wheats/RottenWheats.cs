using UnityEngine;

public class RottenWheats : MonoBehaviour,ICollectible
{
   
   [SerializeField] WheatDesignSO wheatDesignSO;
   [SerializeField] private PlayerController playerController;

   public void Collect()
    {
        playerController.IncreaseMovementSpeed(wheatDesignSO.MultiplierVal,wheatDesignSO.MultiplierTime);
        Destroy(gameObject);
    }
}
