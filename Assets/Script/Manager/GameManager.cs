using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Completed;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public static GameManager   instance;



    public  int                 playerFoodPoints;
    public  bool                playersTurn;
    private BoardManager        boardManager;
    private int level = 3;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        boardManager = gameObject.GetComponent<BoardManager>();

        InitGame();

    }

    private void InitGame()
    {
        boardManager.SetupScene(level);
    }


}
