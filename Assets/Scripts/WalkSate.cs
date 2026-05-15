using UnityEngine;

public class WalkState : IPlayerState
{
    private PlayerManager player;
    private PlayerStateMachine stateMachine;

    public WalkState(PlayerManager player, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        player.animator.Play("Walk");
    }

    public void Update()
    {
        if (player.mover == false)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public void Exit()
    {
        Debug.Log("EXIT WALK");
    }
}