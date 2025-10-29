using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;   

public class ReplayManager : MonoBehaviour
{
    private float m_time = 0;
    public int snapshotIndex = 0;
    private float m_nextSnapshotTime;
    private bool m_hasNextSnapshot = true;

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

    public void FixedUpdate()
    {
        m_time += Time.fixedDeltaTime;

        if(currentState == State.Record)
        {
            m_snapshotDeltaTotal += Time.fixedDeltaTime;
            if(m_snapshotDeltaTotal > snapshotDelta)
            {
                TakeSnapshot();

                m_snapshotDeltaTotal -= snapshotDelta;
            }
        }
        else if(currentState == State.Playback)
        {
            if(m_time >= m_nextSnapshotTime && m_hasNextSnapshot)
            {
                LoadNextSnapshot();
                snapshotIndex++;
            }
        }
    }

    private void LoadNextSnapshot()
    {
        if(replayContainer.GetSnapShot(snapshotIndex, out SnapShotData currentSnapshot))
        {
            foreach(IReplayObject obj in replayObjects)
            {
                if(currentSnapshot.GetObjectSnapshot(obj.GetId(), out SnapshotInfo info))
                {
                    obj.LoadSnapShot(info);
                }
            }
        }

        m_hasNextSnapshot = replayContainer.GetSnapShot(snapshotIndex, out SnapShotData nextSnapshot);
        if(m_hasNextSnapshot)
        {
            m_nextSnapshotTime = nextSnapshot.frameTime;
        }
    }

    private void TakeSnapshot()
    {
        m_time += Time.fixedDeltaTime;

        SnapShotData snapShotData = new SnapShotData(m_time);

        foreach(IReplayObject replayObject in replayObjects)
        {
            snapShotData.AddObjectSnapshot(((UnityEngine.Object)replayObject).name, replayObject.SaveSnapshot());
        }

        replayContainer.AddSnapShot(snapShotData);

        snapshotIndex++;
    }
}