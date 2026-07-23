using UnityEngine;

public class EnemyBlade : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public bool Hit = false;
    public bool Active = false;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Blade") && !Hit)
        {
            Active = false;
            _animator.SetTrigger("Guarded");
        }
    }

    void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack_1_InPlace") && !Active)
        {
            Debug.Log("ON");
            Hit = false;
            Active = true;
        }
        else if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack_1_InPlace") && Active)
        {
            Debug.Log("OFF");
            Active = false;
        }
    }
}
