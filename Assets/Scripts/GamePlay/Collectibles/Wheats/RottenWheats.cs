using UnityEngine;

public class RottenWheats : MonoBehaviour,ICollectible
{
   
   [SerializeField] private PlayerController playerController;
   [SerializeField] private float DecreaseMovementSpeed;
   [SerializeField] private float DecreaseTime;

   public void Collect()
    {
        playerController.IncreaseMovementSpeed(DecreaseMovementSpeed,DecreaseTime);
        Destroy(gameObject);
    }
}
