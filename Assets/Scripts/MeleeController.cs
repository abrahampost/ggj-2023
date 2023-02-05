using System;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [HideInInspector]
    public float meleeSpeed = 1.0f;
    [HideInInspector]
    public float damage = 10.0f;
    private GameObject player;
    private HashSet<int> enemiesDamaged = new HashSet<int>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var animationController = player.GetComponent<AnimationController>();

        gameObject.transform.SetParent(player.transform);
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<BoxCollider2D>().size = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().size * 3;

        animationController.AttackAnimation(meleeSpeed);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var enemyController = collision.gameObject.GetComponent<EnemyController>();
            if (!enemiesDamaged.Contains(collision.gameObject.GetInstanceID()))
            {
                enemiesDamaged.Add(collision.gameObject.GetInstanceID());
                enemyController.TakeDamage(damage);
                var knockbackVector = collision.gameObject.transform.position - player.transform.position;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = knockbackVector.normalized * 3;
            }
        }
    }
}
