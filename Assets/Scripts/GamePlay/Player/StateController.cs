using UnityEngine;

public class StateController : MonoBehaviour
{
    private PlayerState CurrentPlayerState = PlayerState.Idle;
    public void Start()
    {
        ChangeState(PlayerState.Idle);
    }

    public void ChangeState(PlayerState newState)
    {
        if(CurrentPlayerState == newState) return;
        CurrentPlayerState = newState;
    }

    public PlayerState GetPlayerState()
    {
        return CurrentPlayerState;
    }
}
