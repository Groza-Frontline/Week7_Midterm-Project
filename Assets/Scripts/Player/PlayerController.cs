using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ColorState currentState;

    public GameObject bulletPrefab;
    public float shootInterval = 1f;

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

    public void SwitchState()
    {
        currentState++;

        if ((int)currentState > 2)
        {
            currentState = 0;
        }

        UpdateColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject Color = 
    }

}
