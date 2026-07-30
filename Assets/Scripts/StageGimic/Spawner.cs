using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] BoxCollider _c;
    [SerializeField] int _spawnNum;

    public void Spawn()
    {
        for(int i = 0; i < _spawnNum; i++)
        {
            var obj = Instantiate(_enemy);
            float spawnX, spawnZ;
            spawnX = Random.Range(_c.bounds.min.x, _c.bounds.max.x);
            spawnZ = Random.Range(_c.bounds.min.z, _c.bounds.max.z);

            obj.transform.position = new Vector3(spawnX, 1, spawnZ);
        }
    }
}
