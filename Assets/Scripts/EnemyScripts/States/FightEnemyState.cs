using UnityEngine;

public class FightEnemyState : EnemyState
{
    public FightEnemyState(EnemyStateMachine esm) : base(esm) { }

    private const float Offset = 1.0f;  // 自ら保つプレイヤーとの距離感
    private const float Speed = 2f;  // 移動速度
    private const float SerachDistance = 5.0f;  // Searchステートに移行する距離
    private const float MoveSpan = 0.5f;  // 移動先を再設定するまでの間隔
    private const float MinAttackSpan = 0.8f;  // 再攻撃までの最短時間
    private const float MaxAttackSpan = 3.0f;  // 再攻撃までの最長時間
    private const float MinAngleChange = -3.0f;  // 一回の移動の最小角度
    private const float MaxAngleChange = 3.0f;  // 一回の移動の最大角度

    private EnemyContext _context;  // 行動判断に必要な情報
    private float _attackSpan;  // 攻撃間隔(ランダムで変更される)
    private float _attackDuration;  // 前回の攻撃からの経過時間
    private float _moveDuration;  // 前回の移動からの経過時間
    private float _orbitAngle;  // プレイヤーからの現在地点のxz平面上の角度

    public override void OnStart()
    {
        _context = ESM.Owner.Context;

        var dir = _context.Self.position - _context.Player.position;
        _orbitAngle = Mathf.Atan2(dir.x, dir.z);

        _context.Animator.SetBool("Fight", true);
        _context.Animator.SetTrigger("StateChange");

        _context.Agent.ResetPath();
        _context.Agent.updateRotation = false;
        _context.Agent.speed = Speed;
        _context.Agent.SetDestination(_context.Self.position);

        _attackSpan = Random.Range(MinAttackSpan, MaxAttackSpan);
        _attackDuration = 0;
        _moveDuration = 0;
        
        if(Player.Instance.TargetList.Count >= 5)
        {
            ESM.ChangeState(new AroundEnemyState(ESM));
        }
        else
        {
            Player.Instance.TargetList.Add(ESM.Owner);
        }
    }

    public override void OnUpdate()
    {
        _moveDuration += Time.deltaTime;
        _attackDuration += Time.deltaTime;
        if (_moveDuration > MoveSpan)
        {
            _moveDuration = 0;
            _orbitAngle += Random.Range(MinAngleChange, MaxAngleChange) * Mathf.Deg2Rad;

            Vector3 target = _context.Player.position + new Vector3(Mathf.Cos(_orbitAngle), 0, Mathf.Sin(_orbitAngle)) * Offset;
            _context.Agent.SetDestination(target);
        }

        if (_attackDuration > _attackSpan)
        {
            _attackDuration = 0;
            _attackSpan = Random.Range(MinAttackSpan, MaxAttackSpan);
            _context.Animator.SetTrigger("Attack");
        }

        _context.Self.LookAt(_context.Player);
        var rotation = _context.Self.rotation;
        rotation.x = 0;
        rotation.z = 0;
        _context.Self.rotation = rotation;

        float distance = (_context.Self.position - _context.Player.position).magnitude;
        if(distance > SerachDistance)
        {
            ESM.ChangeState(new SearchEnemyState(ESM));
        }
    }

    public override void OnExit()
    {
        _context.Animator.SetBool("Fight", false);
        Player.Instance.TargetList.Remove(ESM.Owner);
    }
}
