using Mono.Cecil.Cil;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{

  private PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<ICollectible>(out var collectible) )
        {
            collectible.Collect();

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<IBoostable>(out var boostable))
        {
            boostable.Boost(playerController);
        }
    }
}
