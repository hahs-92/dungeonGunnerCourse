using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Tooltip
    [Tooltip("The player WeaponShootPosition gameobject in the hieracrchy")]
    #endregion Tooltip
    [SerializeField] private Transform weaponShootPosition;

    private Player player;

    private void Awake()
    {
        // Load components
        player = GetComponent<Player>();
    }

    private void Update()
    {
        // Process the player movement input
        MovementInput();

        // Process the player weapon input
        WeaponInput();

    }

    /// <summary>
    /// Player movement input
    /// </summary>
    private void MovementInput()
    {
        player.idleEvent.CallIdleEvent();
    }

    /// <summary>
    /// Weapon Input
    /// </summary>
    private void WeaponInput()
    {
        Vector3 weaponDirection;
        float weaponAngleDegrees, playerAngleDegrees;
        AimDirection playerAimDirection;

        // Aim weapon input
        AimWeaponInput(out weaponDirection, out weaponAngleDegrees, out playerAngleDegrees, out playerAimDirection);
    }

    private void AimWeaponInput(out Vector3 weaponDirection, out float weaponAngleDegrees, out float playerAngleDegrees, out AimDirection playerAimDirection)
    {
        // Get mouse world position
        Vector3 mouseWorldPosition = HelperUtilities.GetMouseWorldPosition();

        // Calculate direction vector of mouse cursor from weapon shoot position
        weaponDirection = (mouseWorldPosition - weaponShootPosition.position);

        // Calculate direction vector of mouse cursor from player transform position
        Vector3 playerDirection = (mouseWorldPosition - transform.position);

        // Get weapon to cursor angle
        weaponAngleDegrees = HelperUtilities.GetAngleFromVector(weaponDirection);

        // Get player to cursor angle
        playerAngleDegrees = HelperUtilities.GetAngleFromVector(playerDirection);

        // Set player aim direction
        playerAimDirection = HelperUtilities.GetAimDirection(playerAngleDegrees);

        // Trigger weapon aim event
        player.aimWeaponEvent.CallAimWeaponEvent(playerAimDirection, playerAngleDegrees, weaponAngleDegrees, weaponDirection);
    }
}
