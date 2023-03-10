using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [HideInInspector]
    public float damage = 10.0f;
    [HideInInspector]
    public float speedAffect = .5f;
    private Rigidbody2D rb;
    public GameObject parent;
    private bool dealtDamage = false;

    public float hitboxRatio = 1.0f;

    void Start()
    {
        rb = parent.GetComponent<Rigidbody2D>();
        gameObject.transform.SetParent(rb.transform);
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<BoxCollider2D>().size = parent.GetComponent<BoxCollider2D>().size * hitboxRatio;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !dealtDamage)
        {
            var statsController = collision.gameObject.GetComponentInChildren<StatsController>();
            statsController.TakeDamage(damage);
            dealtDamage = true;
        }
        if (collision.gameObject.tag == "Tree" && !dealtDamage)
        {
            var treeController = collision.gameObject.GetComponent<TreeController>();
            treeController.TakeDamage(damage);
            dealtDamage = true;
        }
    }
}
