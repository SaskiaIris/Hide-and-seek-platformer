using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D Other)
    {
        ScoreManager.instance.ChangeScore(value);
        Debug.Log("+1");
    }
}