using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupHandGun : MonoBehaviour
{
    public AudioSource ammoSound;
    public HandGunAmmo globalAmmo;
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Picking up ammo");
            ammoSound.Play();
            if(HandGunAmmo.loadedAmmo == 0)
            {
                HandGunAmmo.loadedAmmo += 6;
                HandGunAmmo.currentAmmo += 4;
                globalAmmo.SendMessage("DrawClip");
            } else {HandGunAmmo.currentAmmo += 10;}
            this.gameObject.SetActive(false);
        }
    }
}
