using System.Runtime.Serialization;
using UnityEngine;

public class GoldWheats : MonoBehaviour , ICollectible
{
   [SerializeField] private PlayerController playerController;
   [SerializeField] private float IncreaseMovementSpeed;
   [SerializeField] private float IncreaseTime;
   

   public void Collect()
    {
        playerController.IncreaseMovementSpeed(IncreaseMovementSpeed,IncreaseTime);
        Destroy(gameObject);
    }

}
