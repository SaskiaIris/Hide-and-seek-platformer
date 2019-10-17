using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public Animator playerAnimator;
	public float m_JumpForce = 15f;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    public bool isDark;

	private float movement;
	private Vector2 targetVelocity;
	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;
	private bool m_FacingRight;
	private bool jump;
	private bool isJumping;
	private bool isFalling;
    private int jumpCounter;
	private Collider2D m_PlayerCollider;

    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
        }

        jumpCounter = 0;
        m_FacingRight = false;
		jump = false;
		isJumping = false;
		isFalling = false;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_PlayerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");

        if(jump && jumpCounter < 2) {
            //m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            m_Rigidbody2D.velocity = new Vector2(0f, m_JumpForce);
            isJumping = true;
            jumpCounter++;
        } else {
            isJumping = false;
        }

        playerAnimator.SetBool("jump", isJumping);
        playerAnimator.SetFloat("speed", Mathf.Abs(movement));
        playerAnimator.SetBool("fall", isFalling);
        playerAnimator.SetBool("dark", isDark);
    }

    void FixedUpdate() {
        //playerAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        targetVelocity = new Vector2(movement * 10f, m_Rigidbody2D.velocity.y);	

		// And then smoothing it out and applying it to the character
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

    	if(movement > 0 && m_FacingRight) {
    		Flip();
    	} else if(movement < 0 && !m_FacingRight) {
    		Flip();
    	}


        ////////////DEBUG///////////
    	//print("valsnelheid: " + m_Rigidbody2D.velocity.y);
    	print("spring: " + isJumping);
        print("val: " + isFalling);    	
        print("is het donker: " + isDark);
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

        	print("Staat op de grond!");

            jumpCounter = 0;
        }
	}

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Playground") || other.gameObject.CompareTag("DarkPlayground")) {
            if(!isJumping) {
                isFalling = true;
            }

            print("Staat NIET op de grond!");
        }
    }
}
