using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private Vector2 startPos;

    private bool held = false;

    public bool InBoard { get; set; }

    private void Start()
    {
        //startPos = new Vector2();
    }

    void Update()
    {
        if (held == true)
        {
            //Debug.Log(message: $"Piece held! ");
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.localPosition = mousePos;
        }

        if (held && Input.GetKeyDown("q"))
        {
            transform.Rotate(0, 0, -90);
        }

        if (held && Input.GetKeyDown("e"))
        {
            transform.Rotate(0, 0, 90);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");

            held = true;
            startPos = transform.position;
        }
    }



    private void OnMouseUp()
    {
        held = false;
        SnapPosition();
    }

    private void SnapPosition()
    {
        //where the piece is now
        Vector2 original = transform.position;
        //find the nearest point on the grid
        Vector2 newPos = EventManager.GetPosition(original);

        //if the distance between those two points is greater than one, the piece is being placed outside the board and should not be moved
        if (Vector2.Distance(original, newPos) < 1)
        {
            //if the piece is being placed in the board, snap it to the grid
            transform.position = newPos;

            //find how many colliders this piece is intersecting. if it is intersecting any, it is in an invalid position and should move back to where it was initially
            Collider2D[] colliders = new Collider2D[10];
            ContactFilter2D filter = new ContactFilter2D();
            int numColliders = GetComponent<Collider2D>().OverlapCollider(filter.NoFilter(), colliders);
            Debug.Log("this piece is intersecting " + numColliders + " colliders");
            if (numColliders > 0)
            {
                //moving the piece back to where it was at the beginning
                transform.position = startPos;
            }
        }
    }
}

