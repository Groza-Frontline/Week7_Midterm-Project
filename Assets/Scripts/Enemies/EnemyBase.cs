using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    protected Transform player;

    public float moveSpeed = 2f;

    public ColorState enemyColor;

    protected Renderer rend;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rend = GetComponent<Renderer>();

        UpdateColor();
    }

    protected virtual void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        if (player == null) return;

        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, player.position) < 0.2f)
        {
            GameManager.Instance.GameOver();
        }
    }

    public virtual void TakeDamage(ColorState bulletColor)
    {
        if(bulletColor == enemyColor)
        {
            Destroy(gameObject);
        }
    }

    protected void UpdateColor()
    {
        switch (enemyColor)
        {
            case ColorState.Red;
                rend.material.color = Color.red;
                break;

            case ColorState.Blue;
                rend.material.color = Color.blue;
                break;

            case ColorState.Green;
                rend.material.color = Color.green;
                break;
        }
    }
}
