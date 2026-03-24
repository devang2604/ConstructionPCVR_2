using UnityEngine;

public class RoboFollow : MonoBehaviour
{
    public Transform player;
    public float followDistance = 2f;
    public float heightOffset = 1.5f;
    public float followSpeed = 3f;

    public float hoverAmplitude = 0.2f;
    public float hoverFrequency = 2f;

    Vector3 velocity;

    void Update()
    {
        if (!player) return;

        // Target position behind player
        Vector3 targetPos = player.position
                            - player.forward * followDistance
                            + Vector3.up * heightOffset;

        // Smooth follow
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos + HoverOffset(),
            ref velocity,
            0.3f
        );
    }

    Vector3 HoverOffset()
    {
        float y = Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;
        return new Vector3(0, y, 0);
    }
}