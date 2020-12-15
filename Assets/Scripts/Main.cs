using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LEVEL
{
    LEVEL1 = 1,
    LEVEL2 = 2,
    LEVEL3 = 3,
    LEVEL4 = 4,
    LEVEL5 = 5,
    LEVEL6 = 6,
    LEVEL7 = 7
}

public class Main : MonoBehaviour
{ 
    private GameObject game;
    private GameObject player;
    void Start()
    {
        game = Resources.Load<GameObject>("Game");//GameObject.Find("Game").GetComponent<Game>();
        Instantiate(game);
        player = GameObject.FindGameObjectWithTag("Player");
        SetLevel(LEVEL.LEVEL1.ToString(), player);
        //SetLevel(LEVEL.LEVEL3.ToString(), player);
        //SetLevel(LEVEL.LEVEL3.ToString());
        //SetLevel(LEVEL.LEVEL4.ToString());
        //SetLevel(LEVEL.LEVEL5.ToString());
        //SetLevel(LEVEL.LEVEL6.ToString());
        //SetLevel(LEVEL.LEVEL7.ToString());
    }

    void SetLevel(string level, GameObject player)
    {
        Game gameInstance = game.GetComponent<Game>();
        gameInstance.InitializeStuff(player);
        gameInstance.SetLevel(level);
    }
}
