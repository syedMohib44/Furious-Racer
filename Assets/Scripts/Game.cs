using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private string level;
    private SceneryPool sp;
    private ObstaclePool op;
    private Dictionary<int, string> prefabNameDic;
    private GameObject player;
    private int count = 0;
    public RectTransform tra;

    public void InitializeStuff(GameObject player)
    {
        this.player = player;
    }

    void SetLevel1()
    {
        const float maxHeight = 4.9f, minHeight = 0.6f;
        GameObject tree1 = LoadObject(level + "/Tree1");
        //GameObject tree2 = LoadObject(level + "/Tree2");
        GameObject mountain1 = LoadObject(level + "/Mountain1");
        //GameObject rocks = LoadObject(level + "/Rocks");
        GameObject ramp = LoadObject(level + "/RampPoint");
        GameObject traffic = LoadObject(level + "/RollingRock");

        GameObject boost = GameObject.Find("Boost");
        GameObject checkPoint = GameObject.Find("CheckPoint");

        sp.SetObjects(10, tree1, -20.0f, 30.0f, Random.Range(10.0f, 20.0f), 0, false);
        sp.SetObjects(20, mountain1, -65.0f, 65.0f, 20.0f, 3, false);

        op.SetObjects(5, traffic, -10.0f, 10.0f, 0.95f, 0);
        op.SetObjects(3, ramp, -6.0f, 6.0f, -0.8f, 1);
        op.SetObjects(5, boost, -10.0f, 10.0f, 1.6f, 2);
        player.GetComponent<PlayerMovement>().InitializeLevel(maxHeight, minHeight);
    }

    void SetLevel2()
    {
        const float maxHeight = 4.9f, minHeight = 1.0f;
        GameObject tree1 = GameObject.Find("Tree1");
        GameObject tree2 = GameObject.Find("Tree2");
        GameObject mountain1 = GameObject.Find("Mountain1");

        GameObject traffic = GameObject.Find("BasicCar");
        GameObject ramp = GameObject.Find("RampPoint");
        GameObject checkPoint = GameObject.Find("CheckPoint");

        sp.SetObjects(20, tree1, -40.0f, 40.0f, Random.Range(5.0f, 20.0f), 0);
        sp.SetObjects(20, tree2, -40.0f, 40.0f, Random.Range(5.0f, 20.0f), 1);
        //sp.SetObjects(100, "Road Stripe", roadStripe, "RoadStripe", -10.0f, 10.0f, 0.0f, 2, false);
        sp.SetObjects(50, mountain1, -65.0f, 65.0f, 20.0f, 3, false);

        op.SetObjects(5, traffic, -10.0f, 10.0f, 0.95f, 0);
        op.SetObjects(5, ramp, -10.0f, 10.0f, -0.8f, 1);
        player.GetComponent<PlayerMovement>().InitializeLevel(maxHeight, minHeight);
        //op.SetObjects(5, checkPoint, -10.0f, 10.0f, 2.5f, 2);

        //SetInstances(sp.getObsticleName());
    }

    void SetLevel3()
    {
        const float maxHeight = 4.9f, minHeight = 1.0f;
        GameObject tree1 = GameObject.Find("Tree1");
        GameObject tree2 = GameObject.Find("Tree2");
        GameObject mountain1 = GameObject.Find("Mountain1");
        //GameObject roadStripe = GameObject.Find("RoadStripe");
        GameObject perpRoadStripe = GameObject.Find("PerpRoadStripe");


        GameObject traffic = GameObject.Find("BasicCar");
        GameObject perpTraffic = GameObject.Find("PerpBasicCar");
        GameObject ramp = GameObject.Find("RampPoint");
        GameObject stopBoard = GameObject.Find("StopBoard");

        sp.SetObjects(30, tree1, -25.0f, 25.0f, Random.Range(5.0f, 20.0f), 0);
        sp.SetObjects(30, tree2, -25.0f, 25.0f, Random.Range(5.0f, 20.0f), 1);
        sp.SetObjects(15, mountain1, -65.0f, 65.0f, 20.0f, 3, false);
        sp.SetObjects(1, perpRoadStripe, 0.0f, 0.0f, 20.0f, 3, false);
        sp.SetObjects(1, perpTraffic, 0.0f, 0.0f, 20.0f, 3, false);
        op.SetObjects(5, traffic, -10.0f, 10.0f, 0.95f, 0);
        op.SetObjects(5, ramp, -10.0f, 10.0f, -0.8f, 1);
        op.SetObjects(5, stopBoard, -18.0f, 18.0f, 0.0f, 2);
        player.GetComponent<PlayerMovement>().InitializeLevel(maxHeight, minHeight);

        //SetInstances(sp.getObsticleName());
    }


    void SetLevel4()
    {
        const float maxHeight = 4.9f, minHeight = 0.6f;
        GameObject tree1 = GameObject.Find("Tree1");
        GameObject tree2 = GameObject.Find("Tree2");
        GameObject mountain1 = GameObject.Find("Mountain1");
        //GameObject roadStripe = GameObject.Find("RoadStripe");
        GameObject perpRoadStripe = GameObject.Find("PerpRoadStripe");


        GameObject traffic = GameObject.Find("BasicCar");
        GameObject perpTraffic = GameObject.Find("PerpBasicCar");
        GameObject ramp = GameObject.Find("RampPoint");
        GameObject stopBoard = GameObject.Find("StopBoard");

        sp.SetObjects(100, tree1, -60.0f, 60.0f, Random.Range(5.0f, 20.0f), 0);
        sp.SetObjects(100, tree2, -60.0f, 60.0f, Random.Range(5.0f, 20.0f), 1);
        sp.SetObjects(50, mountain1, -65.0f, 65.0f, 20.0f, 3, false);
        sp.SetObjects(1, perpRoadStripe, 0.0f, 0.0f, 20.0f, 3, false);
        sp.SetObjects(1, perpTraffic, 0.0f, 0.0f, 20.0f, 3, false);
        op.SetObjects(5, traffic, -10.0f, 10.0f, 0.95f, 0);
        op.SetObjects(5, ramp, -10.0f, 10.0f, -0.8f, 1);
        player.GetComponent<PlayerMovement>().InitializeLevel(maxHeight, minHeight);
        //SetInstances(sp.getObsticleName());
    }


    void SetLevel5()
    {
        const float maxHeight = 4.9f, minHeight = 0.6f;
        GameObject tree1 = GameObject.Find("Tree1");
        GameObject tree2 = GameObject.Find("Tree2");
        GameObject mountain1 = GameObject.Find("Mountain1");
        GameObject rocks = GameObject.Find("Rocks");

        GameObject traffic = GameObject.Find("BasicCar");
        GameObject ramp = GameObject.Find("RampPoint");
        GameObject checkPoint = GameObject.Find("CheckPoint");

        sp.SetObjects(10, tree1, -25.0f, 25.0f, Random.Range(5.0f, 20.0f), 0);
        sp.SetObjects(10, tree2, -25.0f, 25.0f, Random.Range(5.0f, 20.0f), 1);
        //sp.SetObjects(100, "Road Stripe", roadStripe, "RoadStripe", -10.0f, 10.0f, 0.0f, 2, false);
        sp.SetObjects(6, rocks, -5.0f, 5.0f, 50.0f, 2, false);
        sp.SetObjects(50, mountain1, -65.0f, 65.0f, 20.0f, 3, false);

        op.SetObjects(5, traffic, -10.0f, 10.0f, 0.95f, 0);
        op.SetObjects(5, ramp, -10.0f, 10.0f, -0.8f, 0);
        op.SetObjects(5, checkPoint, -10.0f, 10.0f, 2.5f, 0);
        player.GetComponent<PlayerMovement>().InitializeLevel(maxHeight, minHeight);

        //SetInstances(sp.getObsticleName());
    }

    void SetLevel6()
    {
        const float maxHeight = 4.9f, minHeight = 0.6f;
        GameObject tree1 = GameObject.Find("Tree1");
        GameObject tree2 = GameObject.Find("Tree2");
        GameObject mountain1 = GameObject.Find("Mountain1");
        //GameObject roadStripe = GameObject.Find("RoadStripe");
        GameObject perpRoadStripe = GameObject.Find("PerpRoadStripe");


        GameObject traffic = GameObject.Find("BasicCar");
        GameObject perpTraffic = GameObject.Find("PerpBasicCar");
        GameObject ramp = GameObject.Find("RampPoint");
        GameObject stopBoard = GameObject.Find("StopBoard");

        sp.SetObjects(50, tree1, -50.0f, 50.0f, Random.Range(5.0f, 20.0f), 0);
        sp.SetObjects(50, tree2, -50.0f, 50.0f, Random.Range(5.0f, 20.0f), 1);
        sp.SetObjects(50, mountain1, -65.0f, 65.0f, 20.0f, 3, false);
        //sp.SetObjects(1, perpRoadStripe, 0.0f, 0.0f, 20.0f, 3, false);
        //sp.SetObjects(1, perpTraffic, 0.0f, 0.0f, 20.0f, 3, false);
        op.SetObjects(5, traffic, -10.0f, 10.0f, 0.95f, 0);
        op.SetObjects(5, ramp, -10.0f, 10.0f, -0.8f, 1);
        op.SetObjects(5, stopBoard, -18.0f, 18.0f, 0.0f, 2);
        player.GetComponent<PlayerMovement>().InitializeLevel(maxHeight, minHeight);
        //SetInstances(sp.getObsticleName());
    }

    public void SetLevel(string level = "/Level1")
    {
        this.level = level;
        sp = LoadObjectWithInstanciate(level + "/Scenery").GetComponent<SceneryPool>();
        op = LoadObjectWithInstanciate(level + "/Spawner").GetComponent<ObstaclePool>();

        if (SceneManager.GetActiveScene().name == "Level1")
            SetLevel1();
        else if (SceneManager.GetActiveScene().name == "Level2")
            SetLevel2();
        else if (SceneManager.GetActiveScene().name == "Level3")
            SetLevel3();
        else if (SceneManager.GetActiveScene().name == "Level4")
            SetLevel4();
        else if (SceneManager.GetActiveScene().name == "Level5")
            SetLevel5();
        else if (SceneManager.GetActiveScene().name == "Level6")
            SetLevel6();
    }

    //public void SetInstances(Dictionary<int, string> prefabNameDic)
    //{
    //    this.prefabNameDic = prefabNameDic;
    //}
    private GameObject LoadObjectWithInstanciate(string path)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        return Instantiate(obj);
    }
    private GameObject LoadObject(string path)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        return obj;
    }
    void Update()
    {
        // if (tra.localScale.x > 0)
        //     tra.localScale -= new Vector3(0.08f, 0, 0) * Time.deltaTime;  

    }
}
