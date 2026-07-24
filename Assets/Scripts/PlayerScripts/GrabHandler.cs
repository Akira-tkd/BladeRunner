using UnityEngine;
using UnityEngine.InputSystem;

public class GrabHandler : MonoBehaviour
{
    [SerializeField] GameObject _sword;
    [SerializeField] bool _left;

    public bool Grab = false;
    public float Dif = 0;

    private Vector3 _prePos;

    void Update()
    {
        if (!Grab)
        {
            if (_left)
            {
                Dif = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).magnitude;
            }
            else
            {
                Dif = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude;
            }
        }
        else
        {
            Dif = 0;
        }
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
        if (context.performed)
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
