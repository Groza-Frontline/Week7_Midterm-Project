using UnityEngine;

// Interface for damageable objects, which defines a method to take damage based on the color of the bullet
public interface IDamageable
{
    // Method to apply damage to the object based on the color of the bullet
    void TakeDamage(ColorState bulletColor);
}
