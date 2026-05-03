using UnityEngine;
using UnityEngine.UI;

public class RottenWheats : MonoBehaviour,ICollectible
{
   
   [SerializeField] WheatDesignSO wheatDesignSO;
   [SerializeField] private PlayerController playerController;

     [SerializeField] private PlayerStateUI playerStateUI;

   private RectTransform boosterTransform;
   private Image boosterImage;

    void Awake()
    {
        boosterTransform = playerStateUI.SlowBoosterRectTransform;
        boosterImage = playerStateUI.SlowBoosterRectTransform.GetComponent<Image>();
    }
    public void Collect()
    {
        playerController.IncreaseMovementSpeed(wheatDesignSO.MultiplierVal,wheatDesignSO.MultiplierTime);
         playerStateUI.PlayBoosterAnimation(boosterTransform,boosterImage,playerStateUI.RottenWheatImage,
        wheatDesignSO.ActiveSprite,wheatDesignSO.PassiveSprite,
        wheatDesignSO.WheatActiveSprite,wheatDesignSO.WheatPassiveSprite,wheatDesignSO.MultiplierTime);
        Destroy(gameObject);
    }
}
