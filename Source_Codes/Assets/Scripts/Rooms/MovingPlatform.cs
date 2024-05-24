using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startpoint;
    public Transform endpoint;
    public float speed = 1.5f;
    int direction = 1;

    private void Update()
    {
        Vector2 target = currentMovementTarget();
        platform.position = Vector2.Lerp(platform.position, target, speed*Time.deltaTime);
        float distance = (target - (Vector2)platform.position).magnitude;
        if (distance <= 0.1f)
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startpoint.position;
        }
        else
        {
            return endpoint.position;
        }
    }

    private void OnDrawGizmos() 
    {
        if(platform!=null && startpoint!=null && endpoint!=null)
        {
            Gizmos.DrawLine(platform.transform.position, startpoint.position);
            Gizmos.DrawLine(platform.transform.position, endpoint.position);
        }
    }
}
