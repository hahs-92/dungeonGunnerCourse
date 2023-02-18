using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOtherComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestGameManager.Instance.TestMethod();
    }
}
