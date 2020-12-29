using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
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
            transform.position += new Vector3(0, 0, -5) * Time.deltaTime;
            Debug.Log((-transform.localScale.x / 2 + transform.position.x / 2) + "  -----------  " + transform.name + " ----------- " + transform.GetComponentInChildren<Renderer>().bounds.center);
            transform.RotateAround(transform.GetComponentInChildren<Renderer>().bounds.center, new Vector3(1, 0, 0), -1);
            //transform.position = Vector3.Lerp(new Vector3(transform.position.x, 0.0f, transform.position.z), new Vector3(transform.position.x, 2.0f, transform.position.z), Mathf.PingPong(Time.time * 2.0f, 1.0f));

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

