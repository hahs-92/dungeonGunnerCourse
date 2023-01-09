using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// necesitamos heredar de EditorWindow (UnityEditor)
public class RoomNodeGraphEditor : EditorWindow
{
    private GUIStyle roomNodeStyle;

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
    }

    ///<summary>
    /// Draw Editor Gui
    /// </summary>
    private void OnGUI()
    {
        //Debug.Log("OnGUI has been called");
        // Dibujamos el area 
        GUILayout.BeginArea(new Rect(new Vector2(100f, 100f), new Vector2(nodeWidth,nodeHeight)), roomNodeStyle);
        EditorGUILayout.LabelField("Node 1");
        GUILayout.EndArea();
        
        GUILayout.BeginArea(new Rect(new Vector2(300f, 300f), new Vector2(nodeWidth,nodeHeight)), roomNodeStyle);
        EditorGUILayout.LabelField("Node 2");
        GUILayout.EndArea();
    }
}
