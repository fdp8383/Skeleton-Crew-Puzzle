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
    public GameObject menu;
    public MenuManager menuManager;

    public int level;
    void Start()
    {
        board = GameObject.Find("board");
        boardScript = board.GetComponent<BoardScript>();

        menu = GameObject.Find("SceneManager");
        menuManager = menu.GetComponent<MenuManager>();

        level = 29;

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
            // tutorial level, only 1 piece 2x2
            case 0:
                boardScript.xSpaces = 2;
                boardScript.ySpaces = 2;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(-8, 4, 0), Quaternion.identity));
                break;

            // 2 pieces
            // level 1
            case 1:
                boardScript.xSpaces = 4;
                boardScript.ySpaces = 2;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(-8, 4, 0), Quaternion.identity));
                break;

            // 3x3
            // level 2
            case 2:
                boardScript.xSpaces = 3;
                boardScript.ySpaces = 3;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[10], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(-8, -2, 0), Quaternion.identity));
                break;

            //level 3
            case 3:
                boardScript.xSpaces = 3;
                boardScript.ySpaces = 3;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[17], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(-8, -2, 0), Quaternion.identity));
                break;

            // level 4
            case 4:
                boardScript.xSpaces = 3;
                boardScript.ySpaces = 3;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[5], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[16], new Vector3(-8, -2, 0), Quaternion.identity));
                break;

            // level 5
            case 5:
                boardScript.xSpaces = 4;
                boardScript.ySpaces = 3;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[24], new Vector3(-8, -2, 0), Quaternion.identity));
                break;

            // level 6
            case 6:
                boardScript.xSpaces = 4;
                boardScript.ySpaces = 3;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[26], new Vector3(-8, -2, 0), Quaternion.identity));
                break;

            // level 7
            case 7:
                boardScript.xSpaces = 4;
                boardScript.ySpaces = 3;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[16], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[27], new Vector3(5, 5, 0), Quaternion.identity));
                break;

            // level 8
            case 8:
                boardScript.xSpaces = 4;
                boardScript.ySpaces = 3;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[18], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(5, 5, 0), Quaternion.identity));
                break;

            // level 9
            case 9:
                boardScript.xSpaces = 4;
                boardScript.ySpaces = 3;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(5, 5, 0), Quaternion.identity));
                break;

            // level 10
            case 10:
                boardScript.xSpaces = 5;
                boardScript.ySpaces = 4;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[8], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[9], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[10], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[18], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[28], new Vector3(2, 4.5f, 0), Quaternion.identity));
                break;

            // level 11
            case 11:
                boardScript.xSpaces = 5;
                boardScript.ySpaces = 3;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[5], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[2], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(5, 5, 0), Quaternion.identity));
                break;

            // level 12
            case 12:
                boardScript.xSpaces = 5;
                boardScript.ySpaces = 4;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[24], new Vector3(-8, 4, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[12], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[19], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                break;

            // level 13
            case 13:
                boardScript.xSpaces = 5;
                boardScript.ySpaces = 4;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[12], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[2], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[4], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                break;

            // level 14
            case 14:
                boardScript.xSpaces = 5;
                boardScript.ySpaces = 5;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[1], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[4], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[5], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[5], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[9], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                break;

            // level 15
            case 15:
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

            //level 16
            case 16:
                boardScript.xSpaces = 5;
                boardScript.ySpaces = 5;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[0], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[3], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[4], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[7], new Vector3(2, 4.5f, 0), Quaternion.identity));
                break;

            //level 17
            case 17:
                boardScript.xSpaces = 6;
                boardScript.ySpaces = 3;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[26], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[26], new Vector3(-8, -2, 0), Quaternion.identity));
                break;

            //level 18
            case 18:
                boardScript.xSpaces = 6;
                boardScript.ySpaces = 5;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[1], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[10], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[20], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[21], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(0.5f, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(7, 0, 0), Quaternion.identity));
                break;

            //level 19
            case 19:
                boardScript.xSpaces = 7;
                boardScript.ySpaces = 4;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[3], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[8], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[26], new Vector3(7, 0, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[26], new Vector3(7, 0, 0), Quaternion.identity));
                break;

            //level 20
            case 20:
                boardScript.xSpaces = 7;
                boardScript.ySpaces = 5;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[5], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[7], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[10], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[17], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[17], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(9, 3, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[24], new Vector3(6.5f, -0.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[27], new Vector3(7, -4, 0), Quaternion.identity));
                break;

            // level 21
            case 21:
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

            // level 22
            case 22:
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

            // level 23
            case 23:
                boardScript.xSpaces = 7;
                boardScript.ySpaces = 7;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[20], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(8, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(8, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(8, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(8, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(8.5f, -3, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(8.5f, -3, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(8.5f, -3, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(8.5f, -3, 0), Quaternion.identity));
                break;

            // level 24
            case 24:
                boardScript.xSpaces = 7;
                boardScript.ySpaces = 7;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[0], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(-8, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[7], new Vector3(-3.5f, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[8], new Vector3(1, 5, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[10], new Vector3(5, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-12, -4, 0), Quaternion.Euler(0, 0, -90)));
                activePieces.Add(Instantiate<GameObject>(pieces[23], new Vector3(9, 3, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(6.5f, -0.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[28], new Vector3(7, -4, 0), Quaternion.identity));
                break;

            // level 25
            case 25:
                boardScript.xSpaces = 7;
                boardScript.ySpaces = 7;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[0], new Vector3(12, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[4], new Vector3(-8, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(-6, -1, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[8], new Vector3(-5, 6, 0), Quaternion.Euler(0, 0, -90)));
                activePieces.Add(Instantiate<GameObject>(pieces[9], new Vector3(0, 5.5f, 0), Quaternion.Euler(0, 0, 180)));
                activePieces.Add(Instantiate<GameObject>(pieces[11], new Vector3(6, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[14], new Vector3(-11, 1, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(12, 0, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(7, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[27], new Vector3(-9, -3, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[28], new Vector3(10, 4, 0), Quaternion.identity));
                break;

            // level 26
            case 26:
                boardScript.xSpaces = 7;
                boardScript.ySpaces = 7;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[1], new Vector3(-4.5f, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[2], new Vector3(-10.5f, 4, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[5], new Vector3(-5, 0, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(-0.5f, 5.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[10], new Vector3(-10, -3, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[11], new Vector3(6, 0, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[18], new Vector3(7, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[20], new Vector3(10.5f, 1, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[20], new Vector3(10.5f, 1, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(11, 5.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[28], new Vector3(4, 6, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[28], new Vector3(4, 6, 0), Quaternion.identity));
                break;

            // level 27
            case 27:
                boardScript.xSpaces = 7;
                boardScript.ySpaces = 7;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[0], new Vector3(-5, 5, 0), Quaternion.Euler(0, 0, -90)));
                activePieces.Add(Instantiate<GameObject>(pieces[2], new Vector3(-6.5f, 0, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[4], new Vector3(-11.5f, -2, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[9], new Vector3(-10.5f, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[11], new Vector3(11.5f, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[16], new Vector3(0.5f, 6.5f, 0), Quaternion.Euler(0, 0, 180)));
                activePieces.Add(Instantiate<GameObject>(pieces[16], new Vector3(0.5f, 6.5f, 0), Quaternion.Euler(0, 0, 180)));
                activePieces.Add(Instantiate<GameObject>(pieces[18], new Vector3(5.5f, 1, 0), Quaternion.Euler(0, 0, -90)));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(6.5f, 6.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[24], new Vector3(8.5f, -2.5f, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(9, 3, 0), Quaternion.identity));
                break;

            // level 28
            case 28:
                boardScript.xSpaces = 7;
                boardScript.ySpaces = 7;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[0], new Vector3(-8, 4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[1], new Vector3(-11, 5.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[2], new Vector3(1.5f, 5.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[5], new Vector3(8.5f, -1.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[6], new Vector3(-7.5f, -2.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[7], new Vector3(11, 2.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[16], new Vector3(10, -4.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[21], new Vector3(-7, 1, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[22], new Vector3(-11, 0, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(8.5f, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[28], new Vector3(-5, 5, 0), Quaternion.identity));
                break;

            // level 29
            case 29:
                boardScript.xSpaces = 7;
                boardScript.ySpaces = 7;
                boardScript.points = new Vector2[boardScript.xSpaces, boardScript.ySpaces];
                boardScript.GenerateBoard(boardScript.xSpaces, boardScript.ySpaces);
                boardScript.Boundary.localScale = new Vector2(boardScript.xSpaces, boardScript.ySpaces);
                activePieces.Add(Instantiate<GameObject>(pieces[9], new Vector3(-10.5f, -1.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[10], new Vector3(-5, 6, 0), Quaternion.Euler(0, 0, 180)));
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-9, 3, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[15], new Vector3(-9, 3, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[16], new Vector3(10, 0.5f, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[16], new Vector3(10, 0.5f, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[20], new Vector3(3.5f, 5.5f, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[21], new Vector3(6, -2, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[25], new Vector3(-0.5f, 6, 0), Quaternion.Euler(0, 0, 90)));
                activePieces.Add(Instantiate<GameObject>(pieces[27], new Vector3(9, 5, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[28], new Vector3(-11, 6, 0), Quaternion.identity));
                activePieces.Add(Instantiate<GameObject>(pieces[28], new Vector3(-11, 6, 0), Quaternion.identity));
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
        if(level == 30)
        {
            menuManager.ChangeScene(5);
        }
        SpawnPieces();
        boardScript.nextLevelButton.GetComponent<Button>().interactable = false;
    }
}
