using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupSMG : MonoBehaviour
{
    public AudioSource ammoSound;
    public SMGAmmo globalAmmo;
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Picking up ammo");
            ammoSound.Play();
            if(SMGAmmo.loadedAmmo == 0)
            {
                SMGAmmo.loadedAmmo += 30;
                SMGAmmo.currentAmmo += 20;
                globalAmmo.SendMessage("DrawClip");
            } else {SMGAmmo.currentAmmo += 50;}
            this.gameObject.SetActive(false);
        }
    }
}
