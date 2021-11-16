using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SMGAmmo : MonoBehaviour
{
    public static int currentAmmo;
    public int internalAmmo;

    public static int loadedAmmo;
    public int internalLoadedAmmo;
    string ammoClip = "";

    public TMP_Text ammoDisplay;
    public TMP_Text loadedAmmoDisplay;
    public AudioSource reloadSound;

    private void Start()
    {
        currentAmmo = internalAmmo;
        loadedAmmo = internalLoadedAmmo;
        DrawClip();
    }
    // Update is called once per frame
    void Update()
    {
        internalAmmo = currentAmmo;
        internalLoadedAmmo = loadedAmmo;
        ammoDisplay.text = internalAmmo.ToString();
    }
    public void DrawClip()
    {
        for (int i = 0; i < loadedAmmo; i++)
        {
            ammoClip = ammoClip.Insert(i, "I");
        }
        loadedAmmoDisplay.text = ammoClip;
        ammoClip = "";
    }

    public void ReloadAutomatic()
    {
        int reloadingAmmo;
        if (currentAmmo >= 30)
        {
            reloadingAmmo = 30;
        }
        else if (currentAmmo > 0 && currentAmmo < 30)
        {
            reloadingAmmo = currentAmmo;
        }
        else { reloadingAmmo = 0; }

        reloadSound.Play();
        currentAmmo -= reloadingAmmo;
        loadedAmmo += reloadingAmmo;
        DrawClip();
    }

    public void ReloadManual()
    {
        if (loadedAmmo < 30)
        {
            int reloadingAmmo = 30 - loadedAmmo;
            if (currentAmmo >= reloadingAmmo)
            {
                currentAmmo -= reloadingAmmo;
                loadedAmmo += reloadingAmmo;
            }
            else
            {
                reloadingAmmo = currentAmmo;
                currentAmmo -= reloadingAmmo;
                loadedAmmo += reloadingAmmo;
            }
            Debug.Log("Reloading with " + reloadingAmmo.ToString()+ " bullets");
            reloadSound.Play();
            DrawClip();
        }
    }
}
