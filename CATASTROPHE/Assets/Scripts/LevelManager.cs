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
    private GameObject previousLevel;
    private GameObject newLevel;

    [SerializeField] private float tweenTime;

    

    void Start()
    {
        instance = this;
        //set level1 active
        //levels[0].SetActive(true);
    }

    public void ChangeLevel(int levelNum)
    {
        previousLevel = levelNum > 0 ? levels[levelNum - 1] : levels[0];
        newLevel = levels[levelNum];

        foreach (GameObject i in levels)
        {
            if (!(i == previousLevel))
                i.SetActive(false);
        }
        //levels[levelNum].SetActive(true);

        // Visual Transition
        StartCoroutine(BackgroundTransition());
    }

    IEnumerator BackgroundTransition()
    {
        //previousLevel.GetComponentInChildren
        yield return null;
    }
}
