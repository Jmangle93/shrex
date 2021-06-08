using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public bool invertY;
    public float maxViewAngle;
    public float minViewAngle;
    public Vector3 offset;
    public Transform pivot;
    public float rotateSpeed;
    public Transform target;
    public bool useOffsetValues;
    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }
        // We now have a pivot Transform in PlayerController which we manually filled with camera's pivot. Don't want its parent set at runtime.
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = null;//target.transform;
        // Hide cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void CheckGroundClipping()
    {
        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
    }

    void CheckSkyClipping()
    {
        if (pivot.rotation.eulerAngles.x > maxViewAngle && 180f > pivot.rotation.eulerAngles.x)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }
        else if (pivot.rotation.eulerAngles.x > 180f && (360f - minViewAngle) > pivot.rotation.eulerAngles.x)
        {
            pivot.rotation = Quaternion.Euler((360f - minViewAngle), 0, 0);
        }
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if (!invertY)
        {
            vertical *= -1;
        }
        pivot.Rotate(0, horizontal, 0);
        pivot.Rotate(vertical, 0, 0);

        CheckSkyClipping();

        float pivotYAngle = pivot.eulerAngles.y;
        float pivotXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(pivotXAngle, pivotYAngle, 0);
        transform.position = target.position - (rotation * offset);

        CheckGroundClipping();

        transform.LookAt(target);
    }
}
