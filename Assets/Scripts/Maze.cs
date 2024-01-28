using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public GameObject prefab; // The prefab to instantiate
    
    public bool[,] booleanArray = {
        { false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
        { false, true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false },
        { false, true, false, true, false, false, false, true, false, true, false, false, false, false, false, false, false, false, false },
        { false, true, true, true, false, true, true, true, false, true, true, true, true, true, true, true, true, true, false },
        { false, true, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false, true, false },
        { false, true, false, true, true, true, false, true, true, true, true, true, true, true, false, true, false, true, false },
        { false, true, false, false, false, false, false, true, false, false, false, false, false, true, false, false, false, true, false },
        { false, true, true, true, false, true, true, true, true, true, true, true, false, true, false, true, true, true, false },
        { false, false, false, true, false, true, false, false, false, false, false, true, false, true, false, true, false, true, false },
        { false, true, true, true, false, true, false, true, true, true, false, true, false, true, false, true, false, true, false },
        { false, false, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false },
        { false, true, true, true, false, true, true, true, false, true, false, true, false, true, true, true, false, true, false },
        { false, true, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false },
        { false, true, true, true, true, true, true, true, false, true, false, true, true, true, true, true, true, true, false },
        { false, false, false, false, false, true, false, true, false, true, false, true, false, false, false, false, false, true, false },
        { false, true, true, true, false, true, false, true, false, true, true, true, false, true, true, true, false, true, false },
        { false, true, false, false, false, true, false, true, false, false, false, false, false, true, false, true, false, true, false },
        { false, true, true, true, true, true, false, true, true, true, true, true, true, true, false, true, false, true, true },
        { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
    };

}
