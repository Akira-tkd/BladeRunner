using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] Spawner _spawner;
    [SerializeField] int _num;
    [SerializeField] Vector3 _corner1;
    [SerializeField] Vector3 _corner2;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            _spawner.Spawn(_num, _corner1, _corner2);
            Destroy(this.gameObject);
        }
    }
}
