using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;
    public float verticalDashForce = 5f;
    public float detectionRadius = 5f;
    public Sprite hangingSprite;
    public Sprite flyingSprite;
    public Animator animator;

    private bool isDashing = false;
    private float dashTimer = 0f;
    private Rigidbody2D rb;
    private GameObject player;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = hangingSprite;
    }

    private void Update()
    {
        if (!isDashing)
        {
            // Lógica para movimiento normal del enemigo
            if (player != null && Vector2.Distance(transform.position, player.transform.position) <= detectionRadius)
            {
                ChangeSpriteAndAnimate(flyingSprite);
                Vector2 direction = (player.transform.position - transform.position).normalized;
                StartDash(direction);
            }
        }
        else
        {
            if (dashTimer <= 0f)
            {
                isDashing = false;
                rb.velocity = Vector2.zero;
                // Lógica para el comportamiento posterior al dash
            }
            else
            {
                dashTimer -= Time.deltaTime;
            }
        }

        // Flip del sprite según la dirección del movimiento
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void ChangeSpriteAndAnimate(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
        if (animator != null)
        {
            animator.SetBool("isFlying", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aquí puedes implementar la lógica para la muerte del murciélago.
            Destroy(gameObject);
        }
    }

    public void StartDash(Vector2 direction)
    {
        if (!isDashing)
        {
            isDashing = true;
            dashTimer = dashDuration;
            rb.velocity = direction.normalized * dashSpeed;
            rb.AddForce(Vector2.up * verticalDashForce, ForceMode2D.Impulse);
        }
    }
}
