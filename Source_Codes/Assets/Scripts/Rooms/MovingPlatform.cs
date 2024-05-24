using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform posA, posB;
    [SerializeField] int speed;
    private Vector3 targetPos;

    void Start()
    {
        targetPos = posB.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.05f) targetPos = posB.position;
        if (Vector2.Distance(transform.position, posB.position) < 0.05f) targetPos = posA.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
    }

   private void OnCollisionEnter2D(Collision2D collision) 
   {
     
        collision.transform.SetParent(transform);

    }

    private void OnCollisionExit2D(Collision2D collision) 
   {
     
        collision.transform.SetParent(null);;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(posA.position, posB.position);
    }
}
