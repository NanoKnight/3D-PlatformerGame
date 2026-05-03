using System.Runtime.Serialization;
using UnityEngine.UI;
using UnityEngine;

public class GoldWheats : MonoBehaviour , ICollectible
{
    [SerializeField] private WheatDesignSO wheatDesignSO;
   [SerializeField] private PlayerController playerController;
   [SerializeField] private PlayerStateUI playerStateUI;

   private RectTransform boosterTransform;
   private Image boosterImage;


    void Awake()
    {
        boosterTransform = playerStateUI.SpeedBoosterRectTransform;
        boosterImage = playerStateUI.SpeedBoosterRectTransform.GetComponent<Image>();
    }

    public void Collect()
    {
        playerController.IncreaseMovementSpeed(wheatDesignSO.MultiplierVal,wheatDesignSO.MultiplierTime);

        playerStateUI.PlayBoosterAnimation(boosterTransform,boosterImage,playerStateUI.GoldWheatImage,
        wheatDesignSO.ActiveSprite,wheatDesignSO.PassiveSprite,
        wheatDesignSO.WheatActiveSprite,wheatDesignSO.WheatPassiveSprite,wheatDesignSO.MultiplierTime);
        Destroy(gameObject);


    }

}
