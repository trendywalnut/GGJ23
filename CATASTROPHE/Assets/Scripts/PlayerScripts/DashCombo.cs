using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DashCombo : MonoBehaviour
{
    private int comboNum = 0;
    private bool changed = false;
    private bool reset = false;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private float comboResetTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        comboText.SetText(comboNum.ToString());
        if (reset)
        {
            comboNum = 0;
        }
    }

    public void IncreaseCombo()
    {
        comboNum++;
        changed = true;
        comboText.transform.DOShakePosition(0.5f, 10f, 10, 20);
    }

    IEnumerator ResetCombo()
    {
        yield return new WaitForSeconds(comboResetTimer);
        changed = false;
        yield return new WaitForSeconds(comboResetTimer);
        if(!changed)
        {
            reset = true;
        }
    }
}
