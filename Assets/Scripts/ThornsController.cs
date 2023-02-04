using System;
using System.Collections.Generic;
using UnityEngine;

public class ThornsController : MonoBehaviour
{
    [HideInInspector]
    public float secondsAlive = 1.0f;
    [HideInInspector]
    public float minDistance = .4f;
    [HideInInspector]
    public float maxDistance = 2f;

    private Rigidbody2D rb;
    private Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        var mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        var angle = mousePosition - GameObject.FindGameObjectWithTag("Player").transform.position;
        velocity = new Vector2(angle.x, angle.y);
        if (velocity.magnitude > minDistance && velocity.magnitude < maxDistance)
        {
            transform.position = transform.position + velocity;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg));
            Destroy(gameObject, secondsAlive);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
