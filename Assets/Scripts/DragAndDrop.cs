﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool held = false;

    void Update()
    {
<<<<<<< Updated upstream

=======
        if (held == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
>>>>>>> Stashed changes
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            held = true;

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
<<<<<<< Updated upstream

=======
        held = false;
>>>>>>> Stashed changes
    }
}

