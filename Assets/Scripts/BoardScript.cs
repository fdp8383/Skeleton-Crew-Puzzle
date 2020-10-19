using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography;
using UnityEngine;

public class BoardScript : MonoBehaviour
{

    //level number
    private int level = 0;

    private GameObject square; //gridsquare

    public GameObject[] pieces; //all of the pieces

    private Vector2[,] points; //all of the grid points

    public int xSpaces;
    public int ySpaces;

    public int Level { get; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        //setting up events for pieces to use
        //pieces can find the nearest board point to snap to
        EventManager.getPosition += NearestPoint;
        //board will check if it is filled when you place a piece
        EventManager.boardCheck += Filled;

        xSpaces = 5;
        ySpaces = 5;
        points = new Vector2[xSpaces, ySpaces];


        //load the grid square
        square = Resources.Load<GameObject>("GridSquare");

        pieces = new GameObject[24];
        //add all the pieces to the array
        for(int i = 0; i < 24; i++)
        {
            pieces[i] = Resources.Load<GameObject>("Block" + i.ToString());
        }

        //add the board and pieces to the scene
        level = 1;
        GenerateBoard(xSpaces, ySpaces);
        //for(int i = 0; i < pieces.Length; i++)
        //{
        //    Instantiate(pieces[i], new Vector3(i, i, 0), Quaternion.identity);
        //}
    }

    void Update()
    {
        /*
        if(Filled())
        {
            Debug.Log(message: $"filled");
            Application.Quit();
        }
        */
    }

    //get the nearest point on the grid to a given point. will use for snapping pieces to grid
    public Vector2 NearestPoint(Vector2 initial)
    {
        Vector2 closest = points[0,0];
        float shortestDist = float.MaxValue;
        float dist = 0;

        for (int i = 0; i < xSpaces; i++)
        {
            for (int n = 0; n < ySpaces; n++)
            {
                dist = Vector2.Distance(initial, points[i, n]);
                if (dist < shortestDist)
                {
                    closest = points[i, n];
                    shortestDist = dist;
                }
            }
        }
        return closest;
    }

    //check if the board is filled
    public bool Filled()
    {
        bool hit = false;
        bool isFilled = false;
        //go through each space
        for (int i = 0; i < xSpaces; i++)
        {
            for (int n = 0; n < ySpaces; n++)
            {
                hit = Physics2D.Raycast(points[i, n], Vector2.up, 0.1f);
                Debug.Log("Hit: " + hit);
                if (!hit)//check if there is an empty space. if so return false
                {
                    Debug.Log(false);
                    isFilled = false;
                    return isFilled;
                }
                hit = false;
            }
        }
        //if the function makes it here without returning false, the board is filled
        Debug.Log(true);
        isFilled = true;
        return isFilled;
    }

    private void GenerateBoard(int x, int y)
    {
        xSpaces = x;
        ySpaces = y;

        //generate points
        points = new Vector2[xSpaces, ySpaces];
        for (int i = 0; i < xSpaces; i++)
        {
            for (int n = 0; n < ySpaces; n++)
            {
                points[i, n] = new Vector2(i - (xSpaces - 1) / 2f, n - (ySpaces - 1) / 2f); //create a point
                Instantiate(square, new Vector3(points[i, n].x, points[i, n].y, 0), Quaternion.identity).transform.parent = transform; //draw a grid square around the point and set the parent to the board
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DragAndDrop piece = other.GetComponent<DragAndDrop>();
        if (piece)
            piece.InBoard = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        DragAndDrop piece = other.GetComponent<DragAndDrop>();
        if (piece)
            piece.InBoard = false;
    }
}
