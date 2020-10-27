using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;
	public bool isTutorial;
	public bool isGameTutorial;
	public bool isCredits;
	public bool isBack;
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
			obj.color = Color.cyan;
		}
		if (isStart)
		{
			//menuManager.menuEnum = MenuEnum.GameMenu;
			menuManager.ChangeScene(2);
			//SceneManager.LoadScene(1);
			obj.color = Color.cyan;
		}
        if (isTutorial)
        {
			menuManager.ChangeScene(4);
			obj.color = Color.cyan;
		}
        if (isGameTutorial)
        {
			menuManager.ChangeScene(1);
			obj.color = Color.cyan;
		}
        if (isCredits)
        {
			menuManager.ChangeScene(3);
			obj.color = Color.cyan;
		}
        if (isBack)
        {
			menuManager.ChangeScene(0);
			obj.color = Color.cyan;
		}
	}

}
