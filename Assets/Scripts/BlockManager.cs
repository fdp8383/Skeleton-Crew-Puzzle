using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.VersionControl;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject[] pieces; //all of the pieces

    private void Awake()
    {
        foreach(var button in  GetComponentsInChildren<Block>())
        {
            button.OnButtonClicked += ButtonOnOnButtonClicked;
        }
        
    }

    void Start()
    {
        pieces = new GameObject[]
       {
            Resources.Load<GameObject>("AxeBlock"),
            Resources.Load<GameObject>("CrossBlock"),
            Resources.Load<GameObject>("FlippedHammerBlock"),
            Resources.Load<GameObject>("SmallLBlock"),
            Resources.Load<GameObject>("SquareBlock"),
            Resources.Load<GameObject>("StraightBlock"),
            Resources.Load<GameObject>("UBlock"),
            Resources.Load<GameObject>("ZBlock"),
            Resources.Load<GameObject>("ZigZagBlock")
       };
    }
    private void ButtonOnOnButtonClicked(int buttonNumber)
    {
        Debug.Log(message: $"Button {buttonNumber} clicked! ");
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //sets mousePos according to screen
        Instantiate(pieces[buttonNumber], new Vector3(mousePos.x,mousePos.y, 0), Quaternion.identity);
    }
}
