using UnityEngine;

// This is the base class for all enemy types in the game. It handles movement towards the player, taking damage, and updating the enemy's color based on its ColorState
// Implemets the IDamageable interface to allow the enemy to take damage from bullets of matching color
public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    // Reference to the player's Transform component for movement towards the player
    protected Transform player;

    // Speed of the enemy's movement towards the player
    public float moveSpeed = 2f;

    // Stores the enemy's assigned color state (Red, Blue, or Green)
    public ColorState enemyColor;


    // Reference to the Renderer component
    protected Renderer rend;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // Find the player GameObject with the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the Renderer component attached to this GameObject
        rend = GetComponent<Renderer>();

        // Call the UpdateColor method
        UpdateColor();
    }

    protected virtual void Update()
    {
        // Call the MoveToPlayer method to move the enemy towards the player
        MoveToPlayer();
    }

    // Moves the enemy towards the player's position at a constant speed
    void MoveToPlayer()
    {

        if (player == null) return;

        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, player.position) < 0.2f)
        {
            // If the enemy is close enough to the player, trigger the Game Over state in the GameManager
            GameManager.Instance.GameOver();
        }
    }

    // Implement TakeDamege method from IDamageable interface
    public virtual void TakeDamage(ColorState bulletColor)
    {
        // If the bullet's color matches the enemy's color, destroy the enemy GameObject
        if (bulletColor == enemyColor)
        {
            Destroy(gameObject);
        }
    }

    // Updates the enemy's color based on its ColorState
    protected void UpdateColor()
    {
        switch (enemyColor)
        {
            case ColorState.Red:
                rend.material.color = Color.red;
                break;

            case ColorState.Blue:
                rend.material.color = Color.blue;
                break;

            case ColorState.Green:
                rend.material.color = Color.green;
                break;
        }
    }
}
