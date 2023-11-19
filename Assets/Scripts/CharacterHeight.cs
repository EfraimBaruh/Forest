using UnityEngine;

/// <summary>
/// This script initializes characters height and updates based on changes in the inspector.
/// Attach the script on to the character gameobject!
/// </summary>
public class CharacterHeight : MonoBehaviour
{
    [Range(1.45f, 2.3f)]
    public float Height;

    public float SmoothAdoption;

    private void Start()
    {
        // Set initial height
        Vector3 newPosition = new Vector3(transform.position.x, Height, transform.position.z);
        transform.position = newPosition;
    }

    private void Update()
    {
        RaycastHit hit;
        // Update character position accordingly with height
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 10))
        {
            Vector3 ground = hit.point;

            Vector3 targetPosition = new Vector3(transform.position.x, (ground.y + Height), transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * SmoothAdoption);

        }
    }
}
