using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPersist : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
