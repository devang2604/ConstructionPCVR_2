using UnityEngine;

public class RoboLook : MonoBehaviour
{
    public Transform player;
    public Transform cameraTransform;
    public RoboFollow followScript;

    public float rotateSpeed = 6f;

    void Update()
    {
        if (!player || !cameraTransform || !followScript) return;

        Transform target = followScript.isInFocusMode ? cameraTransform : player;

        Vector3 direction = target.position - transform.position;
        direction.y *= 0.6f;

        if (direction == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * rotateSpeed
        );
    }
}