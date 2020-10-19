using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
	TextMeshPro obj;

	void Start()
	{
		obj = GetComponent<TextMeshPro>();
		obj.color = Color.black;
	}

	void OnMouseEnter()
	{
		obj.color = Color.red;
	}

	void OnMouseExit()
	{
		obj.color = Color.black;
	}

}
