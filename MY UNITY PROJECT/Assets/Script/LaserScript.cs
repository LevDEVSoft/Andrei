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
            Movement movement = hit.collider.GetComponent<Movement>();
            if (movement != null)
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * HitForce);
                    movement.Hit(LaserDamage);
                }

            }
        }
        

        else
        {
            LaserLine.SetPosition(1, cam.forward * Firerange);

        }
        StartCoroutine("Laserfx");
    }
    private void Update()
    {
        if(Input.GetButtonDown("fire1"))
        {
            Fire();
        
        }
        
    }
}




// Update is called once per frame
