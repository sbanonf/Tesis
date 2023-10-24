using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PC : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator _anim;

    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Detectar entrada móvil
        if (Application.isMobilePlatform)
        {
            ProcessMobileInput();
        }
        else
        {
            // Control en PC
            moveInput = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        ProcessMovement();
    }

    void ProcessMobileInput()
    {
        // Implementa tus funciones de movimiento móvil aquí
        // Por ejemplo, puedes llamar a MoveRight, MoveLeft o StopMoving según la entrada táctil
    }

    void ProcessMovement()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0 && rb.velocity.y <= 0 && isGround)
        {
            _anim.SetBool("Jump", false);
            _anim.SetBool("Idle", true);
        }
        else if (rb.velocity.y <= 0 && rb.velocity.x != 0 && isGround)
        {
            _anim.SetBool("Jump", false);
            _anim.SetBool("Idle", false);
        }

        if (facingRight && moveInput < 0)
        {
            Flip();
        }
        else if (!facingRight && moveInput > 0)
        {
            Flip();
        }
    }

    public void MoveRight()
    {
        moveInput = 1f;
        Debug.Log("Hola me muevo");
    }

    public void MoveLeft()
    {
        moveInput = -1f;
        Debug.Log("Hola me muevo");
    }

    public void StopMoving()
    {
        moveInput = 0f;
    }

    public void Jump()
    {
        if (isGround || extraJumps > 0)
        {
            _anim.SetBool("Idle", false);
            _anim.SetBool("Jump", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
