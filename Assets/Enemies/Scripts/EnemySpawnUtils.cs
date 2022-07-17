using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnUtils : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    private GameObject enemyType1;

    [SerializeField]
    private GameObject enemyType2;

    [SerializeField]
    private GameObject enemyType3;

    private GameObject[] enemyTypes;

    private float offCameraDistanceV = 6f;
    private float offCameraDistanceH = 11f;


    // Start is called before the first frame update
    void Start()
    {
      enemyTypes = new GameObject[] {enemyType1, enemyType2, enemyType3};
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject enemyForType(int type) {
      return enemyTypes[type - 1];
    }

    public IEnumerator spawnEnemy(int enemyType, int position, float interval = 0f) {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemyForType(enemyType), spawnPosition(position), Quaternion.identity);
    }

    public IEnumerator spawnEnemy(int enemyType, Vector3 coordinate, float interval = 0f) {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemyForType(enemyType), coordinate, Quaternion.identity);
    }

    public bool enemiesOnField() {
      GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
      return enemies.Length > 0;
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

    public IEnumerator spawnRandomWave(int numBasic, int numAdvanced, float interval = 0f) {
      yield return new WaitForSeconds(interval);

      var positions = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
      shuffle(positions);

        for (int i = 0; i < positions.Length; i++) {
          int pos = positions[i];
          if (numBasic > 0) {
            numBasic--;
            StartCoroutine(spawnEnemy(1, pos));
          }
          else if (numAdvanced > 0) {
            numAdvanced--;
            int type = (Random.value <= 0.5f) ? 2 : 3;
            StartCoroutine(spawnEnemy(type, pos));
          }
          else {
            break;
          }
        }
    }

    void shuffle(int[] nums)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < nums.Length; t++ )
        {
            int tmp = nums[t];
            int r = Random.Range(t, nums.Length);
            nums[t] = nums[r];
            nums[r] = tmp;
        }
    }

}
