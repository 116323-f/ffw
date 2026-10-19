using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class RhythmNoteClip : PlayableAsset
{
    public NoteBehaviour behaviour = new NoteBehaviour();

    public ClipCaps clipCaps
    {
        get {  return ClipCaps.None; }
    }
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        return ScriptPlayable<NoteBehaviour>.Create(graph);
    }
}

