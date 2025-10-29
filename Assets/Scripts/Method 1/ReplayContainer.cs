using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Replay Container")]
public class ReplayContainer : ScriptableObject
{
    [SerializeField]
    private List<SnapShotData> m_snapshots;

    public void Init()
    {
        m_snapshots = new List<SnapShotData>();
    }

    public void AddSnapShot(SnapShotData snapshot)
    {
        m_snapshots.Add(snapshot);
    }

    public bool GetSnapShot(int index, out SnapShotData data)
    {
        if(index >= m_snapshots.Count)
        {
            data = new SnapShotData(-1);
            return false;
        }

        if(index < 0)
        {
            data = new SnapShotData(-1);
            return false;
        }

        data = m_snapshots[index];

        return true;
    }

    public void ResetData()
    {
        m_snapshots.Clear();
    }
}