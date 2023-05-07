using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// para testear el spanw de los enemies
// se le agrega al object Gamemanager
public class SpawnTest : MonoBehaviour
{
    // ya no se tiene que popular en el inspector
    //public RoomTemplateSO roomTemplateSO;
    private List<SpawnableObjectsByLevel<EnemyDetailsSO>> testLevelSpawnList;
    private RandomSpawnableObject<EnemyDetailsSO> randomEnemyHelperClass;
    // se reemplaza por la linea de abajo
    private List<GameObject> instantiatedEnemyList = new List<GameObject>();

    private void OnEnable()
    {
        // subscribe to change of room
        StaticEventHandler.OnRoomChanged += StaticEventHandler_OnRoomChanged;
    }

    private void OnDisable()
    {
        // unsubscribe to change of room
        StaticEventHandler.OnRoomChanged -= StaticEventHandler_OnRoomChanged;
    }


    private void Start()
    {
        // Get test level spawn list from dungeon room template
        //testLevelSpawnList = roomTemplateSO.enemiesByLevelList;

        // Create RandomSpawnableObject helper class
        //randomEnemyHelperClass = new RandomSpawnableObject<EnemyDetailsSO>(testLevelSpawnList);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {

            EnemyDetailsSO enemyDetails = randomEnemyHelperClass.GetItem();

            if (enemyDetails != null)
                instantiatedEnemyList
                    .Add(Instantiate(
                        enemyDetails.enemyPrefab,
                        HelperUtilities.GetSpawnPositionNearestToPlayer(HelperUtilities.GetMouseWorldPosition()), 
                        Quaternion.identity));
        }

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    if (instantiatedEnemy != null)
        //    {
        //        Destroy(instantiatedEnemy);
        //    }

        //    EnemyDetailsSO enemyDetails = randomEnemyHelperClass.GetItem();

        //    if (enemyDetails != null)
        //        instantiatedEnemy = Instantiate(
        //            enemyDetails.enemyPrefab, 
        //            HelperUtilities.GetSpawnPositionNearestToPlayer(HelperUtilities.GetMouseWorldPosition()), 
        //            Quaternion.identity);
        //}
    }

    private void StaticEventHandler_OnRoomChanged(RoomChangedEventArgs roomChangedEventArgs)
    {
        // Destroy any spawned enemies
        if (instantiatedEnemyList != null && instantiatedEnemyList.Count > 0)
        {
            foreach (GameObject enemy in instantiatedEnemyList)
            {
                Destroy(enemy);
            }
        }

        RoomTemplateSO roomTemplate = DungeonBuilder.Instance.GetRoomTemplate(roomChangedEventArgs.room.templateID);

        if (roomTemplate != null)
        {
            testLevelSpawnList = roomTemplate.enemiesByLevelList;

            // Create RandomSpawnableObject helper class
            randomEnemyHelperClass = new RandomSpawnableObject<EnemyDetailsSO>(testLevelSpawnList);
        }
    }
}
