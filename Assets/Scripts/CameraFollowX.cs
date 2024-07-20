using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    [SerializeField] private Transform player; // El jugador al que seguirá la cámara
    void Update()
    {
        if (player != null)
        {
            // Solo actualiza la posición X de la cámara para seguir al jugador
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}