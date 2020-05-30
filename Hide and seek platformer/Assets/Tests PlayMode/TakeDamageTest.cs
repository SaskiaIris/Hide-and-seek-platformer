using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TakeDamageTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TakeDamageTestSimplePasses()
        {
            // Use the Assert class to test conditions
            GameObject player = new GameObject();
            PlayerMovement movement = player.AddComponent<PlayerMovement>();
            GameValues.HealthPoints = 100;         

            movement.GetDamage();
            float value0 = GameValues.HealthPoints;
            movement.GetDamage();
            movement.GetDamage();
            movement.GetDamage();

            float value1 = GameValues.HealthPoints;

            Assert.True(value0 == 95f && value1 == 80f);
        }

    }
}
