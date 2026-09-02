using UnityEngine;

public class Accuracy : MonoBehaviour
{
    public void CheckHit(float playerInputTime, float noteTargetTime)
    {
        float timeDifference = Mathf.Abs(playerInputTime - noteTargetTime);

        if (timeDifference <= 0.05f)
        {
            Debug.Log("Perfect!");
        }
        else if (timeDifference <= 0.15f)
        {
            Debug.Log("Good!");
        }
        else
        {
            Debug.Log("Bad / Too Far!");
        }
    }
}
