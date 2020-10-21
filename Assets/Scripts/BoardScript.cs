using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BoardScript : MonoBehaviour
{

    private GameObject square; //gridsquare

    private Transform Boundary; //outer boundary of the grid to keep pieces inside

    public GameObject[] pieces; //all of the pieces
    public bool[] activePieces;

    private Vector2[,] points; //all of the grid points

    public int xSpaces;
    public int ySpaces;

    public bool hasSpawned;

    public GameObject spawnButton;
    public GameObject despawnButton;

    private void Awake()
    {
        //load the grid square
        square = Resources.Load<GameObject>("GridSquare");
    }

    // Start is called before the first frame update
    void Start()
    {
        //setting up events for pieces to use
        //pieces can find the nearest board point to snap to
        EventManager.getPosition += NearestPoint;
        //board will check if it is filled when you place a piece
        EventManager.boardCheck += Filled;

        Boundary = transform.Find("outside");

        xSpaces = 5;
        ySpaces = 5;
        points = new Vector2[xSpaces, ySpaces];

        //resize the bounding collider with the board
        Boundary.localScale = new Vector2(xSpaces, ySpaces);
        GenerateBoard(xSpaces, ySpaces);
        hasSpawned = false;

        spawnButton = GameObject.Find("SpawnButton");
        despawnButton = GameObject.Find("DespawnButton");
    }

    void Update()
    {
        // This is the 'kill state'
        // If the board is filled and the mouse is up, stop the game
        if (Filled() && Input.GetMouseButtonUp(0))
        {

#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }

        // This runs if the game is still being played
        else
        {
            if (hasSpawned && spawnButton.GetComponent<Button>().interactable)
            {
                spawnButton.GetComponent<Button>().interactable = false;
                despawnButton.GetComponent<Button>().interactable = true;
            }
            else if (!hasSpawned && !spawnButton.GetComponent<Button>().interactable)
            {
                spawnButton.GetComponent<Button>().interactable = true;
                despawnButton.GetComponent<Button>().interactable = false;
            }
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
        bool isFilled = false;
        //go through each space
        for (int i = 0; i < xSpaces; i++)
        {
            for (int n = 0; n < ySpaces; n++)
            {
                hit = Physics2D.Raycast(points[i, n], Vector2.up, 0.1f);
                if (!hit)//check if there is an empty space. if so return false
                {
                    isFilled = false;
                    return isFilled;
                }
                hit = false;
            }
        }
        //if the function makes it here without returning false, the board is filled
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
