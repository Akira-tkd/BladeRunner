using UnityEngine;

public class SearchEnemyState : EnemyState
{
    private const float Span = 0.2f;  // 経路再設定をする間隔
    private const float Speed = 6.0f;  // サーチ時の移動速度
    private const float Offset = 3.0f;  // サーチを終了するプレイヤーとの距離

    private EnemyContext _context;  // 行動判断に必要な情報
    private float _duration;  // 前回の経路再設定からの経過時間

    public SearchEnemyState(EnemyStateMachine esm) : base(esm) { }

    public override void OnStart()
    {
        _context = ESM.Owner.Context;

        _context.Animator.SetBool("Search", true);
        _context.Animator.SetTrigger("StateChange");

        _context.Agent.updateRotation = true;
        _context.Agent.ResetPath();

        _duration = 0;
    }

    public override void OnUpdate()
    {
        _duration += Time.deltaTime;
        if(_duration > Span)
        {
            _context.Agent.SetDestination(_context.Player.position);
            _context.Agent.speed = Speed;
            _duration = 0;
        }

        float distance = (_context.Self.position -  _context.Player.position).magnitude;
        if(distance < Offset)
        {
            ESM.ChangeState(new FightEnemyState(ESM));
        }
    }

    public override void OnExit()
    {
        _context.Animator.SetBool("Search", false);
    }
}
