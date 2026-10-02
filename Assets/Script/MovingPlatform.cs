using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed;
    Vector2 targetPos;
    private MovingPlatform script;
    private HoldSlider holdSliderScript;

    public void Start()
    {
        script = GetComponent<MovingPlatform>();
        holdSliderScript = GetComponent<HoldSlider>();
        targetPos = posB.position;
    }

    private void Update()
    {
    transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //once position is reached, disable script to stop moving
        if (Vector2.Distance(transform.position, targetPos) < 0.001f)
        { 
            holdSliderScript.enabled = false;
        }
    }

}
