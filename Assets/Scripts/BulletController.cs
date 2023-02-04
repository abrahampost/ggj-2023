using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5.0f;
    public float secondsAlive = 5.0f;
    public float startingDistance = .2f;

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
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg));
        //transform.rotation.SetLookRotation(new Vector3(0, 0, Mathf.Atan2(velocity.y, velocity.x)));
        //transform.Rotate(new Vector3(0, 0, Mathf.Atan2(velocity.y, velocity.x)));
        //transform.rotation = Quaternion.LookRotation(Vector3.up);


        Destroy(gameObject, secondsAlive);
    }


    void FixedUpdate()
    {
        rb.velocity = velocity * Time.deltaTime * 100 * speed;
        //transform.Rotate(new Vector3(0, 0, Mathf.Atan2(velocity.y, velocity.x)));
        //transform.rotation.SetLookRotation(new Vector3(0, 0, Mathf.Atan2(velocity.y, velocity.x)));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
