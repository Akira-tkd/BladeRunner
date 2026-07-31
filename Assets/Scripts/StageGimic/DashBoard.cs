using UnityEngine;

public class DashBoard : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            c.gameObject.GetComponent<Player>().Dash();
        }
    }
}
