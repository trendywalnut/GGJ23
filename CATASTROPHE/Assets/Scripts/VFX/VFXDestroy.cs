using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDestroy : MonoBehaviour
{
    public void destroyVFX()
    {
        Destroy(GetComponentInParent<Transform>().gameObject);
    }
}
