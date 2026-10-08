using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed;
    Vector2 targetPos;
    private MovingPlatform movingPlatformScript;
    private HoldSlider holdSliderScript;

    public void Start()
    {
        Debug.Log("MovingPlatform object: " + gameObject.name);
        Debug.Log("posA: " + posA);
        Debug.Log("posB: " + posB);

        movingPlatformScript = GetComponent<MovingPlatform>();
        holdSliderScript = GetComponent<HoldSlider>();
        targetPos = posB.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        print($"Time active:{speed*Time.deltaTime}");

        //once position is reached, disable script to stop moving
        if (Vector2.Distance(transform.position, targetPos) < 0.001f)
        {
            print($"Overall time active:{speed * Time.deltaTime}");
            holdSliderScript.enabled = false;
        }
    }

    public void EnableMoving()
    {
        enabled = true;
    }

    public void DisableMoving()
    {
        enabled = false;
    }
}

