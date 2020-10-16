﻿using System;
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
        EventManager.getPosition += NearestPoint;

        //load the grid square
        square = Resources.Load<GameObject>("gridSquare");

        //add all the pieces to the array
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

        //add the board and pieces to the scene
        level = 1;
        GenerateBoard(5, 5);
        for(int i = 0; i < pieces.Length; i++)
        {
            Instantiate(pieces[i], new Vector3(i, i, 0), Quaternion.identity);
        }
    }

    void Update()
    {
        if(Filled())
        {
            Debug.Log(message: $"filled");
            Application.Quit();
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
