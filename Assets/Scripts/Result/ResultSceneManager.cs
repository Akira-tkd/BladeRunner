using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    public void OnAPush(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Destroy(ScoreManager.Instance.gameObject);
            SceneManager.LoadScene("Title");
        }
    }
}
