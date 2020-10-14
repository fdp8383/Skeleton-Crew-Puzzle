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

    private Vector2[,] points; //all of the grid points

    public GameObject[] pieces; //all of the pieces

    private int xSpaces;
    private int ySpaces;

    public int Level { get; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.EventName += NearestPoint;

        //load the grid square
        square = Resources.Load<GameObject>("gridSquare");

        

        //initialize and add the pieces to the pieces array
        pieces = new GameObject[10];
        pieces[0] = GameObject.Find("SquareBlock");
        pieces[1] = GameObject.Find("UBlock");
        pieces[2] = GameObject.Find("ZigZagBlock");
        pieces[3] = GameObject.Find("CrossBlock");
        pieces[4] = GameObject.Find("ZBlock");
        pieces[5] = GameObject.Find("StraightBlock");
        pieces[6] = GameObject.Find("AxeBlock");
        pieces[7] = GameObject.Find("SmallLBlock");
        pieces[8] = GameObject.Find("FlippedHammerBlock");
        pieces[9] = GameObject.Find("FlippedLBlock");

        foreach(GameObject gameObj in pieces)
        {
            gameObj.SetActive(false);
        }

        level = 1;
        GenerateBoard(10, 10);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(Filled());
        }
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
        //go through each space
        for (int i = 0; i < xSpaces; i++)
        {
            for (int n = 0; n < ySpaces; n++)
            {
                hit = Physics2D.Raycast(points[i, n], Vector2.up, 0.1f);
                Debug.Log("Hit: " + hit);
                if (!hit)//check if there is an empty space. if so return false
                {
                    return false;
                }
                hit = false;
            }
        }
        //if the function makes it here without returning false, the board is filled
        return true;
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
}
