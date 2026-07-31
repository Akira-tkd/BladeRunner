using UnityEngine;

public class BladeController : MonoBehaviour
{
    public bool Active {  get; private set; }

    [SerializeField] float _speedBorder;
    [SerializeField] bool _left;
    private float _speed;

    void Update()
    {
        if (_left)
        {
            _speed = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).magnitude;
        }
        else
        {
            _speed = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude;
        }

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
