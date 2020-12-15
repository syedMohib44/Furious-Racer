using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public List<Pool> pool = new List<Pool>();
    Queue<GameObject> poolObject;
    Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    private float x = 0;
    private float y = 0;
    private float z = 1;
    private Vector3 camPos;
    public static bool change = false;
    Pool poolPrefab;
    Dictionary<string, List<Pool>> objpoolDict = new Dictionary<string, List<Pool>>();
    private Vector3 playerPos;

    private Dictionary<int, string> obsticleName = new Dictionary<int, string>();
    private int count = 0;
    public class Pool
    {
        public int size;
        public string tag;
        public GameObject prefab;
    }

    public void SetObjects(int size, GameObject prefab, float xLeft, float xRight, float y, int objNo, bool? random = true)
    {
        if (this.playerPos == null)
            playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        poolPrefab = new Pool();
        poolPrefab.prefab = prefab;
        poolPrefab.prefab.name = prefab.name;
        poolPrefab.prefab.tag = prefab.tag;
        poolPrefab.size = size;
        this.y = y;
        int prefabObjNo = objNo;
        camPos = Camera.main.transform.position;

        poolObject = new Queue<GameObject>();
        for (int i = 0; i < size; i++)
        {
            float probablity = Random.Range(0.0f, 1.0f);
            GameObject obj = Instantiate(prefab);
            obj.SetActive(true);

            obj.GetComponent<ObjectMovement>().enabled = true;
            z += Random.Range(30.0f, 50.0f);
            if (random == true)
            {
                if (probablity > 0.5f)
                    this.x = Random.Range(0, xLeft);
                else
                    this.x = Random.Range(0, xRight);
            }
            else
            {
                if (probablity > 0.5f)
                    this.x = xLeft;
                else
                    this.x = xRight;
            }
            obj.transform.position = new Vector3(this.x, this.y, z);

            if (poolPrefab.prefab.tag != "Ramp")
                obj.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 0);

            poolObject.Enqueue(obj);
        }
        this.z = 0;
        obsticleName.Add(count, prefab.name);
        poolDictionary.Add(prefab.name, poolObject);
        count++;
    }

    public void IncreaseXY(float x, float y)
    {
        this.x = x;
        this.y = y;
    }


    void FixedUpdate()
    {

        if (obsticleName != null && obsticleName.Count > 0)
        {
            if (count >= obsticleName.Count)
                count = 0;

            SetRodPooling(obsticleName[count].ToString(), playerPos);
            count++;
        }
    }

    public void SetRodPooling(string key, Vector3 playerPos)
    {
        Queue<GameObject> objQ = poolDictionary[key];
        //for (int i = 0; i < objQ.Count; i++)
        //{
        if (objQ != null && objQ.Count > 0)
        {
            GameObject obj = objQ.Dequeue();

            //obj.SetActive(true);
            if (obj.transform.position.z < (playerPos.x - 15.0f))
            {
                if (obj.transform.position.x > 0)
                    obj.transform.position = new Vector3(Random.Range(0, -7), obj.transform.position.y, Random.Range(80.0f, 150.0f) + obj.transform.position.z);
                else
                    obj.transform.position = new Vector3(Random.Range(0, 7), obj.transform.position.y, 100.0f + obj.transform.localScale.z);
            }

            poolDictionary[key].Enqueue(obj);
        }
        //}
    }
}
