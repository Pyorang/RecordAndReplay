using UnityEngine;

public interface IReplayObject
{
    string GetId();
    SnapshotInfo SaveSnapshot();

    void LoadSnapShot(SnapshotInfo snapshotInfo);
}
