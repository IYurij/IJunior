using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControlelr : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawners;
    [SerializeField] private GameObject _enemyTemplate;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(2f);
        int i = 0;

        while (true)
        {
            if (i > 2)
                i = 0;

            DoSpawn(_spawners[i]);

            i++;

            yield return waitForSeconds;
        }
    }

    private void DoSpawn(GameObject spawner)
    {
        float rand = Random.Range(-0.05f, 0.06f);
        float positionX = spawner.transform.position.x + rand;
        float positionY = spawner.transform.position.y + 2f;
        float positionZ = spawner.transform.position.z + rand;

        Instantiate(_enemyTemplate, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
    }
}
