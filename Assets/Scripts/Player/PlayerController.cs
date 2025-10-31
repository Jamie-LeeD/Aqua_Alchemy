
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    [Header("Shooting")]
    public GameObject projectilePrefab;
    public float shootCooldown = 0.3f;
    public float projectileSpawnOffset = 0.5f;

    private Vector2 facingDirection = Vector2.down;
    private float shootTimer;

    // cached components
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (rb == null) Debug.LogWarning("PlayerController: No Rigidbody2D found on the player.");
        if (animator == null) Debug.LogWarning("PlayerController: No Animator found on the player.");
    }

    private void Update()
    {
        Vector2 dir = Vector2.zero;

        // Horizontal
        if (Input.GetKey(KeyCode.A))
        {
            facingDirection = Vector2.left;
            dir.x = -1;
            if (animator != null) animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            facingDirection = Vector2.right;
            dir.x = 1;
            if (animator != null) animator.SetInteger("Direction", 2);
        }

        // Vertical
        if (Input.GetKey(KeyCode.W))
        {
            facingDirection = Vector2.up;
            dir.y = 1;
            if (animator != null) animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            facingDirection = Vector2.down;
            dir.y = -1;
            if (animator != null) animator.SetInteger("Direction", 0);
        }

        // Normalize for consistent diagonal speed
        if (dir != Vector2.zero) dir.Normalize();

        if (animator != null) animator.SetBool("IsMoving", dir.sqrMagnitude > 0f);

        // Movement: set Rigidbody2D.velocity (not linearVelocity)
        if (rb != null)
        {
            rb.linearVelocity = dir * speed;
        }
        else
        {
            // fallback: Move with transform (not recommended for physics)
            transform.position += (Vector3)(dir * speed * Time.deltaTime);
        }

        // Shooting
        shootTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootCooldown;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
    }

    void Shoot()
    {
        if (projectilePrefab == null)
        {
            Debug.LogWarning("PlayerController: projectilePrefab is not assigned.");
            return;
        }

        // Spawn projectile slightly in front of player
        Vector3 spawnPos = transform.position + (Vector3)(facingDirection * projectileSpawnOffset);
        GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        // Set direction (ensure prefab has a Projectile component)
        Projectile projectile = proj.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.SetDirection(facingDirection);
        }
        else
        {
            Debug.LogWarning("Spawned projectile has no Projectile script attached.");
        }
    }

}

