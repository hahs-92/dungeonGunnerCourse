using UnityEngine;
[System.Serializable]

public class Doorway
{
    public Vector2 position;
    public Orientation orientation;
    public GameObject doorPrefab;

    #region Header
    [Header("The Upper Left Position To Start Copying From")]
    #endregion
    public Vector2Int doorwayStartCopyPosition;

    #region Header
    [Header("The Widht of titles i the doorway to copy over")]
    #endregion
    public int doorwayCopyTitleWidth;

    #region Header
    [Header("The height of titles i the doorway to copy over")]
    #endregion
    public int doorwayCopyTitleHeight;

    [HideInInspector]
    public bool isConnected = false;
    [HideInInspector]
    public bool isUnavailable = false;
}
