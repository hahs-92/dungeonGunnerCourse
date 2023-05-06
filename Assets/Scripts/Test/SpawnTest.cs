using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// para testear el spanw de los enemies
// se le agrega al object Gamemanager
public class SpawnTest : MonoBehaviour
{
    public RoomTemplateSO roomTemplateSO;
    private List<SpawnableObjectsByLevel<EnemyDetailsSO>> testLevelSpawnList;
    private RandomSpawnableObject<EnemyDetailsSO> randomEnemyHelperClass;
    private GameObject instantiatedEnemy;

    private void Start()
    {
        // Get test level spawn list from dungeon room template
        testLevelSpawnList = roomTemplateSO.enemiesByLevelList;

        // Create RandomSpawnableObject helper class
        randomEnemyHelperClass = new RandomSpawnableObject<EnemyDetailsSO>(testLevelSpawnList);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (instantiatedEnemy != null)
            {
                Destroy(instantiatedEnemy);
            }

            EnemyDetailsSO enemyDetails = randomEnemyHelperClass.GetItem();

            if (enemyDetails != null)
                instantiatedEnemy = Instantiate(
                    enemyDetails.enemyPrefab, 
                    HelperUtilities.GetSpawnPositionNearestToPlayer(HelperUtilities.GetMouseWorldPosition()), 
                    Quaternion.identity);
        }
    }
}
