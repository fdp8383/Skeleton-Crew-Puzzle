using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceManager : MonoBehaviour
{
    public GameObject[] pieces;
    public GameObject board;
    public List<GameObject> activePieces;
    public BoardScript boardScript;

    public int level;
    void Start()
    {
        board = GameObject.Find("board");
        boardScript = board.GetComponent<BoardScript>();

        level = 0;

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

    // Spawns in the pieces
    public void SpawnPieces()
    {
        boardScript.hasSpawned = true;
        switch (level)
        {
            // tutorial level, only 1 piece
            case 0:
                boardScript.xSpaces = 2;
                boardScript.ySpaces = 2;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[24], new Vector3(-8, 4, 0), Quaternion.identity));
                break;
            // first 'real' level
            case 1:
                boardScript.xSpaces = 5;
                boardScript.ySpaces = 5;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                //resize the bounding collider with the board
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);

                activePieces.Add(Instantiate<GameObject>(pieces[0], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[3], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[4], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[7], new Vector3(2, 4.5f, 0), Quaternion.identity));
                break;
            default:
                Debug.Log("Something went wrong. The current level is #" + level);
                break;
        }
    }

    // Goes through all of the despawned pieces and destroys them
    public void DespawnPieces()
    {
        boardScript.hasSpawned = false;
        foreach(GameObject piece in activePieces)
        {
            Destroy(piece);
        }
    }

    public void NextLevel()
    {
        DespawnPieces();
        level++;
        SpawnPieces();
        boardScript.nextLevelButton.GetComponent<Button>().interactable = false;
    }
}
