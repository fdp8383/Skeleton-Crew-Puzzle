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

    private void Start()
    {
        startPos = new Vector2();
    }

    void Update()
    {
        if (held == true)
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
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
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            held = true;


            Vector2 v2position = this.transform.localPosition;
            startPos = mousePos - v2position;
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }



    private void OnMouseUp()
    {
        held = false;
        SnapPosition();
    }

    private void SnapPosition()
    {
        Vector2 pos = transform.position;
        pos = EventManager.GetPosition(pos);
        transform.position = pos;
    }
}

