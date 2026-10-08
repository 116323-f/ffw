using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA;
    public Transform posB;

    [SerializeField] private float speed = 2f;

    private Vector3 targetPos;

    private void Start()
    {
        targetPos = posB.position;

        // Start at A
        transform.position = posA.position;

        // Wait for Timeline
        enabled = false;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );

        // Stop when we reach B
        if (Vector3.Distance(transform.position, targetPos) < 0.001f)
        {
            transform.position = targetPos;
            enabled = false;

            Debug.Log("Red square reached posB");
        }
    }

    // Timeline calls this when the red square should start
    public void EnableMoving()
    {
        enabled = true;
        Debug.Log("Red square started moving");
    }
}