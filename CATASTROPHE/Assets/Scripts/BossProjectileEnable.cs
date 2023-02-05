using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileEnable : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;

    private bool once = false;
    private void Update()
    {
        if (BossAttackSM.Instance.isHalfHealth && !once)
        {
            EnableTheSpawners();
            once = true;
        }
    }

    private void EnableTheSpawners()
    {
        foreach(GameObject thing in spawners)
        {
            thing.SetActive(true);
        }
    }
}
