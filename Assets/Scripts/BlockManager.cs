using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.VersionControl;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject[] pieces; //all of the pieces
<<<<<<< HEAD
<<<<<<< HEAD
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
=======

    private void Awake()
    {
        foreach(var button in  GetComponentsInChildren<Block>())
        {
            button.OnButtonClicked += ButtonOnOnButtonClicked;
>>>>>>> parent of 08b9aea... board spawns in properly
=======

    private void Awake()
    {
        foreach(var button in  GetComponentsInChildren<Block>())
        {
            button.OnButtonClicked += ButtonOnOnButtonClicked;
>>>>>>> parent of 08b9aea... board spawns in properly
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
