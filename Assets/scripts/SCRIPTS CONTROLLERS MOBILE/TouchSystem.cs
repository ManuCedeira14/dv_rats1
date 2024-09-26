using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchSystem : MonoBehaviour
{
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private LayerMask layerMask;

    void Update()
    {
        CheckTouches();
    }

    void CheckTouches()
    {

        foreach (Touch touch in Input.touches)
        {
            //if (touch.phase != TouchPhase.Began) continue;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
                {
                    var spheres = Instantiate(spherePrefab);
                    spheres.transform.position = new Vector3(hit.point.x, hit.point.y + 3f, hit.point.z);
                }
            }
        }
    }
}