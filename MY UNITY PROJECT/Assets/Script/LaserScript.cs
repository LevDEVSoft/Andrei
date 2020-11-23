using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float Firerate;
    public float Firerange;
    public float HitForce;
    public int LaserDamage;
    private LineRenderer LaserLine;
    private bool LaserLineEnabled;
    private WaitForSeconds LaserDuration;
    private float nextFire;
    


    // Start is called before the first frame update
    void Start()
    {
        LaserLineEnabled = GetComponent<LineRenderer>();
    }


    void Fire()
    {
        Transform cam = Camera.main.transform;
        nextFire = Time.time + Firerate;
        Vector3 rayorigin = cam.position;
        LaserLine.SetPosition(0, transform.up * -10);
        RaycastHit hit;
        if (Physics.Raycast(rayorigin, cam.forward, out hit, Firerange)) 
        {
            LaserLine.SetPosition(1, hit.point);
            Movement cubectrl = hit.collider.GetComponent<Movement>();
            if (cubectrl != null)
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * HitForce);
                    cubectrl.Hit(LaserDamage);
                }

            }
        }
        

        else
        {
            LaserLine.SetPosition(1, cam.forward * Firerange);

        }
        StartCoroutine("Laserfx");
    }
     void FixedUpdate()
    {
        if(Input.GetButtonDown("fire1"))
        {
            Fire();
        
        }
        
    }

    private IEnumerator Laserfx()
    {
        LaserLine.enabled = true;
        yield return LaserDuration;
        LaserLine.enabled = false;
    
    
    }
}




// Update is called once per frame
