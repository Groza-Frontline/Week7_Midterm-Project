using UnityEngine;

// RedEnemy class inherits from EnemyBase and sets the enemyColor to Red in the Start method
public class RedEnemy : EnemyBase
{
    //Override the Start method to set the enemyColor to Red
    protected override void Start()
    {
        // Set the enemyColor to Red
        enemyColor = ColorState.Red;

        // Call the Start() method in the parent class (EnemyBase)
        base.Start();
    }
}
