using UnityEngine;

public class AroundEnemyState : EnemyState
{
    public AroundEnemyState(EnemyStateMachine esm) : base(esm) { }

    private const float Offset = 4f;  // 自ら保つプレイヤーとの距離
    private const float Span = 1f;  // 移動するスパン
    private const float Speed = 2.0f;  // 移動速度
    private const float SerachDistance = 8f;  // Searchステートに移る距離
    private const float FightDistance = 2.5f;  //  Fightステートに移る距離
    private const float MinAngleChange = -15f;  // 一回の移動の最小角度
    private const float MaxAngleChange = 15f;  // 一回の移動の最大角度

    private EnemyContext _context;  // 行動判断に必要な情報
    private float _orbitAngle;  // プレイヤーからの現在地点のxz平面上の角度
    private float _duration;  // 前回の移動からの経過時間

    public override void OnStart()
    {
        _context = ESM.Owner.Context;

        var dir = _context.Self.position - _context.Player.position;
        _orbitAngle = Mathf.Atan2(dir.x, dir.z);

        _context.Animator.SetBool("Around", true);
        _context.Animator.SetTrigger("StateChange");

        _context.Agent.ResetPath();
        _context.Agent.updateRotation = false;
        _context.Agent.speed = Speed;

        _duration = 0;
    }

    public override void OnUpdate()
    {
        _duration += Time.deltaTime;
        if (_duration > Span)
        {
            _duration = 0;
            _orbitAngle += Random.Range(MinAngleChange, MaxAngleChange) * Mathf.Deg2Rad;

            Vector3 target = _context.Player.position + new Vector3(Mathf.Cos(_orbitAngle), 0, Mathf.Sin(_orbitAngle)) * Offset;
            _context.Agent.SetDestination(target);
        }

        _context.Self.LookAt(_context.Player);
        var rotation = _context.Self.rotation;
        rotation.x = 0;
        rotation.z = 0;
        _context.Self.rotation = rotation;

        float distance = (_context.Self.position - _context.Player.position).magnitude;
        if (distance > SerachDistance)
        {
            ESM.ChangeState(new SearchEnemyState(ESM));
        }
        else if(distance < FightDistance && Player.Instance.TargetList.Count < 5)
        {
            ESM.ChangeState(new FightEnemyState(ESM));
        }
    }

    public override void OnExit()
    {
        _context.Animator.SetBool("Around", false);
    }
}
