using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomNodeTypeListSO", menuName = "Scriptable Objects/Dungeon/Room Node Type List")]
public class RoomNodeTypeListSO : ScriptableObject
{
    #region Header ROOM NODE TYPE LIST
    [Space(10)]
    [Header("ROOM NODE TYPE LIST")]
    #endregion


    // es un pop up, que se muestra cuando se hace hover
    #region
    [Tooltip("This list should be populated with all the RoomNodeTypeListSO for the game - it is used instead of an emun")]
    #endregion

    public List<RoomNodeTypeSO> list;


    #region Validation
#if UNITY_EDITOR
    // se llama cuando se carga o modifica el script en el inspector
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(list), list);
    }
#endif
    #endregion
}
