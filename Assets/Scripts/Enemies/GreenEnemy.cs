using UnityEngine;

public class GreenEnemy : EnemyBase
{
    protected override void Start()
    {
        enemyColor = ColorState.Green;
        base.Start();
    }
}
