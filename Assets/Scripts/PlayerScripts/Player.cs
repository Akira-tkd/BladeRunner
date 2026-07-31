using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System;

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
    [SerializeField] AudioSource _loopAS;
    [SerializeField] AudioSource _oneshotAS;
    [SerializeField] AudioClip _hitSE;
    [SerializeField] GameObject _ps;

    private float _movement;

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

        if (_movement > 0 && _rb.linearVelocity.magnitude < 5f)
        {
            Vector3 forward = (_forward.position - this.transform.position).normalized;
            forward.y = 0;
            _rb.AddForce(forward * _movement * _speed);
        }

        if(_rb.linearVelocity.magnitude > 1f)
        {
            if (!_loopAS.isPlaying)
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
        if (c.gameObject.CompareTag("EnemyBlade"))
        {
            if (c.gameObject.GetComponent<EnemyBlade>().Active && !c.gameObject.GetComponent<EnemyBlade>().Hit)
            {
                c.gameObject.GetComponent<EnemyBlade>().Hit = true;

                ScoreManager.Instance.HitNum++;
                _oneshotAS.PlayOneShot(_hitSE);
            }
        }
    }

    public async void Dash()
    {
        float time = 0;
        Vector3 before = _offset;
        Vector3 after = transform.up * -0.5f + transform.forward * -1.5f;
        while(time < 0.1f)
        {
            time += Time.deltaTime;
            _offset = Vector3.Lerp(before, after, time / 0.1f);
            await UniTask.Yield();
        }
        _ps.SetActive(true);
        await UniTask.Delay(TimeSpan.FromSeconds(5f), DelayType.Realtime);
        _ps.SetActive(false);
        time = 0;
        while(time < 0.1f)
        {
            time += Time.deltaTime;
            _offset = Vector3.Lerp(after, before, time / 0.1f);
            await UniTask.Yield();
        }
        
    }
}
