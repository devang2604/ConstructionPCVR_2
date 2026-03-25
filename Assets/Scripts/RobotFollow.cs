using UnityEngine;

public class RoboFollow : MonoBehaviour
{
    public Transform player;
    public Transform cameraTransform;

    public float followSmoothness = 5f;
    public Vector3 shoulderOffset = new Vector3(0.6f, 1.4f, -0.8f);

    public float focusDistance = 1.2f;
    public float focusHeightOffset = -0.2f;
    public float focusSmoothness = 6f;

    public float hoverAmplitude = 0.05f;
    public float hoverFrequency = 1.5f;

    public bool isInFocusMode;

    void Update()
    {
        if (!player || !cameraTransform) return;

        if (Input.GetKeyDown(KeyCode.P))
        {
            isInFocusMode = !isInFocusMode;
        }

        Vector3 targetPos = isInFocusMode ? GetFocusPosition() : GetShoulderPosition();

        float smooth = isInFocusMode ? focusSmoothness : followSmoothness;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos + HoverOffset(),
            Time.deltaTime * smooth
        );
    }

    Vector3 GetShoulderPosition()
    {
        return player.TransformPoint(shoulderOffset);
    }

    Vector3 GetFocusPosition()
    {
        return cameraTransform.position
               + cameraTransform.forward * focusDistance
               + cameraTransform.up * focusHeightOffset;
    }

    Vector3 HoverOffset()
    {
        float y = Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;
        return new Vector3(0, y, 0);
    }
}