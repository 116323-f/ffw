using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class StitchOrderManager : MonoBehaviour
{
    private List<StitchComponent> sortedStitches = new List<StitchComponent>();
    private int currentStepIndex = 0;

    void Start()
    {
        InitializeAndSequenceStitches();
    }

    // 1. Gather, sort, and initialize all stitches in the scene
    void InitializeAndSequenceStitches()
    {
        // Find all StitchComponents in the scene
        StitchComponent[] allStitches = FindObjectsByType<StitchComponent>(FindObjectsSortMode.None);

        // Sort them strictly by their assigned executionOrder index
        sortedStitches = allStitches.OrderBy(s => s.executionOrder).ToList();

        // Disable everything at the start
        foreach (var stitch in sortedStitches)
        {
            stitch.SetStitchActive(false);
        }

        // Activate the very first stitch in the sequence
        ActivateCurrentStep();
    }

    // 2. Enable the stitch at the current index
    void ActivateCurrentStep()
    {
        if (currentStepIndex >= 0 && currentStepIndex < sortedStitches.Count)
        {
            sortedStitches[currentStepIndex].SetStitchActive(true);
        }
        else
        {
            Debug.Log("All stitches in the sequence have been completed!");
        }
    }

    // 3. Call this function from your gameplay scripts when a stitch finishes
    public void CompleteCurrentStitch()
    {
        // Disable the completed stitch
        if (currentStepIndex < sortedStitches.Count)
        {
            sortedStitches[currentStepIndex].SetStitchActive(false);
        }

        // Move to the next index and activate it
        currentStepIndex++;
        ActivateCurrentStep();
    }
}
