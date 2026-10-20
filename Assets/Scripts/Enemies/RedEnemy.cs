using UnityEngine;

public class RedEnemy : EnemyBase
{
    protected override void Start()
    {
        enemyColor = ColorState.Red;
        base.Start();
    }
}
