using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
    public GameObject[] pieces; //all of the pieces
    public GameObject[] buttons;

    private void Awake()
    {
        //add buttons to an array and pieces to a separate array
        pieces = new GameObject[24];
        buttons = new GameObject[24];

        for (int i = 0; i < 24; i++)
        {
            pieces[i] = Resources.Load<GameObject>("Block" + i.ToString());
            buttons[i] = Resources.Load<GameObject>("GridSquare");
        }
        for(int i = 0; i < 5; i++)
        {
            
            //Instantiate(buttons[i], new Vector3(-5 + i * 2.5f, -5, 0), Quaternion.identity);
        }
    }

    void Start()
    {
        
    }
    private void ButtonOnOnButtonClicked(int buttonNumber)
    {
        Debug.Log(message: $"Button {buttonNumber} clicked! ");
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //sets mousePos according to screen
        Instantiate(pieces[buttonNumber], new Vector3(mousePos.x,mousePos.y, 0), Quaternion.identity);
    }
}
