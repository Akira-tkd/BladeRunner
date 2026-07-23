using UnityEngine;

public class EnemyStateMachine
{
    public Enemy Owner { get; private set; }
    public EnemyState CurrentState { get; private set; }

    public EnemyStateMachine(Enemy owner)
    {
        this.Owner = owner;
    }

    public void ChangeState(EnemyState newState)
    {
        CurrentState?.OnExit();
        CurrentState = newState;
        CurrentState?.OnStart();
    }
}
