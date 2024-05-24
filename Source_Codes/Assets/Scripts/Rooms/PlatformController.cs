using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] Transform posA, posB;
    [SerializeField] int speed;
    private Vector2 targetPos;
    void Start()
    {
        targetPos = posB.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;
        if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
        transform.position = new Vector3(transform.position.x,transform.position.y,1);
    }

   private void OnTriggerEnter2D(Collider2D collision) 
   {
        if (collision.CompareTag("Player"))
        {   
            Debug.Log("enter trigger");
            collision.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
   {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(posA.position, posB.position);
    }
}
