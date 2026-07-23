using UnityEngine;

public class BladeController : MonoBehaviour
{
    public bool Active {  get; private set; }

    [SerializeField] float _speedBorder;
    private Vector3 _prePos;
    private float _speed;

    void Update()
    {
        if(_prePos != null)
        {
            _speed = (transform.position - _prePos).magnitude;
        }
        _prePos = transform.position;

        if (_speed > _speedBorder && !Active)
        {
            Active = true;
        }
        else if(_speed < _speedBorder)
        {
            Active = false;
        }
    }
}
