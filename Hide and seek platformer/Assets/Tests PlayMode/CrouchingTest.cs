using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class CrouchingTest
    {
        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene("TestScene Crouching");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator CrouchingTestWithEnumeratorPasses()
        {
            GameObject player = GameObject.Find("Player");
            Transform end = GameObject.Find("End").transform;
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            EyeManager eye = player.GetComponent<EyeManager>();

            movement.isTesting = true;
            movement.IsDucking = true;

            eye.eyesClosed = true;
            movement.movement = 1;

            yield return new WaitForSeconds(3);

            Assert.True(Vector2.Distance(player.transform.position, end.position) <= 1);
        }
    }
}
