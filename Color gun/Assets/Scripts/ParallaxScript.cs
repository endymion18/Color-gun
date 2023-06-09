using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    [SerializeField] private Transform followingTarget;
    [SerializeField] [Range(0f, 1f)] private float parallaxStrength;
    [SerializeField] private bool disableVerticalParallax;

    private Vector3 targetPreviousPosition;

    private void Start()
    {
        if (!followingTarget)
        {
            followingTarget = Camera.main.transform;

            targetPreviousPosition = followingTarget.position;
        }
    }

    private void Update()
    {
        var delta = followingTarget.position - targetPreviousPosition;

        if (disableVerticalParallax) delta.y = 0;

        targetPreviousPosition = followingTarget.position;
        transform.position += delta * parallaxStrength;
    }
}