using UnityEngine;

public class BlueEnemy : EnemyBase
{
    protected override void Start()
    {
        enemyColor = ColorState.Blue;
        base.Start();
    }
}
