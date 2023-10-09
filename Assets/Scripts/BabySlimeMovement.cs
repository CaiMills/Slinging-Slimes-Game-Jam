using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BabySlimeMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            flip();
            currentPoint = pointA.transform; //makes it so it doesnt need to exactly touch point A, but instead just needs to be near it
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform; //makes it so it doesnt need to exactly touch point B, but instead just needs to be near it
        }
    }

    private void flip() //this is the function that flips the sprite
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos() //creates a debug visual that can only be seen in the editor
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f); //creates a visual for the waypoints (circle)
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position); //creates a visual for the baby slimes patrol path
    }
}
