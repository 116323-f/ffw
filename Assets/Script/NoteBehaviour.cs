using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class NoteBehaviour : PlayableBehaviour
{
    private MovingPlatform movingPlatformScript;
    private HighScore highScoreScript;
    private bool holdTriggered;

    private ZPress zPressScript;
    private ZRelease zReleaseScript;
    private bool zPressTriggered;
    private bool zReleaseTriggered;

    private XPress xPressScript;
    private XRelease xReleaseScript;
    private bool xPressTriggered;
    private bool xReleaseTriggered;

    private AccuracyManager accuracyManagerScript;



    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        movingPlatformScript = Script.GetInChildren<MovingPlatform>();



    }
}
