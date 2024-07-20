using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyPiranha : MonoBehaviour
{
    public float moveDistance = 2f; // Distancia que el enemigo se moverá hacia arriba y hacia abajo
    public float waitTime = 1f; // Tiempo que el enemigo esperará antes de subir o bajar
    public float moveSpeed = 1f; // Velocidad de movimiento vertical del enemigo
    public float distanceThreshold = 0.1f; // Umbral de distancia para detener el movimiento

    private Vector3 initialPosition; // Posición inicial del enemigo
    private Vector3 targetPosition; // Posición objetivo hacia donde se moverá
    private Rigidbody2D rb; // Referencia al Rigidbody2D del enemigo

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        StartCoroutine(MoveUpAndDown());
    }

    private IEnumerator MoveUpAndDown()
    {
        while (true)
        {
            // Calcular la posición objetivo basada en si se está moviendo hacia arriba o hacia abajo
            if (transform.position.y >= initialPosition.y + moveDistance)
            {
                targetPosition = initialPosition;
            }
            else if (transform.position.y <= initialPosition.y)
            {
                targetPosition = initialPosition + new Vector3(0, moveDistance, 0);
            }

            // Mover gradualmente hacia la posición objetivo
            while (Vector3.Distance(transform.position, targetPosition) > distanceThreshold)
            {
                Vector3 direction = (targetPosition - transform.position).normalized;
                rb.velocity = direction * moveSpeed;
                yield return null;
            }

            // Asegurarse de que el objeto esté exactamente en la posición objetivo
            rb.velocity = Vector2.zero;
            transform.position = targetPosition;

            // Esperar antes de cambiar de dirección
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destruir el jugador
        }
    }

}