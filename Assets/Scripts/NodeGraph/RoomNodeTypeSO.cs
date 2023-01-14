using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomNodeType_", menuName = "Scriptable Objects/Dungeon/Room Node Type")]
public class RoomNodeTypeSO : ScriptableObject
{
    public string roomNodeTypeName;

    #region Header
    [Header("Only flag the RoomNodeTypes that should be visible in the editor")]
    #endregion Header
    public bool displayInNodeGraphEditor = true;

    #region Header
    [Header("One type Should Be A Corridor")]
    #endregion Header
    public bool isCorridor = true;

    #region Header
    [Header("One Type Should Be A CorridorNS")]
    #endregion Header
    public bool isCorridorNS = true;

    #region Header
    [Header("One Type Should Be A CorridorEW")]
    #endregion Header
    public bool isCorridorEW = true;

    #region Header
    [Header("One Type Should Be A Entrance")]
    #endregion Header
    public bool isEntrance;

    #region Header
    [Header("One Type Should Be A Boss Room")]
    #endregion Header
    public bool isBossRoom;

    #region Header
    [Header("One Type Should Be A Node(Unnasigned)")]
    #endregion Header
    public bool isNone;

    #region Validation
#if UNITY_EDITOR
    // se llama cuando se carga o modifica el script en el inspector
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(roomNodeTypeName), "roomNodeTypeName");
    }
#endif
    #endregion
}
