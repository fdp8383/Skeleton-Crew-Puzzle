using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private Vector2 startPos;
    private bool held = false;

    public bool InBoard { get; set; }

    private void Start()
    {
        startPos = new Vector2();
    }

    void Update()
    {
        if (held == true)
        {
            Debug.Log(message: $"Piece held! ");
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
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            held = true;


            Vector2 v2position = this.transform.localPosition;
            startPos = mousePos - v2position;
        }
    }



    private void OnMouseUp()
    {
        held = false;
        SnapPosition();
    }

    private void SnapPosition()
    {
        Debug.Log("touching board? "+InBoard);
        if (InBoard)
        {
            Vector2 pos = transform.position;
            pos = EventManager.GetPosition(pos);
            transform.position = pos;
        }
    }
}

