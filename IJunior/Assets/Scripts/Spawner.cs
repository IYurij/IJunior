using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private EnemyTemplate _enemyTemplate;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(2f);
        int i = 0;

        while (true)
        {
            if (i > _spawnPoints.Length - 1)
                i = 0;

            DoSpawn(_spawnPoints[i]);

            i++;

            yield return waitForSeconds;
        }
    }

    private void DoSpawn(Transform spawner)
    {
        float rand = Random.Range(-0.05f, 0.06f);
        float positionX = spawner.position.x + rand;
        float positionY = spawner.position.y + 2f;
        float positionZ = spawner.position.z + rand;

        Instantiate(_enemyTemplate, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
    }
}
