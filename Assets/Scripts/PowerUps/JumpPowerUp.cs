public class JumpPowerUp : PowerUp
{

    public float jumpMultiplier = 2f;

    protected override void ApplyPowerUp(PlayerMovement player)
    {
        player.IncreaseJumpForce(jumpMultiplier);
    }

    protected override void RemovePowerUp(PlayerMovement player)
    {
        player.ResetJumpForce();
    }
}