using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundTransition : MonoBehaviour
{

    [SerializeField] private float fadeTime;

    private void OnEnable()
    {
        Debug.Log(gameObject.name + " is Enabling");
        GetComponent<SpriteRenderer>().DOFade(0, 0);
        GetComponent<SpriteRenderer>().DOFade(255, fadeTime);
    }

    private void OnDisable()
    {
        GetComponent<SpriteRenderer>().DOFade(0, fadeTime);
    }

}
