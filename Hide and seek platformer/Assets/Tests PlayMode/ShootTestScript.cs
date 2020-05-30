using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
	public class ShootTestScript
	{
		[SetUp]
		public void Setup()
		{
			SceneManager.LoadScene("TestScene");
		}

		[UnityTest]
		public IEnumerator ShootTestScriptWithEnumeratorPasses()
		{
			GameObject playerObject = GameObject.Find("Player");
			Weapon saskia = playerObject.GetComponent<Weapon>();
			yield return new WaitForSeconds(3);
			saskia.Shoot();
			yield return new WaitForSeconds(3);
			Assert.True(GameObject.Find("Ant") == null);
			
			yield return null;
		}
	}
}
