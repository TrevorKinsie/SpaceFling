using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class SphereController : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;

    public LineRenderer line;

    public Vector3 lastPos;

    public Rigidbody2D rb;

    public GameObject planet;

    void OnStart()
    {
        line = gameObject.GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;


        //transform.position = curPosition;

        Debug.DrawLine(transform.position, curPosition);

        line.SetVertexCount(2);
        line.SetPosition(0, transform.position);
        line.SetPosition(1, curPosition);

        lastPos = curPosition;

    }

    void OnMouseUp()
    {
        //line.SetPosition(1, transform.position);

        Vector3 goHere = transform.position - lastPos;

        //Vector2 goHere = new Vector2(lastPos.x, lastPos.y);

        rb.AddForce(goHere * 100.0f);

        var pe2d = planet.GetComponent<PointEffector2D>();

        pe2d.enabled = true;

        // trail of where you once were, and have it persist throughout the play through

    }

    void FollowTheSphere()
    {
        line.setPosition()
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            Debug.Log("you did it");
            //.      Time.timeScale = 0;
        }
    }
}
