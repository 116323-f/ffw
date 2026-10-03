using System.Collections;
using UnityEngine;

public class StitchGroup : MonoBehaviour
{
    public GameObject[] stitches;
    public float delayBetweenTriggers = 2.0f;
    [SerializeField] private MovingPlatform script;

    //Order stitches properly

    //enable stitches based on order (enable movingplatform and holdslider script)

    //enable disable based on stitch order

    //remove all stitches once all complete

    void Start()
    {
        // Start sequential chain
        script = gameObject.AddComponent<MovingPlatform>();
        //StartCoroutine(TriggerObjectsInSequence());
    }



    //IEnumerator TriggerObjectsInSequence()
    //{
    //    foreach (GameObject obj in stitches)
    //    {
    //        if (obj != null)
    //        {
    //            // Action: e.g., Activating the object
    //            //obj.SetActive(true);

    //            // If you want to trigger a custom script component instead, you can do:
    //            obj.gameObject.GetComponent<MovingPlatform>();

    //            // Wait for the specified time before moving to the next object
    //            yield return new WaitForSeconds(delayBetweenTriggers);
    //        }
    //    }
    //}


    //void Update()
    //{

        //public void OrderStitches()
        //{
        //    for (int i = 0; i < stitches.Length; i++)
        //    { 
        //        stitches[i].transform.SetSiblingIndex(i);

        //    }

        //}

    //}
}
