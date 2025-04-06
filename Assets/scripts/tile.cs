using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tile : MonoBehaviour
{
    public bool isBomb = false;
    public bool revealed = false;
    public Board board;
    public Button button;
    public TMPro.TextMeshProUGUI minesDisplay;
    public AudioClip explosion;
    public AudioClip fuse;

    public Image image;
    public int index;
    // Start is called before the first frame update
    public  int getCount()
    {
        int bombCount = 0;
        int x = index % Board.gridSizeX;
        int y = index / Board.gridSizeX;
        if (board.tiles[Mathf.Min(x + 1, Board.gridSizeX - 1) + y * Board.gridSizeX].isBomb)
        {
            bombCount++;
        }
        if (board.tiles[Mathf.Max(x - 1, 0) + y * Board.gridSizeX].isBomb)
        {
            bombCount++;
        }

        if (board.tiles[x + Mathf.Min(y + 1, Board.gridSizeY - 1) * Board.gridSizeX].isBomb)
        {
            bombCount++;
        }
        if (board.tiles[x + Mathf.Max(y - 1, 0) * Board.gridSizeX].isBomb)
        {
            bombCount++;
        }


        if (x < Board.gridSizeX - 1 && y < Board.gridSizeY - 1 && board.tiles[(x + 1) + (y + 1) * Board.gridSizeX].isBomb)
        {
            bombCount++;
        }
        if (x > 0 && y < Board.gridSizeY - 1 && board.tiles[(x - 1) + (y + 1) * Board.gridSizeX].isBomb)
        {
            bombCount++;
        }
        if (x > 0 && y > 0 && board.tiles[(x - 1) + (y - 1) * Board.gridSizeX].isBomb)
        {
            bombCount++;
        }
        if (x < Board.gridSizeX - 1 && y > 0 && board.tiles[(x + 1) + (y - 1) * Board.gridSizeX].isBomb)
        {
            bombCount++;
        }
        return bombCount;


    }
    public void open()
    {
        if (revealed == true)
        {
            return;
        }
        revealed = true;
        AudioManager.instance.PlayTileSound();
        int bombCount = getCount();
        if (bombCount == 0) { openAdj(); }
        Debug.Log(bombCount);
        minesDisplay.text = "" + bombCount;
        image.color = new Color(0, 0, 0, 0);
        revealed = true;
        bool won = true;
        for (int i = 0; i < Board.gridSizeX * Board.gridSizeY; i++)
        {
            if (!board.tiles[i].isBomb && !board.tiles[i].revealed)
            {
                won = false;
            }
        }
        if (won)
        {
            board.StartWinningRoutine();
        }
        button.transform.gameObject.SetActive(false);
   
    }
    public void openAdj()
    {

        if (!isBomb && getCount() == 0) {
            int x = index % Board.gridSizeX;
            int y = index / Board.gridSizeX;
            if (y > 0)
            {
                board.tiles[(x) + (y - 1) * Board.gridSizeX].open();
            }
            if (y < Board.gridSizeY - 1)
            {
                board.tiles[(x) + (y + 1) * Board.gridSizeX].open();
            }
            if (x < Board.gridSizeX - 1)
            {
                board.tiles[(x + 1) + (y) * Board.gridSizeX].open();
            }
            if(x>0){
                board.tiles[(x - 1) + (y) * Board.gridSizeX].open();
            } 
        }
    
    }
    void Start()
    {
        button.onClick.AddListener(() => {Debug.Log(isBomb);
            if (!board.firstClick)
            {
                board.firstClick = true;
                isBomb = false;
            }
            if (board.gameOver)
            {
                return;
            }
            if (!isBomb)
            {
                open();
            }
            else
            {
                var animator = image.GetComponent<UIImageAnimator>();
                board.setGameOver();
                animator.timeOut.AddListener(() => {
                    AudioManager.instance.playSFX(explosion);
                    Instantiate(board.gameOverPrefab);

                
                });
                AudioManager.instance.playSFX(fuse);
                animator.playAnim();
            }

                button.transform.gameObject.SetActive(false); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
