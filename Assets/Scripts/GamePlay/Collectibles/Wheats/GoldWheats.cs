using System.Runtime.Serialization;
using UnityEngine;

public class GoldWheats : MonoBehaviour , ICollectible
{
    [SerializeField] private WheatDesignSO wheatDesignSO;
   [SerializeField] private PlayerController playerController;

   

   public void Collect()
    {
        playerController.IncreaseMovementSpeed(wheatDesignSO.MultiplierVal,wheatDesignSO.MultiplierTime);
        Destroy(gameObject);
    }

}
