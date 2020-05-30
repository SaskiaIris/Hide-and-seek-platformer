using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CarrotTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CarrotTestScriptSimplePasses()
        {
			// Use the Assert class to test conditions
			GameObject player = new GameObject();
			ScoreManager scoreManager = player.AddComponent<ScoreManager>();

			GameValues.Carrots = 0;
			scoreManager.AddCarrots(1);
			int firstTest = GameValues.Carrots;
			scoreManager.AddCarrots(2);
			int secondTest = GameValues.Carrots;

			Assert.True(firstTest == 1 && secondTest == 3);
        }
    }
}