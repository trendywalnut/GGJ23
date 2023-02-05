using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopUp : MonoBehaviour
{

    [SerializeField] private float timeToTween;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, timeToTween);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Button") && hit.collider.transform.IsChildOf(transform))
            {
                if (Input.GetMouseButtonDown(0))
                    StartCoroutine(ClosePopUp());
            }
        }        
    }

    IEnumerator ClosePopUp()
    {
        transform.DOScale(Vector3.zero, timeToTween);
        PopUpManager.Instance.popUpsClosed++;

        yield return new WaitForSeconds(timeToTween);

        Destroy(gameObject);
    }

    private void OnDisable()
    {
        
    }

}
