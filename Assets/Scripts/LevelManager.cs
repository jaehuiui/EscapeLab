using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static int level = 0;
    // Start is called before the first frame update
    public static void setExpert()
    {
        level = 1;
    }

    public static void setNormal()
    {
        level = 0;
    }

    public static int getLevel()
    {
        return level;
    }
}
