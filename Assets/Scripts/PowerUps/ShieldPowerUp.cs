using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp :PowerUp
{
    public GameObject shieldPrefab; // Prefab del escudo

    protected override void ApplyPowerUp(PlayerMovement player)
    {
        if (player.currentShield == null) // Si no hay un escudo activo
        {
            GameObject shield = Instantiate(shieldPrefab, player.transform.position, Quaternion.identity, player.transform);
            player.currentShield = shield; // Asignar el escudo al jugador
        }
    }

    protected override void RemovePowerUp(PlayerMovement player)
    {
        if (player.currentShield != null)
        {
            Destroy(player.currentShield);
            player.currentShield = null;
        }
    }
}