using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float scalemax;
    public float scalemin;
    public float maxOrbitSpeed;
    float orbitSpeed;
    public Transform orbitAnchor;
    Vector3 OrbitDirection;
    Vector3 maxScale;
    public float GrowingSpeed;
    private bool IsScaled = false;


    
    void CubeSettings()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        OrbitDirection = new Vector3(x, y, z);
        orbitSpeed = Random.Range(0.5f, maxOrbitSpeed);
        float scale = Random.Range(scalemin, scalemax);
        transform.localScale = Vector3.zero;
        maxScale = new Vector3(scale, scale, scale);




    }
    void Start()
        {
            CubeSettings();

        }
    private void Update()
        {
        RotateCube();
            if(!IsScaled)
            {
                ScaleObject();
            }

        }
    void RotateCube()
        {
            transform.RotateAround(orbitAnchor.position, OrbitDirection, orbitSpeed * Time.deltaTime);
        transform.Rotate(OrbitDirection * 30 * Time.deltaTime);

        }
  

    void ScaleObject()
    {
        if (transform.localScale != maxScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxScale, Time.deltaTime * GrowingSpeed);
            IsScaled = true;
        }
    }


}

