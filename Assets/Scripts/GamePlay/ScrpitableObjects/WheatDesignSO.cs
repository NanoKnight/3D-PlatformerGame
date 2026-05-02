using System.IO;
using UnityEngine;  

[CreateAssetMenu (fileName ="WheatDesignSO", menuName = "ScriptableObjects/WheatDesignSO")]
public class WheatDesignSO : ScriptableObject
{
    [SerializeField] private float multiplierVal;
    [SerializeField] private float multiplierTime;

    public float MultiplierVal => multiplierVal;
    public float MultiplierTime => multiplierTime;
}
