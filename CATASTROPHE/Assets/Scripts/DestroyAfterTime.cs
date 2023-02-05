using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float destroyTimer = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", destroyTimer);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
