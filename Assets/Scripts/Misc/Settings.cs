using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings 
{
    #region ROOM SETTINGS
    //max number of child corridors leading from a room, maximum should be 3 although this is not  recommended
    // since it can cause the dungeon to fail since the rroms are more likely to not fit together
    public const int maxChildCorridors = 3;

    #endregion

}
