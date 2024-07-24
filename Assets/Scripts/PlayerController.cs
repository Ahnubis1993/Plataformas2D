using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    [Header("Movimientos")]
    public float moveSpeed;

    [Header("Salto")]
    public float jumpForce;
    private bool canDoubleJump;
    public float bounceForce;

    [Header("Componentes")]
    public Rigidbody2D theRB;

    [Header("Grounded")]
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    private bool isGrounded;
    public float knockBackLenght, knockBackForce;
    private float knockBackCounter;

    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer theSR;

    [Header("Detener Movimiento Jugador")]
    public bool stopInput;

    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!PostMenu.instance.isPaused && !stopInput)
        {
            if (knockBackCounter <= 0)
            {
                theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

                isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);

                if (isGrounded)
                {
                    canDoubleJump = true;
                }

                if (Input.GetButtonDown("Jump"))
                {

                    if (isGrounded)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        AudioManager.instance.PlaySFX(10);
                    }
                    else
                    {
                        if (canDoubleJump)
                        {
                            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                            AudioManager.instance.PlaySFX(10);
                            canDoubleJump = false;
                        }
                    }
                }

                if (theRB.velocity.x < 0)
                {
                    theSR.flipX = true;
                }
                else if (theRB.velocity.x > 0)
                {
                    theSR.flipX = false;
                }

            }
            else
            {
                knockBackCounter -= Time.deltaTime;
                if (!theSR.flipX)
                {

                    theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
                }
                else
                {
                    theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
                }
            }
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLenght;
        theRB.velocity = new Vector2(0f, knockBackForce);
    }

    public void Bounce()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
    }

}
