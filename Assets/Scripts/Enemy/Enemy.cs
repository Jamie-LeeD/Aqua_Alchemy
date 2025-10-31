using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int health = 20;
    public float attackRange = 6f;          // how far it can shoot
    public float shootCooldown = 1.5f;      // time between shots

    [Header("Projectile Settings")]
    public GameObject projectilePrefab;     // assign in Inspector
    public float projectileSpawnOffset = 0.5f;

    private Transform player;
    private float shootTimer;

    private void Start()
    {
        // Find the player in the scene by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    private void Update()
    {
        if (player == null) return;

        shootTimer -= Time.deltaTime;

        // Face the player (optional)
        Vector2 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (distance <= attackRange && shootTimer <= 0f)
        {
            Shoot(direction);
            shootTimer = shootCooldown;
        }
    }

    void Shoot(Vector2 dir)
    {
        if (projectilePrefab == null)
        {
            Debug.LogWarning($"{name}: No projectile prefab assigned!");
            return;
        }

        // Spawn slightly in front of enemy
        Vector3 spawnPos = transform.position + (Vector3)(dir.normalized * projectileSpawnOffset);
        GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        // Make sure the projectile moves in the direction of the player
        Projectile projectile = proj.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.SetDirection(dir);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{name} took {damage} damage! Remaining: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(name + " died!");
        Destroy(gameObject);
    }
}
