using UnityEngine;

public class MoveWithObject : MonoBehaviour
{
    public GameObject otherGameObject; // The other GameObject that should move with this one

    private Vector3 lastPosition;

    void Start()
    {
        // Store the initial position of the GameObject
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate the change in position
        Vector3 deltaPosition = transform.position - lastPosition;

        // Apply the change in position to the other GameObject
        if (otherGameObject != null)
        {
            otherGameObject.transform.position += deltaPosition;
        }

        // Update the stored position
        lastPosition = transform.position;
    }
}