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

        pieces = new GameObject[28];

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
            // tutorial level, only 1 piece 1x1
            case 0:
                boardScript.xSpaces = 2;
                boardScript.ySpaces = 2;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(-8, 4, 0), Quaternion.identity));
                break;
            // first 'real' level 2x2
            // level 1
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
            // level 2
            case 2:
                boardScript.xSpaces = 5;
                boardScript.ySpaces = 4;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);

                activePieces.Add(Instantiate<GameObject>(pieces[4], new Vector3(2, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[5], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[12], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                break;
            // level 3
            case 3:
                boardScript.xSpaces = 5;
                boardScript.ySpaces = 7;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);

                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(2, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[16], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[16], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[17], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[20], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(8, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(8, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(8, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(8, -2, 0), Quaternion.identity));
                break;
            // level 4
            case 4:
                boardScript.xSpaces = 5;
                boardScript.ySpaces = 7;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);

                activePieces.Add(Instantiate<GameObject>(pieces[3], new Vector3(2.5f, 6, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[4], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[12], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-3, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[16], new Vector3(8, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(8.5f, -3, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[24], new Vector3(4, -1, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[27], new Vector3(8, 1, 0), Quaternion.identity));
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
        foreach(GameObject square in boardScript.activeBoard)
        {
            Destroy(square);
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
