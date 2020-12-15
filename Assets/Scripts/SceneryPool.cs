using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryPool : MonoBehaviour
{
    public List<Pool> pool = new List<Pool>();
    Queue<GameObject> poolObject;
    Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    private float x = 0, y = 0, z = 1, resetRange = 15.0f, resetPositionZ = 100.0f;
    private Vector3 camPos;
    public static bool change = false;
    Pool poolPrefab;
    Dictionary<string, List<Pool>> objpoolDict = new Dictionary<string, List<Pool>>();

    private Dictionary<int, string> obsticleName = new Dictionary<int, string>();
    private int count = 0;
    public class Pool
    {
        public int size;
        public string tag;
        public GameObject prefab;
    }

    public Dictionary<int, string> getObsticleName()
    {
        return obsticleName;
    }
    /**
     * default random = true
     */
    public void SetObjects(int size, GameObject prefab, float xLeft, float xRight, float z, int objNo, bool? random = true)
    {
        poolPrefab = new Pool();
        poolPrefab.prefab = prefab;
        poolPrefab.prefab.name = prefab.name;
        poolPrefab.prefab.tag = tag;
        poolPrefab.tag = tag;
        poolPrefab.size = size;
        this.y = prefab.transform.position.y;
        int prefabObjNo = objNo;
        camPos = Camera.main.transform.position;

        poolObject = new Queue<GameObject>();
        for (int i = 0; i < size; i++)
        {
            float probablity = Random.Range(0.0f, 1.0f);
            GameObject obj = Instantiate(prefab);
            obj.SetActive(true);

            obj.GetComponent<ObjectMovement>().enabled = true;
            if (random == true)
            {
                this.z += Random.Range(5.0f, 20.0f);
                if (probablity > 0.5f)
                    this.x = xLeft + Random.Range(-10.0f, 10.0f);
                else
                    this.x = xRight + Random.Range(-10.0f, 10.0f);
            }
            else
            {
                this.z += z;
                if (probablity < 0.5f)
                    this.x = xLeft;
                else
                    this.x = xRight;
            }
            obj.transform.position = new Vector3(this.x, this.y, this.z);
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


    public void SetRodPooling(string key, Vector3 playerPos)
    {

        Queue<GameObject> objQ = poolDictionary[key];
        for (int i = 0; i < objQ.Count; i++)
        {
            GameObject obj = objQ.Dequeue();
            obj.SetActive(true);
            obj.transform.position = new Vector3(obj.transform.position.x + (playerPos.x * 3), obj.transform.position.y, obj.transform.position.z);

            poolDictionary[key].Enqueue(obj);
        }
    }


    void FixedUpdate()
    {
        if (obsticleName != null)
        {
            if (count >= obsticleName.Count)
                count = 0;

            SetRodPooling(obsticleName[count].ToString());
            count++;
        }
    }


    public void SetRodPooling(string key)
    {
        // if (key == "Rocks")
        // {
        //     resetPositionZ = 250.0f;
        //     resetRange = 30.0f;
        // }
        if (key == "Mountain1")
        {
            resetPositionZ = 50.0f;
            resetRange = 15.0f;
        }
        else if (key == "Tree1" || key == "Tree2")
        {
            resetPositionZ = 500.0f;
            resetRange = 50.0f;
        }
        else
        {
            resetPositionZ = 100.0f;
            resetRange = 15.0f;
        }
        Queue<GameObject> objQ = poolDictionary[key];
        //for (int i = 0; i < objQ.Count; i++)
        //{
        if (objQ != null && objQ.Count > 0)
        {
            GameObject obj = objQ.Dequeue();
            //if(obj.transform.localScale.z == 1)
            //    resetPositionZ = 800.0f;

            obj.SetActive(true);
            if (obj.transform.position.z < (resetRange + obj.transform.localScale.z) * -1)
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, ((resetPositionZ * obj.transform.localScale.z) / 5));

            poolDictionary[key].Enqueue(obj);
        }
        //}
    }
}
