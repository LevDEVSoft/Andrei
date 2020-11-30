using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public float scalemax;
    public float scalemin;
    public float maxOrbitSpeed;
    private float OrbitSpeed;
    private Transform orbitAnchor;// mistake
    private Vector3 orbitDirection;
    private Vector3 maxscale;
    public float growingSpeed;
    private bool isScaled=false;
    public int health;
    private bool isAlive = true;
    public GameObject explosion;



    // Start is called before the first frame update
    void CubeSettings()
    {
        orbitAnchor = Camera.main.transform;// Mistake was missing
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        orbitDirection = new Vector3(x, y, z);

        OrbitSpeed = Random.Range(.5f, maxOrbitSpeed);// Mistake .5

        float scale = Random.Range(scalemin, scalemax);
        maxscale = new Vector3(scale, scale, scale);
        transform.localScale = Vector3.zero; 
    }

   
    private void Update()
    {
        RotateCube();
        if (!isScaled)
        {
            ScaleObject();
        }
    }

    private void RotateCube()
    {
        transform.RotateAround(orbitAnchor.position, orbitDirection, OrbitSpeed * Time.deltaTime);
        transform.Rotate(orbitDirection * 30 * Time.deltaTime);
    }

    private void Start()
    {
        CubeSettings();
    }


    void ScaleObject()
    {
        if (transform.localScale != maxscale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxscale, Time.deltaTime * growingSpeed);
            isScaled = true;
        }
    }

    public bool Hit(int hitDamage)
    {
        health -= hitDamage;
        if(health>=0 && isAlive)
        {
            StartCoroutine("DestroyCube");
            return true;
        }
        return false;
    }

    private IEnumerator DestroyCube()
    {
        isAlive = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
        //GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject); 

    }
      

}
