using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickController : Controller, IDragHandler, IEndDragHandler
{
    private Vector3 _initialPosition;
    [SerializeField, Range(50, 200)] private float maxMagnitude;
    [SerializeField] private float _jumpForce;


    private void Start()
    {
        _initialPosition = transform.position;
    }

    public override Vector3 GetMovement()
    {
        var finalDirection = new Vector3(_moveDir.x, 0, _moveDir.y);
        finalDirection /= maxMagnitude;

        return finalDirection;
    }

    public override Vector3 GetJump()
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _moveDir = Vector3.ClampMagnitude((Vector3)eventData.position - _initialPosition, maxMagnitude);
        transform.position = _initialPosition + _moveDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _initialPosition;
        _moveDir = Vector3.zero;
    }
    
}