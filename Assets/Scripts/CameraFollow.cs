using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private float distance = 10.0f, tempDist = 30.0f, accelertion = 10.0f;
    private float height = 10.0f;
    private float heightDamping = 2.0f;
    private float rotationDamping = 3.0f;
    bool accelerated = false;
    float absVal = 0;
    // Update is called once per frame
    public void camUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (accelertion < 20)
                accelertion += 3 * Time.deltaTime;
        }
        else
        {
            if (accelertion > 10)
            {
                accelertion -= 6f * Time.deltaTime;
            }
            tempDist = accelertion;
        }

        //Debug.Log(tempDist + "//////////////////////" + accelertion);

        if (!target)
            return;

        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

      
                                         //target.position
        transform.position = new Vector3(target.position.x, target.position.y, target.position.y / 2) + new Vector3(absVal, 0, 0);

        transform.position = new Vector3(0, transform.position.y + 2, transform.position.z - tempDist);
        transform.position = transform.position + Random.insideUnitSphere * 0.7f * Time.deltaTime;
    }
}