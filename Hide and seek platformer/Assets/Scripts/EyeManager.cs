using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EyeManager : MonoBehaviour {
    public bool isInCollision;

	private bool eyesClosed;

    private Camera cam;

    private GameObject foreground;
    private GameObject playground;
    private GameObject background;

    private GameObject darkForeground;
    private GameObject darkPlayground;
    private GameObject darkBackground;

	private GameObject[] lightCarrots;
	private GameObject[] darkCarrots;

	private GameObject[] lightEnemies;
	private GameObject[] darkEnemies;

	private GameObject backgroundPicture;

	private Text warningMessage;

	public static EyeManager instance;

    // Start is called before the first frame update
    void Start() {
        if(instance == null) {
            instance = this;
        }

		GameValues.CurrentLevel = SceneManager.GetActiveScene().buildIndex;
		GameValues.Eyes_Closed = 0;

        cam = GameObject.FindWithTag("Level Camera").GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;

        eyesClosed = false;
        isInCollision = false;

        foreground = GameObject.FindWithTag("Foreground");
        playground = GameObject.FindWithTag("Playground");
        background = GameObject.FindWithTag("Background");

		if(GameValues.CurrentLevel > 3) {
			darkForeground = GameObject.FindWithTag("DarkForeground");
			darkPlayground = GameObject.FindWithTag("DarkPlayground");
			darkBackground = GameObject.FindWithTag("DarkBackground");

			darkCarrots = GameObject.FindGameObjectsWithTag("Dark Carrot");
			darkEnemies = GameObject.FindGameObjectsWithTag("Dark Enemy");

			lightCarrots = GameObject.FindGameObjectsWithTag("Light Carrot");
			lightEnemies = GameObject.FindGameObjectsWithTag("Light Enemy");
		}

		backgroundPicture = GameObject.FindGameObjectWithTag("BackgroundPicture");

		warningMessage = GameObject.FindWithTag("Screen Message").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Eyes") && GameValues.CurrentLevel > 3) {
			GameValues.Eyes_Closed += 1;
            if(isInCollision) {
            	eyesClosed = !eyesClosed;
            	print("ogen: " + eyesClosed);
            } else {
                warningMessage.text = "You can only close/open your eyes in the appropriate \"G\"-marked zones";
            }
        }

        /*if(Input.GetButtonDown("Okay")) {
            warningMessage.text = "";
        }*/
    }

    void FixedUpdate() {
		if(GameValues.CurrentLevel > 3) {
    		if(eyesClosed) {
				cam.backgroundColor = new Color32(50, 44, 67, 255);

				darkForeground.GetComponent<Renderer>().enabled = true;
    			darkPlayground.GetComponent<Renderer>().enabled = true;
    			darkBackground.GetComponent<Renderer>().enabled = true;

    			darkPlayground.GetComponent<Collider2D>().enabled = true;

				foreground.GetComponent<Renderer>().enabled = false;
				playground.GetComponent<Renderer>().enabled = false;
				background.GetComponent<Renderer>().enabled = false;

				playground.GetComponent<Collider2D>().enabled = false;

				for(int lC = 0; lC < lightCarrots.Length; lC++) {
					if(lightCarrots[lC] != null) {
						lightCarrots[lC].GetComponent<Renderer>().enabled = false;
					}
				}
				for(int dC = 0; dC < darkCarrots.Length; dC++) {
					if(darkCarrots[dC] != null) {
						darkCarrots[dC].GetComponent<Renderer>().enabled = true;
					}
				}

				for(int lE = 0; lE < lightEnemies.Length; lE++) {
					if(lightEnemies[lE] != null) {
						lightEnemies[lE].GetComponent<Renderer>().enabled = false;
					}
				}
				for(int dE = 0; dE < darkEnemies.Length; dE++) {
					if(darkEnemies[dE] != null) {
						darkEnemies[dE].GetComponent<Renderer>().enabled = true;
					}
				}

				backgroundPicture.GetComponent<Canvas>().enabled = false;

				PlayerMovement.instance.isDark = true;
			} else {
				cam.backgroundColor = new Color32(152, 220, 255, 255);

				darkForeground.GetComponent<Renderer>().enabled = false;
    			darkPlayground.GetComponent<Renderer>().enabled = false;
    			darkBackground.GetComponent<Renderer>().enabled = false;

    			darkPlayground.GetComponent<Collider2D>().enabled = false;

				foreground.GetComponent<Renderer>().enabled = true;
				playground.GetComponent<Renderer>().enabled = true;
				background.GetComponent<Renderer>().enabled = true;

    			playground.GetComponent<Collider2D>().enabled = true;

				for(int lC = 0; lC < lightCarrots.Length; lC++) {
					if(lightCarrots[lC] != null) {
						lightCarrots[lC].GetComponent<Renderer>().enabled = true;
					}
				}
				for(int dC = 0; dC < darkCarrots.Length; dC++) {
					if(darkCarrots[dC] != null) {
						darkCarrots[dC].GetComponent<Renderer>().enabled = false;
					}
				}

				for(int lE = 0; lE < lightEnemies.Length; lE++) {
					if(lightEnemies[lE] != null) {
						lightEnemies[lE].GetComponent<Renderer>().enabled = true;
					}
				}
				for(int dE = 0; dE < darkEnemies.Length; dE++) {
					if(darkEnemies[dE] != null) {
						darkEnemies[dE].GetComponent<Renderer>().enabled = false;
					}
				}

				backgroundPicture.GetComponent<Canvas>().enabled = true;

				PlayerMovement.instance.isDark = false;
			}
		}
    }
}
