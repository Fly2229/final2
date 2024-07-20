public class SpeedPowerUp : PowerUp
{
    public float speedMultiplier = 2f;

    protected override void ApplyPowerUp(PlayerMovement player)
    {
        player.IncreaseSpeed(speedMultiplier);
    }

    protected override void RemovePowerUp(PlayerMovement player)
    {
        player.ResetSpeed();
    }
}