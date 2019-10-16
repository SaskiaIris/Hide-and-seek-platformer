using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeManager : MonoBehaviour
{
	private bool EyesClosed;
	private Renderer darkness;
	private Renderer darkForeground;
	private Renderer darkPlayground;
	private Renderer darkBackground;
	private Renderer removeObstacleWhenDark;
	private Collider2D collisionOnWhenDark;
	private Collider2D collisionRemoveWhenDark;

    // Start is called before the first frame update
    void Start()
    {
        EyesClosed = false;
        darkness = GameObject.FindWithTag("Darkness").GetComponent<Renderer>();

        darkForeground = GameObject.FindWithTag("DarkForeground").GetComponent<Renderer>();
        darkPlayground = GameObject.FindWithTag("DarkPlayground").GetComponent<Renderer>();
        darkBackground = GameObject.FindWithTag("DarkBackground").GetComponent<Renderer>();

        collisionOnWhenDark = GameObject.FindWithTag("DarkPlayground").GetComponent<Collider2D>();

        removeObstacleWhenDark = GameObject.FindWithTag("RemovablePlayground").GetComponent<Renderer>();
        collisionRemoveWhenDark = GameObject.FindWithTag("RemovablePlayground").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	
        if(Input.GetButtonDown("Eyes")) {
        	EyesClosed = !EyesClosed;
        	print("ogen: " + EyesClosed);
        }
    }

    void FixedUpdate() {
    	if(EyesClosed) {
    		darkness.sortingOrder = 10;
    		darkness.enabled = true;

    		darkForeground.enabled = true;
    		darkPlayground.enabled = true;
    		darkBackground.enabled = true;

    		collisionOnWhenDark.enabled = true;

    		removeObstacleWhenDark.enabled = false;
    		collisionRemoveWhenDark.enabled = false;
    	} else {
    		darkness.sortingOrder = -10;
    		darkness.enabled = false;

    		darkForeground.enabled = false;
    		darkPlayground.enabled = false;
    		darkBackground.enabled = false;

    		collisionOnWhenDark.enabled = false;

    		removeObstacleWhenDark.enabled = true;
    		collisionRemoveWhenDark.enabled = true;
    	}
    }
}
