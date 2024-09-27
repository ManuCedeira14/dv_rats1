using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float XMove;
    private float YMove;
    private float XRotation;
    [SerializeField] private Transform Player;
    [SerializeField] private int sensibility;
    public Vector2 LockAxis;

    private void Update()
    {
        XMove = LockAxis.x * sensibility * Time.deltaTime;
        YMove = LockAxis.y * sensibility * Time.deltaTime;

        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);

        Player.Rotate(Vector3.up * XMove);
    }
}
