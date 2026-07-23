using UnityEngine;
using UnityEngine.AI;

public class EnemyContext
{
    public Transform Player;
    public Transform Self;
    public NavMeshAgent Agent;
    public Animator Animator;
}

public class Enemy : MonoBehaviour
{
    public EnemyContext Context { get ; private set; }

    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Animator _animator;

    private EnemyStateMachine _esm;

    void Start()
    {
        Context = new EnemyContext();
        Context.Player = Player.Instance.transform;
        Context.Self = this.transform;
        Context.Agent = _agent;
        Context.Animator = _animator;

        _esm = new EnemyStateMachine(this);
        _esm.ChangeState(new SearchEnemyState(_esm));
    }

    void Update()
    {
        _esm.CurrentState.OnUpdate();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Blade"))
        {
            if (c.gameObject.GetComponent<BladeController>().Active)
            {
                _esm.ChangeState(new DeathEnemyState(_esm));
            }
        }
    }
}
