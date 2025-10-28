using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ReplayManager : MonoBehaviour
{
    public static ReplayManager instance;

    public enum State
    {
        Idle,
        Record,
        Playback
    }

    public ReplayContainer replayContainer;

    public List<IReplayObject> replayObjects;

    public State currentState;

    [Tooltip("What should the frame delta be between snapshots")]
    public float snapshotDelta;

    private float m_snapshotDeltaTotal;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartRecording()
    {
        currentState = State.Record;
    }

    public void StartPlayBack()
    {
        currentState = State.Playback;
    }

    public void Stop()
    {
        currentState = State.Idle;
    }

    public void Register(IReplayObject replayObject)
    {
        if (replayObjects == null)
        {
            replayObjects = new List<IReplayObject>();
        }

        replayObjects.Add(replayObject);
    }
}