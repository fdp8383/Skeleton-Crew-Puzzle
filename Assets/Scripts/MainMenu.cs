using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;
	TextMeshPro obj;

	void Start()
	{
		obj = GetComponent<TextMeshPro>();
		obj.color = Color.black;
	}

	void OnMouseUp()
	{
		if (isQuit)
		{
			Application.Quit();
		}
		if (isStart)
		{
			SceneManager.LoadScene(1);
			obj.color = Color.cyan;
		}
	}

}
