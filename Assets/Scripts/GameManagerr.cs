using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerr : MonoBehaviour
{
    GameObject SpinCycle;
    GameObject MainCycle;
    public Animator Animator;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI One;
    public TextMeshProUGUI Two;
    public TextMeshProUGUI Three;
    public int TotalThrowCycle;
    public bool SceneControl = true;
    void Start()
    {
        PlayerPrefs.SetInt("Level", int.Parse(SceneManager.GetActiveScene().name));
        SpinCycle = GameObject.FindGameObjectWithTag("SpinCycleTag");
        MainCycle = GameObject.FindGameObjectWithTag("MainCycle");
        LevelText.text = SceneManager.GetActiveScene().name;

        if (TotalThrowCycle < 2)
        {
            One.text = TotalThrowCycle + "";
        }
        else if (TotalThrowCycle < 3)
        {
            One.text = TotalThrowCycle + "";
            Two.text = (TotalThrowCycle - 1) + "";
        } 
        else
        {
            One.text = TotalThrowCycle + "";
            Two.text = (TotalThrowCycle - 1) + "";
            Three.text = (TotalThrowCycle - 2) + "";
        }
    }

    public void ThrowCycleCounter()
    {
        TotalThrowCycle--;
        if (TotalThrowCycle < 2)
        {
            One.text = TotalThrowCycle + "";
            Two.text = "";
            Three.text = "";
        }
        else if (TotalThrowCycle < 3)
        {
            One.text = TotalThrowCycle + "";
            Two.text = (TotalThrowCycle - 1) + "";
            Three.text = "";
        }
        else
        {
            One.text = TotalThrowCycle + "";
            Two.text = (TotalThrowCycle - 1) + "";
            Three.text = (TotalThrowCycle - 2) + "";
        }
        if (TotalThrowCycle == 0)
        {
            StartCoroutine(NewLevel());
        }
    }

    IEnumerator NewLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SpinCycle.GetComponent<Spin>().enabled = false;
        MainCycle.GetComponent<MainCycleController>().enabled = false;
        yield return new WaitForSeconds(1);

        if(SceneControl)
        {
            Animator.SetTrigger("NewLevel");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);

        }
    }

    public void GameOver()
    {
        SpinCycle.GetComponent<Spin>().enabled = false;
        MainCycle.GetComponent<MainCycleController>().enabled = false;
        Animator.SetTrigger("GameOver");
        SceneControl = false;
        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(0);
        }
        

    }
}
