using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float movement;
	private Vector2 targetVelocity;
	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;
	private bool m_FacingRight = false;
	private bool jumping = false;
	

	[SerializeField] private float m_JumpForce = 7000f;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        jumping = Input.GetButtonDown("Jump");
    }

    void FixedUpdate() 
    {
    	targetVelocity = new Vector2(movement * 10f, m_Rigidbody2D.velocity.y);	

		// And then smoothing it out and applying it to the character
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    	//m_Rigidbody2D.AddForce(velocity);

		if(jumping) {
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}

    	if(movement > 0 && m_FacingRight) {
    		Flip();
    	} else if(movement < 0 && !m_FacingRight) {
    		Flip();
    	}
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Mushroom")) {
			Destroy(other.gameObject);
		}
	}
}
