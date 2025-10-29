using UnityEngine;

[System.Serializable]
public class SnapshotInfo
{
    public string id;
}

[System.Serializable]
public class PlayerSnapShotInfo : SnapshotInfo
{
    public Vector3 position;
    public Vector2 velocity;
    public Quaternion rotation;
    public bool onGround;
}
