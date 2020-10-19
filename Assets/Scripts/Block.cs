using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public event Action<int> OnButtonClicked;
    public GameObject[] pieces; //all of the pieces

    private KeyCode _keyCode; //used for keyboard input, I HAVE NOT IMPLEMENTED THIS, but I can should we want this functionality
    private int _keyNumber; //the current NUM of the hotbar

    private void OnValidate()
    {
        _keyNumber = transform.GetSiblingIndex() + 1;
        _keyCode = KeyCode.Alpha0 + _keyNumber;
        //if (_text == null)
        //    _text = GetComponentInChildren<TMP_Text>();
        //_text.SetText(_keyNumber.ToString());
        gameObject.name = "Hotbar Button " + _keyNumber;
    }
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(HandleClick);
    }

    void Start()
    {

    }
    private void HandleClick()
    {
        OnButtonClicked?.Invoke(_keyNumber);
    }

}
