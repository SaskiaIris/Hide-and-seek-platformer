using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
	public float Speed = 20f;
	public Rigidbody2D rb;
	// Start is called before the first frame update
	void Start() {
		rb.velocity = transform.right * Speed;
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D hitInfo) {
		if(hitInfo != hitInfo.CompareTag("DuckArea") && hitInfo != hitInfo.CompareTag("Stairs") && hitInfo != hitInfo.CompareTag("CheckEyeOpp") && hitInfo != hitInfo.CompareTag("Player") && hitInfo != hitInfo.CompareTag("Ignore Ammo") && hitInfo != hitInfo.CompareTag("Light Carrot") && hitInfo != hitInfo.CompareTag("Dark Carrot")) {
			if(hitInfo.CompareTag("Light Enemy") && !PlayerMovement.instance.isDark) {
				Destroy(hitInfo.gameObject);
			} else if(hitInfo.CompareTag("Dark Enemy") && PlayerMovement.instance.isDark) {
				Destroy(hitInfo.gameObject);
			}

			Destroy(gameObject);
			Debug.Log(hitInfo.name);
		}
	}
}