using UnityEngine;

// Class that controls the player behavior, including shooting bullets and switching color states
public class PlayerController : MonoBehaviour, ISwitchable
{
    // Current color state of the player
    public ColorState currentState;

    // Bullet prefab to instantiate when shooting
    public GameObject bulletPrefab;

    // Interval between shots in seconds
    public float shootInterval = 1f;

    // Range within which the player can detect enemies
    public float detectionRange = 10f;

    // Speed at which the player rotates to face the nearest enemy
    public float rotateSpeed = 5f;

    // Timer to track time since the last shot
    private float timer;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateColor();
    }

    void Update()
    {
        // Call the detected and rotate method to find the nearest enemy and rotate towards it
        DetectAndRotate();

        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0;
        }
    }

    // Method to instantiate a bullet and set its color based on the player's current state
    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Bullet bullet = bulletObj.GetComponent<Bullet>();

        bullet.SetColor(currentState);
    }

    // Method to switch the player's color state in a cyclic manner (Red -> Blue -> Green -> Red)
    public void SwitchState()
    {
        currentState++;

        if ((int)currentState > 2)
        {
            currentState = 0;
        }

        UpdateColor();
    }

    // Method to handle mouse click events and switch the player's color state
    private void OnMouseDown()
    {
        SwitchState();
    }

    void UpdateColor()
    {
        switch (currentState)
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

    void DetectAndRotate()
    {
        EnemyBase[] enemies = FindObjectsOfType<EnemyBase>();

        EnemyBase nearest = null;

        float shortestDistance = detectionRange;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearest = enemy;
            }
        }

        if (nearest != null)
        {
            Vector3 dir = nearest.transform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(dir);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
