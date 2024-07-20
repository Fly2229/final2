using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    [SerializeField] private Transform player; // El jugador al que seguir� la c�mara
    void Update()
    {
        if (player != null)
        {
            // Solo actualiza la posici�n X de la c�mara para seguir al jugador
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}