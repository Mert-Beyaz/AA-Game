using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCycleController : MonoBehaviour
{
    public GameObject ThrowCycle;
    public GameManagerr GM;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InstantiateThrowCycle();
        }
    }

    void InstantiateThrowCycle()
    {
        if (GM.TotalThrowCycle != 0)
        {
            Instantiate(ThrowCycle, transform.position, transform.rotation);
            GM.ThrowCycleCounter();
        }
        
    }
}
