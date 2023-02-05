using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawn_rate;

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
            InstantiateObject(enemy);
        }
    }
}
