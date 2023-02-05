using System;
using System.Collections.Generic;
using UnityEngine;

public class ConeOfColdController : MonoBehaviour
{
    [HideInInspector]
    public float startingDistance = .2f;
    [HideInInspector]
    public float damage = 10.0f;
    [HideInInspector]
    public float speedAffect = .5f;

    private Rigidbody2D rb;
    private Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        var mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        var angle = mousePosition - GameObject.FindGameObjectWithTag("Player").transform.position;
        velocity = new Vector2(angle.x, angle.y).normalized;

        transform.position = transform.position + velocity * startingDistance;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var enemyController = collision.gameObject.GetComponent<EnemyController>();
            //enemyController.TakeDamage(damage);
            enemyController.ModifySpeedByPercentageForTime(speedAffect);
        }
    }
}
