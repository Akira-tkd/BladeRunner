using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public List<Enemy> TargetList;


    [SerializeField] float _speed;
    [SerializeField] Vector3 _offset;
    [SerializeField] Rigidbody _rb;
    [SerializeField] GrabHandler _leftHand;
    [SerializeField] GrabHandler _rightHand;
    [SerializeField] Transform _camera;
    [SerializeField] Transform _rig;
    [SerializeField] Transform _forward;

    private float _movement;
    public int _hit;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        _rig.position = this.transform.position + _offset;
        var rotation = _camera.rotation;
        rotation.x = 0;
        rotation.z = 0;
        this.transform.rotation = rotation;

        _movement = 0;
        _movement += _leftHand.Dif;
        _movement += _rightHand.Dif;

        if (_movement > 0)
        {
            Vector3 forward = (_forward.position - this.transform.position).normalized;
            forward.y = 0;
            _rb.AddForce(forward * _movement * _speed);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("EnemyBlade"))
        {
            if (c.gameObject.GetComponent<EnemyBlade>().Active && !c.gameObject.GetComponent<EnemyBlade>().Hit)
            {
                _hit++;
                c.gameObject.GetComponent<EnemyBlade>().Hit = true;
            }
        }
    }
}
