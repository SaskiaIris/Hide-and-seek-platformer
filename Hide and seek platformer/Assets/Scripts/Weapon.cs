using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform shootPoint;
	public GameObject Ammo;

    void Start() {
		GameValues.CurrentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") && GameValues.CurrentLevel > GameValues.LevelSelect) {
            Shoot();
            Debug.Log("PEW PEW PEW");

            GameValues.InsertShotsLevel(GameValues.CurrentLevel, 1);
        }
    }

    public void Shoot() {
        Instantiate(Ammo, shootPoint.position, shootPoint.rotation);
    }
}
