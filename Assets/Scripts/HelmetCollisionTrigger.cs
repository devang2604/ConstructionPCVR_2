using System.Collections;
using UnityEngine;

public class HelmetCollisionTrigger : MonoBehaviour
{
    [Header("Animators")]
    public Animator animator1;
    public Animator animator2;

    [Header("GameObjects to Toggle Active")]
    public GameObject toggleObject1;
    public GameObject toggleObject2;

    [Header("Colliders to Check (Assign in Inspector)")]
    public Collider fallingObjectCollider;
    public Collider helmetCollider;

    [Header("Settings")]
    public float toggleDelay = 5f;

    private bool hasTriggered = false;

    private void Start()
    {
        StartCoroutine(ToggleAfterDelay());
    }

    private IEnumerator ToggleAfterDelay()
    {
        yield return new WaitForSeconds(toggleDelay);

        if (toggleObject1 != null)
            toggleObject1.SetActive(!toggleObject1.activeSelf);

        if (toggleObject2 != null)
            toggleObject2.SetActive(!toggleObject2.activeSelf);

        Debug.Log("GameObjects toggled after " + toggleDelay + " seconds.");
    }

    private void Update()
    {
        if (hasTriggered) return;
        if (fallingObjectCollider == null || helmetCollider == null) return;

        // Only check when both objects are active in the scene
        if (!fallingObjectCollider.gameObject.activeInHierarchy) return;
        if (!helmetCollider.gameObject.activeInHierarchy) return;

        if (fallingObjectCollider.bounds.Intersects(helmetCollider.bounds))
        {
            hasTriggered = true;
            Debug.Log("Collision detected! Firing animations.");
            TriggerAnimations();
        }
    }

    private void TriggerAnimations()
    {
        if (animator1 != null)
            animator1.SetTrigger("Next");
        else
            Debug.LogWarning("Animator1 is NULL!");

        if (animator2 != null)
            animator2.SetTrigger("Next");
        else
            Debug.LogWarning("Animator2 is NULL!");
    }
}