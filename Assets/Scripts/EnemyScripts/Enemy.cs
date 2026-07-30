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
    [SerializeField] AudioSource _loopAS;
    [SerializeField] AudioSource _oneshotAS;
    [SerializeField] AudioClip _hitSE;

    private EnemyStateMachine _esm;
    private bool _death = false;
    private float _deathTime = 0;

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
        if(_death)
        {
            _deathTime += Time.deltaTime;
            if(_deathTime > 1)
            {
                Destroy(this.gameObject);
            }
        }

        if(_agent.velocity.magnitude > 1f)
        {
            if(!_loopAS.isPlaying)
            {
                _loopAS.Play();
            }
        }
        else
        {
            _loopAS.Stop();
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Blade") && !_death)
        {
            if (c.gameObject.GetComponent<BladeController>().Active)
            {
                _esm.ChangeState(new DeathEnemyState(_esm));
                _death = true;

                ScoreManager.Instance.KillNum++;
                _oneshotAS.PlayOneShot(_hitSE);
            }
        }
    }
}
