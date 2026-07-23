using UnityEngine;

public class DeathEnemyState : EnemyState
{
    public DeathEnemyState(EnemyStateMachine esm) : base(esm) { }

    private EnemyContext _context;

    public override void OnStart()
    {
        _context = ESM.Owner.Context;

        _context.Animator.SetTrigger("Death");
    }

    public override void OnUpdate()
    {
        Debug.Log("Death");
    }

    public override void OnExit()
    {
        Debug.LogError("謎の不死身エラー発生");
    }
}
