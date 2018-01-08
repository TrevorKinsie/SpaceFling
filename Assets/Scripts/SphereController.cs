using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class SphereController : MonoBehaviour {//,  IBeginDragHandler, IDragHandler, IEndDragHandler {
                                               /*
                                               public static GameObject DraggedInstance;

                                               Vector3 _startPosition;
                                               Vector3 _offsetToMouse;
                                               float _zDistanceToCamera;

                                               #region Interface Implementations

                                               public void OnBeginDrag(PointerEventData eventData)
                                               {
                                                   DraggedInstance = gameObject;
                                                   _startPosition = transform.position;
                                                   _zDistanceToCamera = Mathf.Abs(_startPosition.z - Camera.main.transform.position.z);

                                                   _offsetToMouse = _startPosition - Camera.main.ScreenToWorldPoint(
                                                       new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
                                                   );
                                               }

                                               public void OnDrag(PointerEventData eventData)
                                               {
                                                   if (Input.touchCount > 1)
                                                       return;

                                                   transform.position = Camera.main.ScreenToWorldPoint(
                                                       new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
                                                       ) + _offsetToMouse;
                                               }

                                               public void OnEndDrag(PointerEventData eventData)
                                               {
                                                   DraggedInstance = null;
                                                   _offsetToMouse = Vector3.zero;

                                               }

                                               #endregion
                                               */

    private Vector3 screenPoint;
    private Vector3 offset;

    public LineRenderer line;

    public Vector3 lastPos;

    public Rigidbody2D rb;

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
        line.SetPosition(1, transform.position);

        Vector2 goHere = new Vector2(lastPos.x, lastPos.y);

        rb.AddForce(goHere * 100.0f);
    }
}
