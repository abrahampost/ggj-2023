using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnRate;

    // private GameObject[] enemies;
    public int maxEnemies;
    // private int current_enemies = 0;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private IEnumerator coroutine;


    // Start is called before the first frame update
    private void Start()
    {
        coroutine = WaitAndSpawn(spawnRate);
        StartCoroutine(coroutine);
    }

    private void Update()
    {
        for (int i=0; i < spawnedEnemies.Count; i++) {
            // Debug.Log(spawnedEnemies[i].GetComponent<EnemyController>().Bark());
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
            if (spawnedEnemies.Count < maxEnemies) {
                GameObject newEnemy = InstantiateObject(enemy);
                spawnedEnemies.Add(newEnemy);
            }
        }
    }
}
