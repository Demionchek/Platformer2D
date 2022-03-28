using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomDelete : MonoBehaviour
{
    void Start()
    {
        Invoke("Del",0.2f);
    }

    private void Del()
    {
        Destroy(gameObject);
    }
}
