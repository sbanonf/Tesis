using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_SImple : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private bool facingRigth = true;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Presionas ESPACIO para saltar, y tienes saltos
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            //Rango Vector2.up (y=-1, y=1)
           // AudioManager.instance.Play("Jump");
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps = extraJumpsValue;
        }

        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRigth == false && moveInput > 0)
            Flip();
        else if (facingRigth == true && moveInput < 0)
            Flip();


    }

    //Funcion = serie de comando a ejecutar en una cierta ocasión.
    void Flip()
    {
        facingRigth = !facingRigth;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnDrawGizmosSelected()
    {
        //El objeto central, el rango del circulo
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
