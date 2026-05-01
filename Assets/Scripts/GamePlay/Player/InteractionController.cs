using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Consts.WheatTypes.GOLD_WHEAT))
        {
            other.gameObject.GetComponent<GoldWheats>().Collect();
        }
        if(other.CompareTag(Consts.WheatTypes.HOLY_WHEAT))
        {
            other.gameObject.GetComponent<HolyWheats>().Collect();
        }

        if(other.CompareTag(Consts.WheatTypes.ROTTEN_WHEAT))
        {
            other.gameObject.GetComponent<RottenWheats>().Collect();
        }
    }
}
