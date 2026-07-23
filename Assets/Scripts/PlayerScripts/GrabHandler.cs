using UnityEngine;
using UnityEngine.InputSystem;

public class GrabHandler : MonoBehaviour
{
    [SerializeField] GameObject _sword;

    public bool Grab = false;
    public float Dif = 0;

    private Vector3 _prePos;

    void Update()
    {
        if(_prePos != null)
        {
            Dif = (_prePos - this.transform.position).sqrMagnitude;
        }
        _prePos = this.transform.position;
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _sword.SetActive(true);
            Grab = true;
        }
        else if (context.canceled)
        {
            _sword.SetActive(false);
            Grab = false;
        }
    }
}
