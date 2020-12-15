using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera_Controller : MonoBehaviour
{
    private CameraFollow camFollow;
    private PlayerMovement playerMovement;
    void Start()
    {
        camFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        camFollow.camUpdate();
    }
}
