using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuEnum
{
    MainMenu = 0,
    GameMenu = 1,
    TutorialMenu = 2,
    CreditsMenu = 3,
    PauseMenu = 4
}
public class MenuManager : MonoBehaviour
{
    public MenuEnum menuEnum = new MenuEnum();
    /*
    static MenuManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    */
    void Update()
    {
        //if we wanted to implment keyboard support for menus
        /*
        if(Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("Game");
        }
        */
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
