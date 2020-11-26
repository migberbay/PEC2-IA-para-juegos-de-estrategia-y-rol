using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyBoid : MonoBehaviour
{
    public NVBoids manager;

    private void OnDestroy()
    {
        manager.AddNewBird();
    }
}
