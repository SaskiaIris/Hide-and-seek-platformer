using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeManager : MonoBehaviour
{
    public Text warningMessage;

	private bool eyesClosed;
    public bool isInCollision;
	private Renderer darkness;
	private Renderer darkForeground;
	private Renderer darkPlayground;
	private Renderer darkBackground;
	private Renderer removeObstacleWhenDark;
	private Collider2D collisionOnWhenDark;
	private Collider2D collisionRemoveWhenDark;

    public static EyeManager instance;
    

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        eyesClosed = false;
        isInCollision = false;
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
            if(isInCollision) {
            	eyesClosed = !eyesClosed;
            	print("ogen: " + eyesClosed);
            } else {
                warningMessage.text = "You can only close/open your eyes in the appropriate \"G\"-marked zones (press o voor okay)";
            }
        }

        if(Input.GetButtonDown("Okay")) {
            warningMessage.text = "";
        }
    }

    void FixedUpdate() {
    	if(eyesClosed) {
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
