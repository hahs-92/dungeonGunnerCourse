using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMap : SingletonMonoBehaviour<DungeonMap>
{
    #region Header GameObject References
    [Space(10)]
    [Header("GameObject References")]
    #endregion
    #region Tooltip
    [Tooltip("Populate with the MinimapUI gameobject")]
    #endregion
    [SerializeField] private GameObject minimapUI;

    private Camera dungeonMapCamera;
    private Camera cameraMain;

    private void Start()
    {
        // Cache main camera
        cameraMain = Camera.main;

        // Get player transform
        Transform playerTransform = GameManager.Instance.GetPlayer().transform;

        // Populate player as cinemachine camera target
        CinemachineVirtualCamera cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = playerTransform;

        // get dungeonmap camera
        dungeonMapCamera = GetComponentInChildren<Camera>();
        dungeonMapCamera.gameObject.SetActive(false);
    }

    /// <summary>
    /// Display dungeon overview map UI
    /// </summary>
    public void DisplayDungeonOverViewMap()
    {
        // Set game state
        GameManager.Instance.previousGameState = GameManager.Instance.gameState;
        GameManager.Instance.gameState = GameState.dungeonOverviewMap;

        // Disable player
        GameManager.Instance.GetPlayer().playerControl.DisablePlayer();

        // Disable main camera and enable dungeon overview camera
        cameraMain.gameObject.SetActive(false);
        dungeonMapCamera.gameObject.SetActive(true);

        // Ensure all rooms are active so they can be displayed
        ActivateRoomsForDisplay();

        // Disable Small Minimap UI
        minimapUI.SetActive(false);
    }

    /// <summary>
    /// Clear the dungeon overview map UI
    /// </summary>
    public void ClearDungeonOverViewMap()
    {
        // Set game state
        GameManager.Instance.gameState = GameManager.Instance.previousGameState;
        GameManager.Instance.previousGameState = GameState.dungeonOverviewMap;

        // Enable player
        GameManager.Instance.GetPlayer().playerControl.EnablePlayer();

        // Enable main camera and disable dungeon overview camera
        cameraMain.gameObject.SetActive(true);
        dungeonMapCamera.gameObject.SetActive(false);

        // Enable Small Minimap UI
        minimapUI.SetActive(true);
    }

    /// <summary>
    /// Ensure all rooms are active so they can be displayed
    /// </summary>
    private void ActivateRoomsForDisplay()
    {
        // Iterate through dungeon rooms
        foreach (KeyValuePair<string, Room> keyValuePair in DungeonBuilder.Instance.dungeonBuilderRoomDictionary)
        {
            Room room = keyValuePair.Value;

            room.instantiatedRoom.gameObject.SetActive(true);
        }
    }
}
