using UnityEngine;

public class StitchGroup : MonoBehaviour
{
    public GameObject[] stitches;

    //Order stitches properly

    //enable stitches based on order

    //enable disable based on stitch order

    //remove all stitches once all complete



    void Start()
    {
        OrderStitches();
    }


    void Update()
    {
        
    }

    public void OrderStitches()
    {
        for (int i = 0; i < stitches.Length; i++)
        {
            stitches[i].transform.SetSiblingIndex(i);

            print($"Stitch {stitches[i].name} set to sibling index {i}");
        }

    }

}
