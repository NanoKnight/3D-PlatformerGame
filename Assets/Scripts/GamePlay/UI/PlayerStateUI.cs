using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Sprites;
using DG.Tweening;
using System.Collections;

public class PlayerStateUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private RectTransform slidingRectTransform;
    [SerializeField] private RectTransform WalkingRectTransform;
    [SerializeField] private RectTransform SpeedBoosterTransform;
    [SerializeField] private RectTransform JumpBoosterTransform;
    [SerializeField] private RectTransform SlowBoosterTransform;

    [Header ("Images")]
    [SerializeField] private Image goldBoosterWheatImage;
    [SerializeField] private Image holyBoosterWheatImage;
    [SerializeField] private Image rottenBoosterWheatImage;
    
    [Header ("Sprites")]
    [SerializeField] private Sprite PlayerWalkingPassive;
    [SerializeField] private Sprite PlayerWalkingActive;
    [SerializeField] private Sprite PlayerSlidingPassive;
    [SerializeField] private Sprite PlayerSlidingActive;
    
    [Header("Settings")]
    [SerializeField] private float MoveDuration;
    [SerializeField] private Ease moveEase;

    public RectTransform SpeedBoosterRectTransform => SpeedBoosterTransform;
    public RectTransform JumpBoosterRectTransform => JumpBoosterTransform;
    public RectTransform SlowBoosterRectTransform => SlowBoosterTransform;

    public Image GoldWheatImage => goldBoosterWheatImage;
    public Image HolyWheatImage => holyBoosterWheatImage;
    public Image RottenWheatImage =>rottenBoosterWheatImage;
    private Image PlayerWalkingImage;
    private Image PlayerSlidingImage;

    

    void Awake()
    {
        PlayerWalkingImage = WalkingRectTransform.GetComponent<Image>();
        PlayerSlidingImage = slidingRectTransform.GetComponent<Image>();
    }

    void Start()
    {
        playerController.OnPlayerStateChanged += PlayerController_OnPlayerChanged;
         SetPlayerUI(WalkingRectTransform,slidingRectTransform,PlayerWalkingActive,PlayerSlidingPassive);

    }

    private void PlayerController_OnPlayerChanged(PlayerState playerState)
    {
        switch(playerState)
        {
            case PlayerState.Idle:
            case PlayerState.Run:
            SetPlayerUI(WalkingRectTransform,slidingRectTransform,PlayerWalkingActive,PlayerSlidingPassive);
            break;

            case PlayerState.Slide:
            case PlayerState.SlideIdle:
            SetPlayerUI(slidingRectTransform,WalkingRectTransform,PlayerWalkingPassive,PlayerSlidingActive);
            break;
        }
    }

    private void SetPlayerUI(RectTransform ActiveTransform,RectTransform PassiveTransform,
    Sprite WalkingSprite,Sprite SlidingSprite)
    {
        PlayerWalkingImage.sprite = WalkingSprite;
        PlayerSlidingImage.sprite = SlidingSprite;

        ActiveTransform.DOAnchorPosX(-25f,MoveDuration).SetEase(moveEase);
        PassiveTransform.DOAnchorPosX(-90f,MoveDuration).SetEase(moveEase);
        
    }

    private IEnumerator SetBoosterUI(RectTransform activeTranform,Image boosterImage,Image wheatImage,
    Sprite activeSprite, Sprite passiveSprite,Sprite activeWheatSprite, Sprite passiveWheatSprite,float duration)
    {
        boosterImage.sprite = activeSprite;
        wheatImage.sprite = activeWheatSprite;
        activeTranform.DOAnchorPosX(25,MoveDuration).SetEase(moveEase);

        yield return new WaitForSeconds(duration);
        boosterImage.sprite = passiveSprite;
        wheatImage.sprite = passiveWheatSprite;
        activeTranform.DOAnchorPosX(90,MoveDuration).SetEase(moveEase);
        
    }

    public void PlayBoosterAnimation(RectTransform activeTranform,Image boosterImage,Image wheatImage,
    Sprite activeSprite, Sprite passiveSprite,Sprite activeWheatSprite, Sprite passiveWheatSprite,float duration)
    {
        StartCoroutine(SetBoosterUI(activeTranform,boosterImage,wheatImage,activeSprite,
        passiveSprite,activeWheatSprite,passiveWheatSprite,duration));
    }
}
