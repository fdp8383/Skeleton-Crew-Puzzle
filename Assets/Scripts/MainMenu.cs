using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;
	public MenuManager menuManager;
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
			//menuManager.menuEnum = MenuEnum.GameMenu;
			menuManager.ChangeScene(1);
			//SceneManager.LoadScene(1);
			obj.color = Color.cyan;
		}
	}

}
