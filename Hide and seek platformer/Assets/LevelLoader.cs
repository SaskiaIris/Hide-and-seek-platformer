using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelNumber = 0;

    private bool isByDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(isByDoor)
            {
                SceneManager.LoadScene(levelNumber);
            }
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
