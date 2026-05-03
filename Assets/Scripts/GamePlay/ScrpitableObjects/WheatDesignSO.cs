using System.IO;
using UnityEngine;  

[CreateAssetMenu (fileName ="WheatDesignSO", menuName = "ScriptableObjects/WheatDesignSO")]
public class WheatDesignSO : ScriptableObject
{
    [SerializeField] private float multiplierVal;
    [SerializeField] private float multiplierTime;
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite passiveSprite;
    [SerializeField] private Sprite wheatActiveSprite;
    [SerializeField] private Sprite wheatPassiveSprite;


    public float MultiplierVal => multiplierVal;
    public float MultiplierTime => multiplierTime;

    public Sprite  ActiveSprite =>activeSprite;
    public Sprite PassiveSprite => passiveSprite;
    public Sprite WheatActiveSprite => wheatActiveSprite;
    public Sprite WheatPassiveSprite => wheatPassiveSprite;
    

}
