using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //ObstaclePool ObjectPooler;

    ////public GameObject cubeprefab; (When signleton wasn't applied)

    //private void Start()
    //{
    //    ObjectPooler = ObstaclePool.Instance;
    //}


    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    ObjectPooler.SpawnFromPool("Obstacle", new Vector3(transform.localScale.x + Random.Range(-10.0f, 10.0f), transform.position.y, Random.Range(100.0f, 200.0f)), new Quaternion(-30, 0, 0,-7));
    //    ObjectPooler.SpawnFromPool("Taraffic", new Vector3(transform.localScale.x + Random.Range(-20.0f, 20.0f), transform.position.y, Random.Range(100.0f, 200.0f)), new Quaternion(0, 180, 0, 1));
    //    ObjectPooler.SpawnFromPool("Check Point", new Vector3(0.0f, 2.5f, 100.0f), Quaternion.identity);
    //    //Instantiate(cubeprefab, transform.position, Quaternion.identity); (When signleton wasn't applied)
    //}
}
