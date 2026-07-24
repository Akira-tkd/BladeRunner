using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _enemy;

    public void Spawn(int spawnNum, Vector3 corner1, Vector3 corner2)
    {
        for(int i = 0; i < spawnNum; i++)
        {
            var obj = Instantiate(_enemy);
            float spawnX, spawnY, spawnZ;
            spawnX = Random.Range(corner1.x, corner2.x);
            spawnY = Random.Range(corner1.y, corner2.y);
            spawnZ = Random.Range(corner1.z, corner2.z);

            obj.transform.position = new Vector3(spawnX, spawnY, spawnZ);
        }
    }
}
