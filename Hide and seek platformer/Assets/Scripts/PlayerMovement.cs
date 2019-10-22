using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public static PlayerMovement instance;

    public Animator playerAnimator;
	public float m_JumpForce = 14f;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    public bool isDark;

	private float movement;
    private float climb;

	private Vector2 targetVelocity;
	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;
    private Transform m_Transform;

	private bool m_FacingRight;
	private bool jump;
    private bool crouch;

	private bool isJumping;
	private bool isFalling;
    private bool isClimbing;
    private bool isOnStairs;
    private bool isDucking;
    private bool isHurt;

    private int jumpCounter;

	private Collider2D m_PlayerCollider;

    // Start is called before the first frame update
    void Start() {
        if(instance == null) {
            instance = this;
        }

        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_PlayerCollider = GetComponent<Collider2D>();
        m_Transform = GetComponent<Transform>();

        jumpCounter = 0;

        m_FacingRight = false;
		jump = false;
        crouch = false;

		isJumping = false;
		isFalling = false;
        isClimbing = false;
        isOnStairs = false;
        isDucking = false;
        isHurt = false;
    }

    // Update is called once per frame
    void Update() {
        movement = Input.GetAxis("Horizontal");
        climb = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");
        crouch = Input.GetButtonDown("Crouch");

        //if(isClimbing) {
        //m_Rigidbody2D.gravityScale = 0f;
        //targetVelocity = new Vector2(m_Rigidbody2D.velocity.x, climb * 10f);
        //m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        //} else {
        //m_Rigidbody2D.gravityScale = 3f;
        targetVelocity = new Vector2(movement * 10f, m_Rigidbody2D.velocity.y);
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        //}

        if (jump && jumpCounter < 2) {
            m_Rigidbody2D.velocity = new Vector2(0f, m_JumpForce);
            isJumping = true;
            isFalling = false;
            jumpCounter++;
        }

        if(jumpCounter > 1 && m_Rigidbody2D.velocity.y < 0) {
            isFalling = true;
            isJumping = false;
        }

        if(climb > 0f && !isJumping && !isFalling && !isDucking) {
            if(isOnStairs) {
                isClimbing = true;
            }
            //isDucking = false;
        } else {
            isClimbing = false;
        }

        print("klim: " + isClimbing);

        if(crouch && !isJumping && !isFalling && !isClimbing) {
            isDucking = !isDucking;
        }

        print("klimsnelheid: " + m_Rigidbody2D.velocity.y);

        playerAnimator.SetBool("jump", isJumping);
        playerAnimator.SetFloat("speed", Mathf.Abs(movement));
        playerAnimator.SetBool("fall", isFalling);
        playerAnimator.SetBool("dark", isDark);
        playerAnimator.SetBool("climb", isClimbing);
        playerAnimator.SetBool("duck", isDucking);
        playerAnimator.SetBool("hurt", isHurt);
    }

    void FixedUpdate() {
        if (movement > 0 && m_FacingRight) {
    		Flip();
    	} else if(movement < 0 && !m_FacingRight) {
    		Flip();
    	}
    }

    private void Flip() {
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Playground") || other.gameObject.CompareTag("DarkPlayground")) {
        	isFalling = false;
        	isJumping = false;

        	//print("Staat op de grond!");

            jumpCounter = 0;
        }

        if(other.gameObject.CompareTag("Enemy")) {
            isHurt = true;
        }

        if(other.gameObject.CompareTag("CheckEyeOpp")) {
            EyeManager.instance.isInCollision = true;
        }

        if(other.gameObject.CompareTag("DuckArea")) {
            isDucking = true;
        }

        if(other.gameObject.CompareTag("Stairs")) {
            isOnStairs = true;
        }
	}

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Playground") || other.gameObject.CompareTag("DarkPlayground")) {
            if(!isJumping) {
                isFalling = true;
            }

            //print("Staat NIET op de grond!");
        }

        if(other.gameObject.CompareTag("Enemy")) {
            isHurt = false;
        }

        if(other.gameObject.CompareTag("CheckEyeOpp")) {
            EyeManager.instance.isInCollision = false;
        }

        if (other.gameObject.CompareTag("Stairs")) {
            isOnStairs = false;
        }
    }
}
