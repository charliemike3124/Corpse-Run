using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public static Resources Instance;

    private void Awake()
    {
        Instance = Instance == null ? this : null;
    }

    public MaterialResource materials;
}
