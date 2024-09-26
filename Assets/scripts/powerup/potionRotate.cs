using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionRotate : MonoBehaviour
{
    [SerializeField] int rotationSpeed;
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
