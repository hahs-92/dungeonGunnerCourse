using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// esta clase sera un prefab, el cual tendra una lista de nodes
// los cuales podran ser accedidos e editados por otras clases
// de esta manera podemos compartir informacion de manera facil
public class GameResources : MonoBehaviour
{
   private static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if(instance == null)
            {
                // este archivo puede ser encontrado con este Metodo
                // xq esta dentro un folder llamado Resources
                instance = Resources.Load<GameResources>("GameResources");
            }
            return instance;
        }
    }

    #region Header DUNGEON
    [Space(10)]
    [Header("DUNGEON")]
    #endregion

    #region Tooltip
    [Tooltip("Populate with the dungeon RoomNodeTypeListSO")]
    #endregion

    public RoomNodeTypeListSO roomNodeTypeList;
}
