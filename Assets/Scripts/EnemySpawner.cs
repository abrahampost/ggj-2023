using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Spawn settings
    public GameObject enemy;
    public float spawnRate;

    // Track enemies spawned
    public int enemyCapacity;
    private int spawnedCount = 0;
    public int maxEnemies;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private IEnumerator coroutine;

    // Enemy stats
    public float health = 10.0f;
    public float damage = 2.0f;

    public Color color;


    // Start is called before the first frame update
    private void Start()
    {
        ScaleLevel();

        coroutine = WaitAndSpawn(spawnRate);
        StartCoroutine(coroutine);
    }

    private void ScaleLevel()
    {
        GameObject gameState = GameObject.Find("GameState");
        int levelsCompleted = gameState.GetComponent<GameState>().levelsCompleted;
        maxEnemies = levelsCompleted / 3 + 1;
    }

    private void Update()
    {
        for (int i=0; i < spawnedEnemies.Count; i++) {
            if (spawnedEnemies[i] == null) {
                spawnedEnemies.RemoveAt(i);
            }
        }
    }

    private GameObject InstantiateObject(GameObject gameObject) 
    {
        GameObject newObject = Instantiate(gameObject, transform.position, transform.rotation);
        return newObject;
    }

    private IEnumerator WaitAndSpawn(float spawnRate) 
    {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            if ((enemyCapacity == 0 || spawnedCount < enemyCapacity)
                && spawnedEnemies.Count < maxEnemies) {

                GameObject newEnemy = InstantiateObject(enemy);
                newEnemy.GetComponent<EnemyController>().health = health;
                newEnemy.GetComponent<EnemyController>().damage = damage;
                newEnemy.GetComponentInChildren<SpriteRenderer>().color = color;
                spawnedEnemies.Add(newEnemy);
                spawnedCount++;
            }
        }
    }
}
