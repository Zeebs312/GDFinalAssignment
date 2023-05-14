using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Weapon damage variables
    public float gunDmg = 1000000f;

    //Range of gun
    public float range = 50f;
    public float reloadTime = 1f;
    public static bool canShoot = false;

    public Camera fpscam;

    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (canShoot == true)
        {
            //Plays partical system
            //muzzleFlash.Play();
            RaycastHit hit;

            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
            {
                MasterKohga enemy = hit.transform.GetComponent<MasterKohga>();
                if (enemy != null)
                {
                   enemy.TakeDamage(gunDmg);
                }
            }
        }
    }
}
