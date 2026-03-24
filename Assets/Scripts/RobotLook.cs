using UnityEngine;

public class RoboLook : MonoBehaviour
{
    public Transform player;
    public float rotateSpeed = 5f;

    void Update()
    {
        if (!player) return;

        Vector3 direction = player.position - transform.position;
        direction.y *= 0.3f;

        if (direction == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * rotateSpeed
        );
    }
}