using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public GameObject[] pieces;
    public GameObject board;
    public int level;
    public BoardScript boardScript;

    public List<GameObject> activePieces;
    void Start()
    {
        board = GameObject.Find("board");
        boardScript = board.GetComponent<BoardScript>();

        level = 1;

        pieces = new GameObject[29];
        //add all the pieces to the array
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i] = Resources.Load<GameObject>("Block" + i.ToString());
        }

        activePieces = new List<GameObject>();
    }

    void Update()
    {
    }

    public void SpawnPieces()
    {
        boardScript.hasSpawned = true;
        switch (level)
        {
            case 1:
                GameObject p0 = Instantiate<GameObject>(pieces[0], new Vector3(-8, 4, 0), Quaternion.identity);
                GameObject p1 = Instantiate<GameObject>(pieces[3], new Vector3(-8, -2, 0), Quaternion.identity);
                GameObject p2 = Instantiate<GameObject>(pieces[4], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity);
                GameObject p3 = Instantiate<GameObject>(pieces[6], new Vector3(5, 5, 0), Quaternion.identity);
                GameObject p4 = Instantiate<GameObject>(pieces[7], new Vector3(2, 4.5f, 0), Quaternion.identity);
                activePieces.Add(p0);
                activePieces.Add(p1);
                activePieces.Add(p2);
                activePieces.Add(p3);
                activePieces.Add(p4);
                break;
            default:
                Debug.Log("Something went wrong. The current level is #" + level);
                break;
        }
    }

    public void DespawnPieces()
    {
        boardScript.hasSpawned = false;
        foreach(GameObject piece in activePieces)
        {
            Destroy(piece);
        }
    }
}
