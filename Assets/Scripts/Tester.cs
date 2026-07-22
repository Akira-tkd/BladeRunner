using UnityEngine;
using UnityEngine.InputSystem;

public class Tester : MonoBehaviour
{
    [SerializeField] Animator _ac;

    public void OnTest1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _ac.SetBool("Tester2", true);
        }
    }

    public void OnTest2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _ac.SetBool("Tester3", true);
        }
    }

    public void OnTest3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _ac.SetBool("Tester2", false);
            _ac.SetBool("Tester3", false);
        }
    }
}
