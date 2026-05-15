using UnityEngine;

public class IdleState : IPlayerState
{
    private PlayerManager player;
    private PlayerStateMachine stateMachine;

    public IdleState(PlayerManager player, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        player.animator.Play("Idle");
    }

    public void Update()
    {
        if (player.mover)
        {
            stateMachine.ChangeState(player.walkState);
        }
    }

    public void Exit()
    {
        Debug.Log("EXIT IDLE");
    }
}