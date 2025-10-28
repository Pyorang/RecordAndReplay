using System.Collections.Generic;
using UnityEngine;

public struct SnapShotData
{
    public float frameTime;

    public Dictionary<string, object> snapshots;

    public SnapShotData(float time)
    {
        frameTime = time;
        snapshots = new Dictionary<string, object>();
    }

    public void AddObjectSnapshot(string id, object data)
    {
        snapshots.Add(id, data);
    }
}
