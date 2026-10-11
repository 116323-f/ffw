using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    private Vector3 targetPos;

    [SerializeField] private float speed = 2f;

    [SerializeField] private HoldSlider holdSliderScript;

    private void Start()
    {
        targetPos = posB.position;
        transform.position = posA.position;
        holdSliderScript = GetComponent<HoldSlider>();

        enabled = false;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Stop at B
        if (Vector3.Distance(transform.position, targetPos) < 0.001f)
        {
            transform.position = targetPos;
            enabled = false;

            print($"Red square at posB");
        }
    }

    public void EnableMoving()
    {
        enabled = true;
        print($"Red square started moving");
    }
}