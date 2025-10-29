using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SnapShotData
{
    public float frameTime;

    public Dictionary<string, SnapshotInfo> snapshots;

    [SerializeReference]
    private List<SnapshotInfo> m_snapshotList;

    public SnapShotData(float time)
    {
        frameTime = time;
        snapshots = new Dictionary<string, SnapshotInfo>();
        m_snapshotList = new List<SnapshotInfo>();
    }

    public void AddObjectSnapshot(string id, SnapshotInfo data)
    {
        snapshots.Add(id, data);

        m_snapshotList.Add(data);
    }

    public bool GetObjectSnapshot(string id, out SnapshotInfo info)
    {
        if(snapshots == null)
        {
            BuildDictionary();
        }
        return snapshots.TryGetValue(id, out info);
    }

    private void BuildDictionary()
    {
        snapshots = new Dictionary<string, SnapshotInfo>();
        foreach(SnapshotInfo snap in m_snapshotList)
        {
            snapshots.Add(snap.id, snap);
        }
    }
}
