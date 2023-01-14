using UnityEngine;
using UnityEditor.Callbacks; // nos permite detectar cosas en el ED y capturlas
using UnityEditor;
using System;

// necesitamos heredar de EditorWindow (UnityEditor)
public class RoomNodeGraphEditor : EditorWindow
{
    private GUIStyle roomNodeStyle;
    private static RoomNodeGraphSO currentRoomNodeGraph;
    private RoomNodeTypeListSO roomNodeTypeList;

    //Node layout values
    private const float nodeWidth = 160f;
    private const float nodeHeight = 75f;
    private const int nodePadding = 25;
    private const int nodeBorder = 12;

    [MenuItem("Room Nod eGraph Editor", menuItem = "Window/Dungeon Editor/Room Node Graph Editor")]
    private static void OpenWindow()
    {
        GetWindow<RoomNodeGraphEditor>("Room Node Graph Editor");
    }

    private void OnEnable()
    {
        // Define node layout style
        roomNodeStyle = new GUIStyle();
        roomNodeStyle.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
        roomNodeStyle.normal.textColor = Color.white;
        roomNodeStyle.padding = new RectOffset(nodePadding, nodePadding, nodePadding, nodePadding);
        roomNodeStyle.border = new RectOffset(nodeBorder, nodeBorder, nodeBorder, nodeBorder);

        // Load Room Node Types
        roomNodeTypeList = GameResources.Instance.roomNodeTypeList;
    }

    ///<summary>
    /// Open the room node graph editor window if a room node scriptable object asset
    /// is double clicked in the inspector
    /// </summary>
    [OnOpenAsset(0)] // need the namespace UnityEditor.Callbacks
    public static bool OnDoubleCliackAsset(int instanceID, int line)
    {
        RoomNodeGraphSO roomNodeGraph = EditorUtility.InstanceIDToObject(instanceID) as RoomNodeGraphSO;

        if(roomNodeGraph != null)
        {
            OpenWindow();
            currentRoomNodeGraph = roomNodeGraph;

            return true;
        }

        return false;
    }

    ///<summary>
    /// Draw Editor Gui
    /// </summary>
    private void OnGUI()
    {
        // If a scriptable object of type RoomNodeGraphSO has been selected then process
        if(currentRoomNodeGraph != null)
        {
            // Process Events
            ProcessEvents(Event.current);

            // Draw Room Nodes
            DrawRoomNodes();
        }

        if(GUI.changed)
        {
            Repaint();
        }


        //Debug.Log("OnGUI has been called");
        // Dibujamos el area 
        //GUILayout.BeginArea(new Rect(new Vector2(100f, 100f), new Vector2(nodeWidth,nodeHeight)), roomNodeStyle);
        //EditorGUILayout.LabelField("Node 1");
        //GUILayout.EndArea();
        
        //GUILayout.BeginArea(new Rect(new Vector2(300f, 300f), new Vector2(nodeWidth,nodeHeight)), roomNodeStyle);
        //EditorGUILayout.LabelField("Node 2");
        //GUILayout.EndArea();
    }

    private void ProcessEvents(Event currentEvent)
    {
        ProcessRoomNodeGraphEvents(currentEvent);
    }

    private void ProcessRoomNodeGraphEvents(Event currentEvent)
    {
        switch(currentEvent.type)
        {
            // Process Mouse Down Events
            case EventType.MouseDown:
                ProcessMouseDownEvent(currentEvent); 
                break;

                default: break;
        }
    }

    /// <summary>
    /// process mouse down events on the rrom node graph (not over a node)
    /// </summary>
    private void ProcessMouseDownEvent(Event currentEvent)
    {
        // Process rigth click mouse down on the graph event (show context menu)
        if(currentEvent.button == 1)
        {
            ShowContextMenu(currentEvent.mousePosition);
        }
    }

    /// <summary>
    /// Show the context menu
    /// </summary>
    private void ShowContextMenu(Vector2 mousePosition)
    {
        GenericMenu menu = new GenericMenu();
        menu.AddItem(new GUIContent("Create Room Node"), false, CreateRoomNode, mousePosition);
        menu.ShowAsContext();
    }

    /// <summary>
    ///  Create a room node at the mouse position
    /// </summary>
    private void CreateRoomNode(object mousePositionObject)
    {
        CreateRoomNode(mousePositionObject, roomNodeTypeList.list.Find(x => x.isNone));
    }

    /// <summary>
    /// Create a room node at the mouse position - overloaded to also pass in RoomNodeType
    /// </summary>
    private void CreateRoomNode(object mousePositionObject, RoomNodeTypeSO roomNodeType)
    {
        Vector2 mousePosition = (Vector2)mousePositionObject;

        // create room node scriptable object asset
        RoomNodeSO roomNode = ScriptableObject.CreateInstance<RoomNodeSO>();

        // add room node to current room node graph room node list
        currentRoomNodeGraph.roomNodelist.Add(roomNode);

        // set room node values
        roomNode.Initialise(new Rect(mousePosition, new Vector2(nodeWidth, nodeHeight)), currentRoomNodeGraph, roomNodeType);

        // add room node to room node graph scriptable object  asset database
        AssetDatabase.AddObjectToAsset(roomNode, currentRoomNodeGraph);

        AssetDatabase.SaveAssets();
    }

    /// <summary>
    /// Draw room nodes in the graph window
    /// </summary>
    private void DrawRoomNodes()
    {
        // loop throught all rooms nodes and draw them
        foreach(RoomNodeSO roomNode in currentRoomNodeGraph.roomNodelist)
        {
            roomNode.Draw(roomNodeStyle);
        }

        GUI.changed = true;
    }
}
