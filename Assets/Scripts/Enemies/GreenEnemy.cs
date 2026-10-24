using UnityEngine;

// GreenEnemy class inherits from EnemyBase and sets the enemyColor to Green in the Start method
public class GreenEnemy : EnemyBase
{
    //Override the Start method to set the enemyColor to Green
    protected override void Start()
    {
        // Set the enemyColor to Green
        enemyColor = ColorState.Green;

        // Call the Start() method in the parent class (EnemyBase)
        base.Start();
    }
}
