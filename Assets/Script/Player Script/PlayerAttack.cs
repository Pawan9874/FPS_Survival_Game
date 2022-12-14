using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    private float damage = 20f;

    private Animator zoomCameraAnim;
    private bool zoomed;

    private Camera mainCam;
    private GameObject crosshair;
    private bool is_Aiming;


    // Start is called before the first frame update
    void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();

        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA)
                            .GetComponent<Animator>();

        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
        ZoomInAndOut();
    }

    void WeaponShoot()
    {
        if(weapon_Manager.GetCurrentSelectedWeapon().FireType == WeaponFireType.MULTIPLE)
        {
            if(Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation(); 
            }
           
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                }

                if (weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                    //BulletFired();
                }
                else
                {
                    
                    if(is_Aiming)
                    {
                        weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                        if(weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.ARROW)
                        {

                        }
                        else if(weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.SPEAR)
                        {

                        }
                    }

                }
            }
        }
    }

    void ZoomInAndOut()
    {
        if(weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);
                crosshair.SetActive(false);
            }
            if(Input.GetMouseButtonUp(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
                crosshair.SetActive(true);
            }
        }

        if(weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.SELF_AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                weapon_Manager.GetCurrentSelectedWeapon().Aim(true);
                is_Aiming = true;
            }
            if(Input.GetMouseButtonDown(1))
            {
                weapon_Manager.GetCurrentSelectedWeapon().Aim(false);
                is_Aiming = false;
            }
        }

    }

}
