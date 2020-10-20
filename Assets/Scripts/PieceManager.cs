using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public GameObject[] pieces;
    public int level;
    void Start()
    {
        GameObject board = GameObject.Find("board");

        level = 1;

        pieces = new GameObject[29];
        //add all the pieces to the array
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i] = Resources.Load<GameObject>("Block" + i.ToString());
        }
    }

    void Update()
    {
    }

    public void SpawnPieces()
    {
        switch (level)
        {
            case 1:
                Instantiate<GameObject>(pieces[0], new Vector3(-8, 4, 0), Quaternion.identity).transform.SetParent(transform);
                Instantiate<GameObject>(pieces[3], new Vector3(-8, -2, 0), Quaternion.identity).transform.SetParent(transform);
                Instantiate<GameObject>(pieces[4], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity).transform.SetParent(transform);
                Instantiate<GameObject>(pieces[7], new Vector3(2, 4.5f, 0), Quaternion.identity).transform.SetParent(transform);
                break;
            default:
                Debug.Log("Something went wrong. The current level is #" + level);
                break;
        }
    }
}
