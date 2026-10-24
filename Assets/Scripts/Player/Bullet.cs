using UnityEngine;

// This script handles the behavior of a bullet in the game.
public class Bullet : MonoBehaviour
{
    // Speed at which the bullet moves forward
    public float speed = 10f;

    // The color state of the bullet (Red, Blue, or Green)
    private ColorState bulletColor;

    // Reference to the Renderer component for changing the bullet's color
    private Renderer rend;

    // Called when the bullet is first created
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Called to update the bullet's position
    void Update()
    {
        // Move the bullet forward based on its speed and the time elapsed since the last frame
        transform.Translate(Vector3.forward * speed *  Time.deltaTime);
    }

    // Sets the color of the bullet based on the provided ColorState
    public void SetColor(ColorState state)
    {
        // Assign the provided color state to the bullet's color
        bulletColor = state;

        rend = GetComponent<Renderer>();

        switch(state)
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

    // Called when the bullet collides with another collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the other object has a component that implements the IDamageable interface
        IDamageable damageable = other.GetComponent<IDamageable>();

        // If the other collider is damageable, apply damage and destroy the bullet
        if (damageable != null)
        {
            damageable.TakeDamage(bulletColor);
            Destroy(gameObject);
        }
    }
}
