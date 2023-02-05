using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //[Header("Internet Tabs")]

    [SerializeField]
    private GameObject tab1, tab2, tab3;

    //[Header("Desktops")]
    [SerializeField]
    private GameObject desktop1, desktop2, desktop3;

    //[Header("File Explorer")]
    [SerializeField]
    private GameObject downloads, firewall, commandPrompt;

    void Start()
    {
        tab1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
