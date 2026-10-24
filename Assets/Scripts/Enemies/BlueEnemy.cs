using UnityEngine;

// BlueEnemy class inherits from EnemyBase and sets the enemyColor to Blue in the Start method
public class BlueEnemy : EnemyBase
{
    //Override the Start method to set the enemyColor to Blue
    protected override void Start()
    {
        // Set the enemyColor to Blue
        enemyColor = ColorState.Blue;

        // Call the Start() method in the parent class (EnemyBase)
        base.Start();
    }
}
