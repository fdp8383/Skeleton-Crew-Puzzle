using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// I feel like this class is obsolete but I don't want to mess with anything
// right now as it's currently working
public class ButtonManager : MonoBehaviour
{
    public Button spawnButton;
    public Button despawnButton;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate<Button>(spawnButton, new Vector3(342, 43, 0), Quaternion.identity).transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
