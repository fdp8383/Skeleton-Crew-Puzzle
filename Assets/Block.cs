using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public event Action<int> OnButtonClicked;

    private void Awake()
    {
        //GetComponent<Button>().onClick.AddListener(HandleClick);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    //private void HandleClick
}
