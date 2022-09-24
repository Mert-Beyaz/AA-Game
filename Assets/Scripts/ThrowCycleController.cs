using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCycleController : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    bool MoveControl;
    GameObject GameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager = GameObject.FindGameObjectWithTag("GameManager"); 
    }
    void FixedUpdate()
    {
        if (!MoveControl)
        {
            rb.MovePosition(rb.position + Vector2.up * Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpinCycleTag")
        {
            transform.SetParent(other.transform);
            MoveControl = true;
        }

        if (other.tag == "ThrowCycle")
        {
            GameManager.GetComponent<GameManagerr>().GameOver();
        }
    }
}
 