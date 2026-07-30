using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] Spawner _spawner;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            _spawner.Spawn();
            Destroy(this.gameObject);
        }
    }
}
