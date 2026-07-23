using UnityEngine;

public abstract class EnemyState
{
    public EnemyStateMachine ESM { get; private set; }

    public EnemyState(EnemyStateMachine esm)
    {
        this.ESM = esm;
    }

    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract void OnExit();
}
