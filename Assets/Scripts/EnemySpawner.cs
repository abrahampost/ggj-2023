using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawn_rate;

    // private GameObject[] enemies;
    public int max_enemies;
    private int current_enemies = 0;

    private IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        coroutine = WaitAndSpawn(spawn_rate);
        StartCoroutine(coroutine);
    }

    private GameObject InstantiateObject(GameObject gameObject) 
    {
        GameObject newObject = Instantiate(gameObject, transform.position, transform.rotation);
        return newObject;
    }

    private IEnumerator WaitAndSpawn(float spawn_rate) 
    {
        while (true) {
            yield return new WaitForSeconds(spawn_rate);
            if (current_enemies < max_enemies) {
                GameObject newEnemy = InstantiateObject(enemy);
                // newEnemy.OnDestroy(() => {
                //     Debug.Log("dead");
                // });
                current_enemies += 1;
            }
        }
    }
}
