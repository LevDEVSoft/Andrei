using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float fireRate;
    public float FireRange;
    public float HitForce;
    public int LaserDamage;
    private LineRenderer laserline;
    private bool laserlineEnabled;
    private WaitForSeconds laserDuration=new WaitForSeconds(0.05f);
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        laserline = GetComponent<LineRenderer>();
       
    }

    void Fire()
    {
        Transform cam = Camera.main.transform;
        nextFire = Time.time + fireRate;
        Vector3 rayorigin = cam.position;
        laserline.SetPosition(0, transform.up * -10);
        RaycastHit hit;
        if (Physics.Raycast(rayorigin, cam.forward, out hit, FireRange))
        {
            laserline.SetPosition(1, hit.point);
            CubeBehavior cubecrtl = hit.collider.GetComponent<CubeBehavior>();
            if(cubecrtl!=null)
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * HitForce);
                    cubecrtl.Hit(LaserDamage);
                }
            }
        }
        else
        {
            laserline.SetPosition(1, cam.forward * FireRange);
        }

        StartCoroutine("LaserFX");




    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            Fire();
            
        }
    }

   private IEnumerator LaserFX()
    {
        laserline.enabled = true;
        yield return laserDuration;
        laserline.enabled = false ;
    }
}
