using UnityEngine;

public enum LEVEL
{
    LEVEL1,
    LEVEL2,
    LEVEL3,
    LEVEL4,
    LEVEL5,
    LEVEL6,
    LEVEL7
}

public class Main : MonoBehaviour
{
    private GameObject game;
    private GameObject player;
    void Start()
    {
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
        game = Instantiate(Resources.Load<GameObject>("Game"));
        CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();

        //GameObject obj = Instantiate(game);
        game.name = "Game";
        Game gameScript = game.GetComponent<Game>();
        gameScript.InitializeStuff(player);
        gameScript.SetLevel(level);
    }
}
