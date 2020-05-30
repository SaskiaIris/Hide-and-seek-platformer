using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;


public class Testscript
{
	[Test]
	public void FlipTestScriptSimplePasses()
	{
		GameObject playerObject = new GameObject();
		playerObject.AddComponent<PlayerMovement>();
		PlayerMovement saskia = playerObject.GetComponent<PlayerMovement>();

		saskia.Flip();

		Assert.True(saskia.m_FacingRight);

	}


}

