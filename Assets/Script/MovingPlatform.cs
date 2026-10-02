using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed;
    Vector2 targetPos;

    public void Start()
    {
        targetPos = posB.position;
    }

    private void Update()
    {
    transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
