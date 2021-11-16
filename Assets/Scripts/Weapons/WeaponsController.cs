using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WeaponsController : MonoBehaviour
{
    public static GameObject[] ammoPanes;
    public static GameObject[] weapons;
    public static string[] weaponLabels;
    public static GameObject activePane;
    public static GameObject activeWeapon;

    public GameObject emptyAmmoPane;
    public GameObject handgunAmmoPane;
    public GameObject smgAmmoPane;
    public TMP_Text weaponDisplay;
    public GameObject handgun;
    public GameObject smg;
    public bool hasHandgun;
    public bool hasSMG;

    public static bool hasWeapon;

    // Start is called before the first frame update
    void Start()
    {
        hasWeapon = false;
        hasHandgun = false;
        hasSMG = false;
        ammoPanes = new GameObject[] {emptyAmmoPane, handgunAmmoPane, smgAmmoPane};
        weapons = new GameObject[] { handgun, smg };
        weaponLabels = new string[] { "9mm", "MP5K" };
        activePane = emptyAmmoPane;
        activePane.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && hasHandgun)
        {
            EquipWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasSMG)
        {
            EquipWeapon(2);
        }
    }

    public void EquipWeapon(int id)
    {
        hasWeapon = true;
        activePane = ammoPanes[id];
        activeWeapon = weapons[id - 1];
        foreach (GameObject pane in ammoPanes)
        {
            pane.SetActive(false);
        }
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        activePane.SetActive(true);
        if (activeWeapon != null)
        {
            activeWeapon.SetActive(true);
        }
        weaponDisplay.text = weaponLabels[id-1];
    }
}
