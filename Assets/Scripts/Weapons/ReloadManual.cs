using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadManual : MonoBehaviour
{
    [SerializeField]
    KeyCode keyReload;

    public GameObject globalAmmo;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(keyReload))
        {
            globalAmmo.SendMessage("ReloadManual");
        }
    }
}
