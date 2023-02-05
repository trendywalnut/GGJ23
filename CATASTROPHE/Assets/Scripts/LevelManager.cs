using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    //[Header("Internet Tabs")]

    [Header("Levels")]
    [SerializeField]
    private GameObject[] levels;

    

    void Start()
    {
        instance = this;
        //set level1 active
        //levels[0].SetActive(true);
    }

    public void ChangeLevel(int levelNum)
    {
        foreach(GameObject i in levels)
        {
            i.SetActive(false);
        }
        levels[levelNum].SetActive(true);
    }
}
