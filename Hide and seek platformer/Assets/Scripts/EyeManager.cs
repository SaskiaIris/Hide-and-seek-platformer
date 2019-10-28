using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeManager : MonoBehaviour
{
    public Text warningMessage;
    public bool isInCollision;

	private bool eyesClosed;

    //private Renderer darkness;
    private Camera cam;

    private GameObject foreground;
    private GameObject playground;
    private GameObject background;

    private GameObject darkForeground;
    private GameObject darkPlayground;
    private GameObject darkBackground;

    private GameObject[] backgroundPictures;

    public static EyeManager instance;

    // Start is called before the first frame update
    void Start() {
        if(instance == null) {
            instance = this;
        }

        cam = GameObject.FindWithTag("Level Camera").GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;

        eyesClosed = false;
        isInCollision = false;
        
        //darkness = GameObject.FindWithTag("Darkness").GetComponent<Renderer>();

        foreground = GameObject.FindWithTag("Foreground");
        playground = GameObject.FindWithTag("Playground");
        background = GameObject.FindWithTag("Background");

        darkForeground = GameObject.FindWithTag("DarkForeground");
        darkPlayground = GameObject.FindWithTag("DarkPlayground");
        darkBackground = GameObject.FindWithTag("DarkBackground");

        backgroundPictures = GameObject.FindGameObjectsWithTag("BackgroundPicture");
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
            //darkness.sortingOrder = 10;
            //darkness.enabled = true;

            cam.backgroundColor = new Color32(50, 44, 67, 255);

            darkForeground.GetComponent<Renderer>().enabled = true;
    		darkPlayground.GetComponent<Renderer>().enabled = true;
    		darkBackground.GetComponent<Renderer>().enabled = true;

    		darkPlayground.GetComponent<Collider2D>().enabled = true;

            foreground.GetComponent<Renderer>().enabled = false;
            playground.GetComponent<Renderer>().enabled = false;
            background.GetComponent<Renderer>().enabled = false;

            playground.GetComponent<Collider2D>().enabled = false;

            foreach(GameObject bgPic in backgroundPictures) {
                bgPic.GetComponent<Renderer>().enabled = false;
            }

            PlayerMovement.instance.isDark = true;
        } else {
            //darkness.sortingOrder = -10;
            //darkness.enabled = false;

            cam.backgroundColor = new Color32(152, 220, 255, 255);

            darkForeground.GetComponent<Renderer>().enabled = false;
    		darkPlayground.GetComponent<Renderer>().enabled = false;
    		darkBackground.GetComponent<Renderer>().enabled = false;

    		darkPlayground.GetComponent<Collider2D>().enabled = false;

            foreground.GetComponent<Renderer>().enabled = true;
            playground.GetComponent<Renderer>().enabled = true;
            background.GetComponent<Renderer>().enabled = true;

    		playground.GetComponent<Collider2D>().enabled = true;

            foreach(GameObject bgPic in backgroundPictures) {
                bgPic.GetComponent<Renderer>().enabled = true;
            }

            PlayerMovement.instance.isDark = false;
        }
    }
}
