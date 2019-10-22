using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionGuideTutorial : MonoBehaviour
{
    public string textMessage;
    public Text text;

    private void OnTriggerEnter2D(Collider2D other)
    {
        text.text = textMessage;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        text.text = "";
    }

}
