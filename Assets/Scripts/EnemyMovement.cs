using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField, Range(1,10)]private float moveSpeed = 2f;
    [SerializeField]private Transform pointA; 
    [SerializeField]private Transform pointB; 

    private Vector3 targetPosition; 
    private Rigidbody2D rb; 
    private float distanceThreshold;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        targetPosition = pointA.position;

        distanceThreshold = moveSpeed * Time.fixedDeltaTime * 2;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (targetPosition - transform.position).normalized;

        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (Vector3.Distance(transform.position, targetPosition) < distanceThreshold)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destruir el jugador
        }
    }

    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }
}