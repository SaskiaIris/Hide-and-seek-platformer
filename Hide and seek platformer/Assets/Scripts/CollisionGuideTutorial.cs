using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionGuideTutorial : MonoBehaviour
{
    public string textMessage;
    public Text text;
    public int triggerNumber = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindWithTag("Key Hint Tutorial " + triggerNumber).GetComponent<Renderer>().enabled = true;
        //text.text = textMessage;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //text.text = "";
        GameObject.FindWithTag("Key Hint Tutorial " + triggerNumber).GetComponent<Renderer>().enabled = false;
    }

}
