using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void OnPushA(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SceneManager.LoadScene("VRScene");
        }
    }
}
