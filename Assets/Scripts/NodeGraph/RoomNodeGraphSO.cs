using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// heredamos de scriptableObjetct, para poder crear assets menu attribute
// a travez de unity menu

[CreateAssetMenu(fileName ="RoomNodeGraph" , menuName ="Scriptable Objects/Dungeon/Room Node Graph")]
public class RoomNodeGraphSO : ScriptableObject
{
    [HideInInspector] public RoomNodeTypeListSO roomNodeTypeList;
    [HideInInspector] public List<RoomNodeSO> roomNodelist = new List<RoomNodeSO>();
    [HideInInspector] public Dictionary<string, RoomNodeSO> roomNodeDictionary = new Dictionary<string, RoomNodeSO>();
}
