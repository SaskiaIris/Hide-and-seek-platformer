using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class NetworkHandler
{

	public static IEnumerator SendData(string keyUrl, Dictionary<int, float> data)
	{
		WWWForm form = new WWWForm();
		// Voeg hier alle data toe van de dictionary
		

		foreach (KeyValuePair<int, float> pair in data)
		{
			form.AddField(pair.Key.ToString(), pair.Value.ToString());
		}

		UnityWebRequest www = UnityWebRequest.Post("https://hvatestingop1.glitch.me/senddata?key=" + keyUrl, form);
		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			Debug.Log(www.error);
		}
		else
		{
			Debug.Log("Form upload complete!");
		}
	}
}