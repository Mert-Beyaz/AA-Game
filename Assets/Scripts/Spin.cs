using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        transform.Rotate(0, 0, Speed * Time.deltaTime);
    }
}
