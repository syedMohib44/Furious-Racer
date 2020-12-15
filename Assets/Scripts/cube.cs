using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour,IpooledObject {

    public float upforce = 1f;
    public float sideforce = .1f;
    // Use this for initialization
    public void OnObjectSpawn()
    {
        float xforce = Random.Range(-sideforce, sideforce);
        float yforce = Random.Range(upforce / 2, upforce);
        float zforce = Random.Range(-sideforce, sideforce);

        Vector3 force = new Vector3(xforce, yforce, zforce);

        transform.Translate(0, 0, zforce + 2 * Time.deltaTime);   
		
	}
	
}
