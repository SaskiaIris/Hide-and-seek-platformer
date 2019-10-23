using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelNumber = 0;

    private bool isByDoor = false;
    private GameObject keyHint;
    // Start is called before the first frame update
    void Start()
    {
        keyHint = GameObject.FindWithTag("Key Hint " + levelNumber.ToString());
    }

    // Update is called once per frame
    void Update() {
        if(isByDoor) {
            keyHint.GetComponent<Renderer>().enabled = true;
            if (Input.GetAxis("Vertical") > 0.1) {
                SceneManager.LoadScene(levelNumber);
            }
        } else {
            keyHint.GetComponent<Renderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isByDoor = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isByDoor = false;
    }
}
