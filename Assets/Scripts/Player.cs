using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
 
    public AudioSource audioData;
    
    [SerializeField]
    private Rigidbody2D myBody;
    private SpriteRenderer spriteRenderer; 
    private Animator animator;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private bool isGrounded = true;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    { 
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    private void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw( "Horizontal" );
        transform.position += new Vector3( movementX, 0f, 0f ) * moveForce * Time.deltaTime;
    }

    private void AnimatePlayer()
    {
        float movementY = Input.GetAxisRaw( "Vertical" );

        if( movementX == 1 )
        {
            animator.SetBool( WALK_ANIMATION, false );
            spriteRenderer.flipX = false;
        }

        if( movementX == -1 )
        {
            animator.SetBool( WALK_ANIMATION, false );
            spriteRenderer.flipX = true;
        }

        if( movementX == 0 )
        {
          animator.SetBool( WALK_ANIMATION, true );
        }
    }

    private void PlayerJump()
    {
        if(Input.GetButtonDown( "Jump" ) && isGrounded )
        {
            myBody.AddForce( new Vector2( 0f, jumpForce ), ForceMode2D.Impulse );
            isGrounded = false ;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if( other.gameObject.CompareTag( GROUND_TAG ) )
        {
            isGrounded = true;    
        }

        if(other.gameObject.CompareTag( ENEMY_TAG ) )
        {
            Object.Destroy( gameObject );
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.CompareTag( ENEMY_TAG ) )
        {
            audioData.Play();
            transform.localScale = new Vector3( 0f, 0f, 0f );
            Destroy( gameObject, audioData.clip.length );
        }
    }
}
