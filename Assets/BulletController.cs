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

        Destroy(gameObject, secondsAlive);
    }


    private void FixedUpdate()
    {
        Debug.Log(velocity);
        rb.velocity = velocity * Time.deltaTime * 100 * speed;
    }
}
