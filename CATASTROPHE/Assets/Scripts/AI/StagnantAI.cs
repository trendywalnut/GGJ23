using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagnantAI : MonoBehaviour
{

    [SerializeField]
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBehavior());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartBehavior()
    {
        while (true)
        {
            yield return StartCoroutine(Behavior());
        }
    }

    IEnumerator Behavior()
    {
        //TODO
        yield return new WaitForSeconds(10f);
    }

}
