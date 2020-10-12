using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;

public class BoardScript : MonoBehaviour
{

    //dimensions of board
    [SerializeField]
    private int xSpaces = 0;
    [SerializeField]
    private int ySpaces = 0;

    //i think i only needed this for testing, can probably get rid of this later
    [SerializeField]
    private Camera camera;

    private GameObject square; //gridsquare

    private BoxCollider2D col; //board collider. may not need

    private Vector2[,] points; //all of the grid points

    // Start is called before the first frame update
    void Start()
    {
        //load the grid square
        square = Resources.Load<GameObject>("gridSquare");

        //generate points
        points = new Vector2[xSpaces, ySpaces];
        for(int i=0; i < xSpaces; i++)
        {
            for (int n = 0; n < ySpaces; n++)
            {
                points[i,n] = new Vector2(i - (xSpaces - 1) / 2f, n - (ySpaces - 1) / 2f); //create a point
                Instantiate(square, new Vector3(points[i, n].x, points[i, n].y, 0), Quaternion.identity).transform.parent = transform; //draw a grid square around the point and set the parent to the board
            }
        }

        //set the boxes collider to the right size. needed this for testing, but we may not actually need the board to have a collider
        col = gameObject.GetComponent<BoxCollider2D>();
        col.size = new Vector2(xSpaces, ySpaces);
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


    //used for testing if nearestpoint worked
    void OnMouseDown()
    {
        Debug.Log(NearestPoint(camera.ScreenToWorldPoint(Input.mousePosition)));
        Debug.Log(camera.ScreenToWorldPoint(Input.mousePosition));
    }
}
