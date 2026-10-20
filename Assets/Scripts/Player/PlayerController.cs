using UnityEngine;

public class PlayerController : MonoBehaviour, ISwitchable
{
    public ColorState currentState;

    public GameObject bulletPrefab;
    public float shootInterval = 1f;

    public float detectionRange = 10f;
    public float rotateSpeed = 5f;

    private float timer;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateColor();
    }

    void Update()
    {
        DetectAndRotate();

        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Bullet bullet = bulletObj.GetComponent<Bullet>();

        bullet.SetColor(currentState);
    }

    public void SwitchState()
    {
        currentState++;

        if ((int)currentState > 2)
        {
            currentState = 0;
        }

        UpdateColor();
    }

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
