using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private float duration; // Duración del power-up
    private Collider2D c2D; // Referencia al Collider2D del power-up
    private SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer del power-up

    protected abstract void ApplyPowerUp(PlayerMovement player);
    protected abstract void RemovePowerUp(PlayerMovement player);

    private void Start()
    {
        c2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                ApplyPowerUp(player);

                // Desactivar visualmente el power-up
                if (c2D != null) c2D.enabled = false;
                if (spriteRenderer != null) spriteRenderer.enabled = false;

                StartCoroutine(RemoveAfterDuration(player));
            }
        }
    }

    private IEnumerator RemoveAfterDuration(PlayerMovement player)
    {
        yield return new WaitForSeconds(duration);

        RemovePowerUp(player); // Quitar el poder del jugador
        Destroy(gameObject); // Destruir el objeto del power-up
    }
}