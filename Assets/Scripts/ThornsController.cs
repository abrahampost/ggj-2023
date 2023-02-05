using System;
using System.Collections.Generic;
using UnityEngine;

public class ThornsController : MonoBehaviour
{
    [HideInInspector]
    public float distance = 2f;

    [HideInInspector]
    public float damage = 10.0f;
    [HideInInspector]
    public float speedAffect = .5f;
    [HideInInspector]
    public float size = 1f;

    private Vector3 velocity;
    private HashSet<int> enemiesDamaged = new HashSet<int>();

    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        var mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        var angle = mousePosition - GameObject.FindGameObjectWithTag("Player").transform.position;
        velocity = new Vector2(angle.x, angle.y);
        if (velocity.magnitude > distance)
        {
            velocity = velocity.normalized * distance;
        }
        transform.parent.localScale = new Vector3(size, size, size);
        transform.parent.position = transform.parent.position + velocity;
        transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg + 90));
        FindFirstObjectByType<AttackSoundController>().PlaceThorns();
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
            }
            enemyController.ModifySpeedByPercentage(speedAffect);
        }
    }
}
