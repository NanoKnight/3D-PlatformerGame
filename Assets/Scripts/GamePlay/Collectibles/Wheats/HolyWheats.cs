using UnityEngine;
using UnityEngine.UI;

public class HolyWheats : MonoBehaviour,ICollectible
{
   [SerializeField] WheatDesignSO wheatDesignSO;
   [SerializeField] private PlayerController playerController;

    [SerializeField] private PlayerStateUI playerStateUI;

   private RectTransform boosterTransform;
   private Image boosterImage;

    void Awake()
    {
        boosterTransform = playerStateUI.JumpBoosterRectTransform;
        boosterImage = playerStateUI.JumpBoosterRectTransform.GetComponent<Image>();
    }

    public void Collect()
    {
        playerController.IncreaseJumpForce(wheatDesignSO.MultiplierVal,wheatDesignSO.MultiplierTime);
            playerStateUI.PlayBoosterAnimation(boosterTransform,boosterImage,playerStateUI.HolyWheatImage,
        wheatDesignSO.ActiveSprite,wheatDesignSO.PassiveSprite,
        wheatDesignSO.WheatActiveSprite,wheatDesignSO.WheatPassiveSprite,wheatDesignSO.MultiplierTime);
        Destroy(gameObject);
        
    }
}
