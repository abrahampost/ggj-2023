using System;
using System.Threading.Tasks;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    [HideInInspector]
    public float speed = 5.0f;
    [HideInInspector]
    public float startingDistance = .2f;
    [HideInInspector]
    public float damage = 10.0f;
    [HideInInspector]
    public float speedAffect = .5f;

    private Rigidbody2D rb;
    private Vector3 velocity;

    private ProjectileSoundController soundController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundController = GameObject.FindFirstObjectByType<ProjectileSoundController>();

        soundController.PlayProjectileLaunch();

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        var mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        var angle = mousePosition - GameObject.FindGameObjectWithTag("Player").transform.position;
        velocity = new Vector2(angle.x, angle.y).normalized;

        transform.position = transform.position + velocity * startingDistance;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg));
    }

    void FixedUpdate()
    {
        rb.velocity = velocity * Time.deltaTime * 100 * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().decreaseHealth(damage);
            Destroy(gameObject);
        }
    }
}
