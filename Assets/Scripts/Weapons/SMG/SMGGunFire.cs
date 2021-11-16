using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGGunFire : MonoBehaviour
{
    [SerializeField]
    float gunFireSpeed;

    Animation anim;
    AudioSource gunsound;
    public SMGAmmo globalAmmo;
    public GameObject muzzleFlash;
    public int damageAmount;
    public int allowedRange;

    float attackRate = 10f;
    float nextAttackTime = 0f;

    void Awake()
    {
        anim = GetComponent<Animation>();
        gunsound  = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButton("Fire1"))
            {
                if (SMGAmmo.loadedAmmo > 0)
                {
                    Shoot();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                else
                {
                    globalAmmo.SendMessage("ReloadAutomatic");
                }

            }
        }
        
    }

    private void Shoot()
    {
        gunsound.Play();
        muzzleFlash.SetActive(true);
        StartCoroutine(muzzleFlashStop());
        anim["SMGGunFire"].speed = gunFireSpeed;
        anim.Play("SMGGunFire");
        SMGAmmo.loadedAmmo -= 1;
        globalAmmo.SendMessage("DrawClip");
        if (PlayerCasting.hasTarget && PlayerCasting.distanceFromTarget < allowedRange)
        {
            Debug.Log(PlayerCasting.hitTarget.name);
            PlayerCasting.hitTarget.SendMessage("DeductHealthPoints", damageAmount, SendMessageOptions.DontRequireReceiver);
        }
    }

    private IEnumerator muzzleFlashStop()
    {
        yield return new WaitForSeconds(0.08f);
        muzzleFlash.SetActive(false);
    }
}
