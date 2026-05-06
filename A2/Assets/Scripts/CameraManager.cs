using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] Transform p1;
    [SerializeField] Transform p2;

    [Header("Cameras")]
    [SerializeField] Camera singleCam;
    [SerializeField] Camera cam1;
    [SerializeField] Camera cam2;

    [Header("Settings")]
    [SerializeField] float splitDistance = 8f;
    [SerializeField] float mergeDistance = 5f;
    [SerializeField] float smooth = 5f;

    float blend; // 0 = single, 1 = split
    bool wasSplit;



    void LateUpdate()
    {
        float dist = Vector2.Distance(p1.position, p2.position);

        float targetBlend = blend;

        if (dist > splitDistance)
            targetBlend = 1f;
        else if (dist < mergeDistance)
            targetBlend = 0f;

        blend = Mathf.Lerp(blend, targetBlend, Time.deltaTime * smooth);

        ApplyMode();
    }

    void ApplyMode()
    {
        bool split = blend > 0.5f;

        singleCam.enabled = true;
        cam1.enabled = true;
        cam2.enabled = true;

        if (split)
        {
            singleCam.rect = new Rect(0, 0, 0, 0);

            cam1.rect = new Rect(0, 0, 0.5f, 1);
            cam2.rect = new Rect(0.5f, 0, 0.5f, 1);
        }
        else
        {
            singleCam.rect = new Rect(0, 0, 1, 1);

            cam1.rect = new Rect(0, 0, 0, 0);
            cam2.rect = new Rect(0, 0, 0, 0);

            
            if (wasSplit)
            {
                SnapSingleCam();
            }

            MoveSingleCam();
        }

        wasSplit = split;
    }

    void SnapSingleCam()
    {
        Vector3 mid = (p1.position + p2.position) / 2f;
        mid.z = singleCam.transform.position.z;

        singleCam.transform.position = mid;
    }


    void MoveSingleCam()
    {
        Vector3 mid = (p1.position + p2.position) / 2f;
        mid.z = singleCam.transform.position.z;

        singleCam.transform.position = Vector3.Lerp(
            singleCam.transform.position,
            mid,
            Time.deltaTime * smooth
        );
    }


}
