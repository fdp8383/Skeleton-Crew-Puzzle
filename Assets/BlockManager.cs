using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private void Awake()
    {
        foreach(var button in  GetComponentsInChildren<Block>())
        {
            button.OnButtonClicked += ButtonOnOnButtonClicked;
        }
        
    }
    
    private void ButtonOnOnButtonClicked(int buttonNumber)
    {
        Debug.Log(message: $"Button {buttonNumber} clicked! ");
    }
}
