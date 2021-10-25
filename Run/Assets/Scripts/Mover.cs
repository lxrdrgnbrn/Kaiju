using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private UnityEvent onSpawn;
    private Rigidbody2D _rb;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Check"))
        {
            onSpawn.Invoke();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.left * speed;
    }
}
