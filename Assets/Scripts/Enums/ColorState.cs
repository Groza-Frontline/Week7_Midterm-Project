using UnityEngine;

public class ColorState : MonoBehaviour , ISwitchable
{
    public ColorState currentState;
    public GameObject bulletPrefab;

    public float detectionRange = 10f;
    public float rotationSpeed = 5f;

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
}
