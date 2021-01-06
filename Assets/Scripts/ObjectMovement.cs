﻿using UnityEngine;
using System.Collections.Generic;
public class ObjectMovement : MonoBehaviour
{
    List<Vector4> v = new List<Vector4>();
    void Start()
    {
        v.Add(new Vector4(0, 0, 0, 0));
    }
    void FixedUpdate()
    {

        if (gameObject.name == "PerpBasicCar")
            transform.position += new Vector3(10.0f, 0, -10.0f) * Time.deltaTime;
        else if (gameObject.tag == "Boost")
        {
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, 1.2f, transform.position.z), new Vector3(transform.position.x, 0.8f, transform.position.z), Mathf.PingPong(Time.time * 1.0f, 1.0f));
            transform.position += new Vector3(0, 0, -5) * Time.deltaTime;
        }
        else if (gameObject.tag == "RR")
        {
            if (v.Count <= gameObject.GetComponentInChildren<MeshFilter>().mesh.vertices.Length)
                v.Add(new Vector4(4, 4, 4, 4));

            gameObject.GetComponentInChildren<MeshFilter>().mesh.SetVertexBufferData(v, 0, 0, v.Count);
            // foreach (Mesh mesh in gameObject.GetComponent<Mesh>().)
            // {

            // }
            transform.position += new Vector3(0, 0, -15) * Time.deltaTime;
            transform.RotateAround(transform.GetComponentInChildren<Renderer>().bounds.center, new Vector3(1, 0, 0), -2.5f);
            //transform.position = Vector3.Lerp(new Vector3(transform.position.x, 7.0f, transform.position.z), new Vector3(transform.position.x, 10.0f, transform.position.z), 0);
        }
        else
            transform.position -= new Vector3(0, 0, 10.0f) * Time.deltaTime;
    }

    Vector3 ClampPoint(Vector3 point, Vector3 segmentStart, Vector3 segmentEnd)
    {
        return ClampProjection(ProjectPoint(point, segmentStart, segmentEnd), segmentStart, segmentEnd);
    }

    Vector3 ProjectPoint(Vector3 point, Vector3 segmentStart, Vector3 segmentEnd)
    {
        return segmentStart + Vector3.Project(point - segmentStart, segmentEnd - segmentStart);
    }

    Vector3 ClampProjection(Vector3 point, Vector3 start, Vector3 end)
    {
        var toStart = (point - start).sqrMagnitude;
        var toEnd = (point - end).sqrMagnitude;
        var segment = (start - end).sqrMagnitude;
        if (toStart > segment || toEnd > segment) return toStart > toEnd ? end : start;
        return point;
    }
}
