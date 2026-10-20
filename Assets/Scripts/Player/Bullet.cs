using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    private ColorState bulletColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed *  Time.deltaTime);
    }

    public void SetColor(ColorState state)
    {
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

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(bulletColor);
            Destroy(gameObject);
        }
    }
}
