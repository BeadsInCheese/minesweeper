using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update
    public List<tile> tiles = new List<tile>();
    public GameObject gameOverPrefab;
    public GameObject winPrefab;
    public bool gameOver = false;
    public UnityEvent gameEnd;
    public bool firstClick=false;
    public GameObject tilePrefab;
    public static int gridSizeX = 9;
    public static int gridSizeY = 9;
    public float buttonScale = 1;
    public static float mineProb = 0.1f;
    public void StartWinningRoutine()
    {

        setGameOver();
        var win=Instantiate(winPrefab);
        

    }
    public void setGameOver() {  
        
        gameOver = true; 
        gameEnd.Invoke();
    
    }
    void Start()
    {
        List<bool> mines = new List<bool>();
        for (int i = 0; i < gridSizeX * gridSizeY; i++)
        { 
            if(Random.Range(0.0f, 1.0f) < mineProb)
            {
                mines.Add(true);
            }
            else
            {
                mines.Add(false);
            }
        
        }
            for (int i = 0; i < gridSizeX * gridSizeY; i++) {
            var tile=Instantiate(tilePrefab);
            tile.transform.SetParent(transform, false);
            tile.transform.localPosition =new Vector3((i%gridSizeX)*30,(i/gridSizeX)*30,0);
            var tileComp = tile.GetComponent<tile>();
            tileComp.isBomb = mines[i];
            tileComp.board = this;
            tileComp.index = i;
            tiles.Add(tile.GetComponent<tile>());
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gridSizeX * gridSizeY; i++)
        {
            transform.GetChild(i).transform.localPosition= new Vector3((i % gridSizeX) * 100*(9.0f/gridSizeY), (i / gridSizeX) * 100  * (9.0f / gridSizeY), 0);
            transform.GetChild(i).transform.localScale = Vector3.one*buttonScale  * (9.0f / gridSizeY);
        }
    }
}
