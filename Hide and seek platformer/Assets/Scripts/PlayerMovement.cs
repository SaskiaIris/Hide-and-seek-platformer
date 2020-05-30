using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {
    public static PlayerMovement instance;
	public float speed = 8f;
	public Animator playerAnimator;
	public float m_JumpForce = 14f;
	public float m_MovementSmoothing = .05f;

    public bool isDark;

	private float movement;
    private float climb;

	private Vector2 targetVelocity;
	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;

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

    // Start is called before the first frame update
    void Start() {
        if(instance == null) {
            instance = this;
        }

        m_Rigidbody2D = GetComponent<Rigidbody2D>();

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

        if (jump && jumpCounter < 2 && !isOnStairs) {
            m_Rigidbody2D.velocity = new Vector2(0f, m_JumpForce);
            isJumping = true;
            isFalling = false;

            if (jumpCounter == 1)
            {
                GameValues.InsertDoubleJumpLevel(GameValues.CurrentLevel, 1);
            }

            jumpCounter++;

            
        }

        if(jumpCounter > 1 && m_Rigidbody2D.velocity.y < 0) {
            isFalling = true;
            isJumping = false;
        }

        if((climb > 0f || climb < 0f) && !isJumping && !isFalling && !isDucking) {
            if(isOnStairs) {
                isClimbing = true;
            }
        }

        if(crouch && !isJumping && !isFalling && !isClimbing) {
            isDucking = !isDucking;
        }

        if(isClimbing) {
            targetVelocity = new Vector2(m_Rigidbody2D.velocity.x, climb * speed);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        targetVelocity = new Vector2(movement * speed, m_Rigidbody2D.velocity.y);
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (isClimbing) {
            m_Rigidbody2D.gravityScale = 0f;
        }
        else {
            m_Rigidbody2D.gravityScale = 3f;
        }

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
		m_FacingRight = !m_FacingRight;
		transform.Rotate(0f, 180f, 0f);
	}

	private void GetDamage() {
		GameValues.HealthPoints -= 5;
		GameValues.HealthLostTotal += 5;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Playground") || other.gameObject.CompareTag("DarkPlayground")) {
        	isFalling = false;
        	isJumping = false;
            jumpCounter = 0;
        }

        if(other.gameObject.CompareTag("Light Enemy") && !isDark) {
            isHurt = true;
			GetDamage();
        }

		if(other.gameObject.CompareTag("Dark Enemy") && isDark) {
			isHurt = true;
			GetDamage();
		}

		if(other.gameObject.CompareTag("CheckEyeOpp")) {
            EyeManager.instance.isInCollision = true;
        }

        if(other.gameObject.CompareTag("Stairs")) {
            isOnStairs = true;
        }
	}

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Playground") || other.gameObject.CompareTag("DarkPlayground")) {
            if(!isJumping && !isClimbing) {
                isFalling = true;
            }
        }

		if(other.gameObject.CompareTag("Light Enemy") && !isDark) {
			isHurt = false;
		}

		if(other.gameObject.CompareTag("Dark Enemy") && isDark) {
			isHurt = false;
		}

		if(other.gameObject.CompareTag("CheckEyeOpp")) {
            EyeManager.instance.isInCollision = false;
        }

        if (other.gameObject.CompareTag("Stairs")) {
            isOnStairs = false;
            isClimbing = false;
        }
    }
}