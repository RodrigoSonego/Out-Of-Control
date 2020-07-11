using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSceneLoaded : MonoBehaviour
{
    public static bool wasLoaded;

    public bool WasLoaded
    {
        get { return wasLoaded; }

        set { wasLoaded = value; }
    }
}
