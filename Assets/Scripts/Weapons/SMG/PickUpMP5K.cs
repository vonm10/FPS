using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpMP5K : MonoBehaviour
{
    public TMP_Text textDisplay;
    public GameObject fakeGun;
    public GameObject realGun;
    public AudioSource pickupSound;
    public SMGAmmo globalAmmo;
    public WeaponsController weaponsController;

    float distanceFromGun;
    GameObject hitObject;

    // Update is called once per frame
    void Update()
    {
        distanceFromGun = PlayerCasting.distanceFromTarget;
        hitObject = PlayerCasting.hitTarget;
        if (Input.GetButtonDown("Action") && distanceFromGun <= 2
            && hitObject.Equals(gameObject))
        {
            PickUpGun();
        }
    }

    private void OnMouseOver()
    {
        if (distanceFromGun <= 2)
        {
            textDisplay.text = "[E] Pick up MP5K";
        }
        else
        {
            textDisplay.text = "";
        }
    }

    private void OnMouseExit()
    {
        textDisplay.text = "";
    }

    private void PickUpGun()
    {
        transform.position = new Vector3(0, -1000, 0);
        pickupSound.Play();
        weaponsController.hasSMG = true;
        weaponsController.EquipWeapon(2);
        if (SMGAmmo.loadedAmmo == 0)
        {
            globalAmmo.ReloadAutomatic();
        }
    }
}
