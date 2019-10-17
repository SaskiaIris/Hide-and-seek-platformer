using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeManager : MonoBehaviour
{
    public Text warningMessage;
    public bool isInCollision;


	private bool eyesClosed;

	private Renderer darkness;

    private GameObject foreground;
    private GameObject playground;
    private GameObject background;

    private GameObject darkForeground;
    private GameObject darkPlayground;
    private GameObject darkBackground;

    public static EyeManager instance;

    // Start is called before the first frame update
    void Start() {
        if(instance == null) {
            instance = this;
        }

        eyesClosed = false;
        isInCollision = false;
        
        darkness = GameObject.FindWithTag("Darkness").GetComponent<Renderer>();

        foreground = GameObject.FindWithTag("Foreground");
        playground = GameObject.FindWithTag("Playground");
        background = GameObject.FindWithTag("Background");

        darkForeground = GameObject.FindWithTag("DarkForeground");
        darkPlayground = GameObject.FindWithTag("DarkPlayground");
        darkBackground = GameObject.FindWithTag("DarkBackground");
    }

    // Update is called once per frame
    void Update() {
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

    		darkForeground.GetComponent<Renderer>().enabled = true;
    		darkPlayground.GetComponent<Renderer>().enabled = true;
    		darkBackground.GetComponent<Renderer>().enabled = true;

    		darkPlayground.GetComponent<Collider2D>().enabled = true;

    		playground.GetComponent<Renderer>().enabled = false;
            playground.GetComponent<Collider2D>().enabled = false;

            PlayerMovement.instance.isDark = true;
        } else {
    		darkness.sortingOrder = -10;
    		darkness.enabled = false;

    		darkForeground.GetComponent<Renderer>().enabled = false;
    		darkPlayground.GetComponent<Renderer>().enabled = false;
    		darkBackground.GetComponent<Renderer>().enabled = false;

    		darkPlayground.GetComponent<Collider2D>().enabled = false;

    		playground.GetComponent<Renderer>().enabled = true;
    		playground.GetComponent<Collider2D>().enabled = true;

            PlayerMovement.instance.isDark = false;
        }
    }
}
