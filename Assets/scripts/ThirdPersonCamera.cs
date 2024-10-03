using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform target;
    public float distanceFromTarget = 5.0f;
    public float distanceFromTargetOnY = 5.0f;
    public float sensitivityX = 10f;
    public float sensitivityY = 10f;
    public float minYAngle = -40f;
    public float maxYAngle = 80f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationX = angles.y;
        rotationY = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;

            rotationY = Mathf.Clamp(rotationY, minYAngle, maxYAngle);

            Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
            Vector3 offset = new Vector3(0, distanceFromTargetOnY, -distanceFromTarget);
            transform.position = target.position + rotation * offset;

            transform.LookAt(target);
        }
    }
}
