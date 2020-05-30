using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class CarrotUnityTestScript
    {
		[SetUp]
		public void Setup() {
			SceneManager.LoadScene("WortelTest");
		}

		// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
		// `yield return null;` to skip a frame.
		[UnityTest]
        public IEnumerator CarrotWithEnumeratorPasses()
        {
			GameObject player = GameObject.Find("Player");
			PlayerMovement movement = player.GetComponent<PlayerMovement>();
			EyeManager eye = player.GetComponent<EyeManager>();

			movement.isTesting = true;
			movement.movement = 1;
			eye.eyesClosed = true;

			yield return new WaitForSeconds(3);
			Assert.True(GameValues.Carrots == 5);
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
        }
    }
}