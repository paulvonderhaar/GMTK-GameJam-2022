using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    private GameObject whiteEnemyPrefab;

    [SerializeField]
    private GameObject blueEnemyPrefab;

    [SerializeField]
    private GameObject redEnemyPrefab;

    [SerializeField]
    private float spawnInterval = 3.5f;

    private float offCameraDistanceV = 6f;
    private float offCameraDistanceH = 11f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnWave1(spawnInterval));
    }

    private IEnumerator spawnWave1(float interval = 0f) {
        yield return new WaitForSeconds(interval);

        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 0));

        yield return new WaitForSeconds(1);

        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 4));

        yield return new WaitForSeconds(1);

        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 8));

        yield return new WaitForSeconds(1);

        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 12));

        yield return new WaitForSeconds(1);
        while(enemiesOnField()) {
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 15));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 0));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 1));

        yield return new WaitForSeconds(1);
        while(enemiesOnField()) {
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 7));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 8));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 9));

        yield return new WaitForSeconds(1);
        while(enemiesOnField()) {
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 2));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 3));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 4));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 5));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 6));

        yield return new WaitForSeconds(2);

        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 10));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 11));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 12));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 13));
        StartCoroutine(spawnEnemy(whiteEnemyPrefab, 14));
    }

    private Vector3 spawnPosition(int direction) {
      Vector3 pos = player.position;

      switch(direction)
      {
        case 0:
          pos.y = pos.y + offCameraDistanceV;
          break;
        case 1:
          pos.x = pos.x + offCameraDistanceH/2f;
          pos.y = pos.y + offCameraDistanceV;
          break;
        case 2:
          pos.x = pos.x + offCameraDistanceH;
          pos.y = pos.y + offCameraDistanceV;
          break;
        case 3:
          pos.x = pos.x + offCameraDistanceH;
          pos.y = pos.y + offCameraDistanceV/2f;
          break;
        case 4:
          pos.x = pos.x + offCameraDistanceH;
          break;
        case 5:
          pos.x = pos.x + offCameraDistanceH;
          pos.y = pos.y - offCameraDistanceV/2f;
          break;
        case 6:
          pos.x = pos.x + offCameraDistanceH;
          pos.y = pos.y - offCameraDistanceV;
          break;
        case 7:
          pos.x = pos.x + offCameraDistanceH/2f;
          pos.y = pos.y - offCameraDistanceV;
          break;
        case 8:
          pos.y = pos.y - offCameraDistanceV;
          break;
        case 9:
          pos.x = pos.x - offCameraDistanceH/2f;
          pos.y = pos.y - offCameraDistanceV;
          break;
        case 10:
          pos.x = pos.x - offCameraDistanceH;
          pos.y = pos.y - offCameraDistanceV;
          break;
        case 11:
          pos.x = pos.x - offCameraDistanceH;
          pos.y = pos.y - offCameraDistanceV/2f;
          break;
        case 12:
          pos.x = pos.x - offCameraDistanceH;
          break;
        case 13:
          pos.x = pos.x - offCameraDistanceH;
          pos.y = pos.y + offCameraDistanceV/2f;
          break;
        case 14:
          pos.x = pos.x - offCameraDistanceH;
          pos.y = pos.y + offCameraDistanceV;
          break;
        case 15:
          pos.x = pos.x - offCameraDistanceH/2f;
          pos.y = pos.y + offCameraDistanceV;
          break;

        default:
          // code block
          break;
      }

        return pos;
    }

    private IEnumerator spawnEnemy(GameObject enemy, int position, float interval = 0f) {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, spawnPosition(position), Quaternion.identity);
    }

    private IEnumerator spawnEnemy(GameObject enemy, Vector3 coordinate, float interval = 0f) {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, coordinate, Quaternion.identity);
    }

    private bool enemiesOnField() {
      GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
      return enemies.Length > 0;
    }

    // private IEnumerator spawnEnemy(float interval, GameObject enemy)
    // {
    //     yield return new WaitForSeconds(interval);
    //     GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), -1), Quaternion.identity);
    //     StartCoroutine(spawnEnemy(interval, enemy));
    // }

    // Update is called once per frame
    void Update()
    {

    }
}
