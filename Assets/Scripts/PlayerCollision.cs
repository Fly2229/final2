using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private string targetTag = "Finish"; // La etiqueta del objeto con el que se colisionará para ganar
    [SerializeField] private string winSceneName = "Win"; // El nombre de la escena de victoria

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            SceneManager.LoadScene(winSceneName); // Cambiar a la escena de victoria
        }
    }
}