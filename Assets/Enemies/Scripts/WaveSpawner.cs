using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public EnemySpawnUtils helper;

    [SerializeField]
    private float spawnDelay = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnWave1(spawnDelay));
    }

    private IEnumerator spawnWave1(float interval = 0f) {
        yield return new WaitForSeconds(interval);

        StartCoroutine(helper.spawnEnemy(1, 0));

        yield return new WaitForSeconds(1);

        StartCoroutine(helper.spawnEnemy(1, 4));

        yield return new WaitForSeconds(1);

        StartCoroutine(helper.spawnEnemy(1, 8));

        yield return new WaitForSeconds(1);

        StartCoroutine(helper.spawnEnemy(1, 12));

        yield return new WaitForSeconds(1);
        while(helper.enemiesOnField()) {
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(helper.spawnEnemy(1, 15));
        StartCoroutine(helper.spawnEnemy(1, 0));
        StartCoroutine(helper.spawnEnemy(1, 1));

        yield return new WaitForSeconds(1);
        while(helper.enemiesOnField()) {
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(helper.spawnEnemy(1, 7));
        StartCoroutine(helper.spawnEnemy(1, 8));
        StartCoroutine(helper.spawnEnemy(1, 9));

        yield return new WaitForSeconds(1);
        while(helper.enemiesOnField()) {
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(helper.spawnEnemy(1, 2));
        StartCoroutine(helper.spawnEnemy(1, 3));
        StartCoroutine(helper.spawnEnemy(1, 4));
        StartCoroutine(helper.spawnEnemy(1, 5));
        StartCoroutine(helper.spawnEnemy(1, 6));

        yield return new WaitForSeconds(2);

        StartCoroutine(helper.spawnEnemy(1, 10));
        StartCoroutine(helper.spawnEnemy(1, 11));
        StartCoroutine(helper.spawnEnemy(1, 12));
        StartCoroutine(helper.spawnEnemy(1, 13));
        StartCoroutine(helper.spawnEnemy(1, 14));

        yield return new WaitForSeconds(1);
        while(helper.enemiesOnField()) {
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(helper.spawnEnemy(1, 3));
        StartCoroutine(helper.spawnEnemy(1, 4));
        StartCoroutine(helper.spawnEnemy(1, 5));

        StartCoroutine(helper.spawnEnemy(2, 12));

        yield return new WaitForSeconds(1);
        while(helper.enemiesOnField()) {
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(helper.spawnEnemy(1, 15));
        StartCoroutine(helper.spawnEnemy(1, 0));
        StartCoroutine(helper.spawnEnemy(1, 1));

        StartCoroutine(helper.spawnEnemy(2, 12));
        StartCoroutine(helper.spawnEnemy(2, 4));

        yield return new WaitForSeconds(1);
        while(helper.enemiesOnField()) {
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(helper.spawnEnemy(1, 15));
        StartCoroutine(helper.spawnEnemy(1, 0));
        StartCoroutine(helper.spawnEnemy(1, 1));

        StartCoroutine(helper.spawnEnemy(3, 7));
        StartCoroutine(helper.spawnEnemy(3, 9));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
