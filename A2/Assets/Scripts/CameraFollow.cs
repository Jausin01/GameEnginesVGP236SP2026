using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desired = target.position;
        desired.z = transform.position.z;

        transform.position = Vector3.Lerp(
            transform.position,
            desired,
            Time.deltaTime * smooth
        );
    }
}
