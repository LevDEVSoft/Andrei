using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Spawnscript : MonoBehaviour
{
    public int Totalspawnee;
    public float timeToSpawn;
    public GameObject spawnee;
    public GameObject[] SpawneeList;
    //private bool positionSet;
    private bool PositionSet;

    private void Start()
    {
        StartCoroutine(Spawnloop());
        SpawneeList = new GameObject[Totalspawnee];
    }

    private void Update()
    {
        
    }



    private bool SetPosition()
    {
        Transform cam = Camera.main.transform;
        transform.position = cam.forward * 10;
        return true;
    
    }

    IEnumerator Changeposition()
    {
        yield return new WaitForSeconds(0.2f);
        if (!PositionSet)
        {
            if (vuforiaBehaviour.instance.enabled)
            {
                SetPosition();
            }
        
        }
    }

    private IEnumerator Spawnloop()
    {
        StartCoroutine(Changeposition());
        yield return new WaitForSeconds(0.2f);
        int i = 0;
        while(i < (Totalspawnee - 1))
        {
            SpawneeList[i] = SpawnElement();
            i++;
                yield return new WaitForSeconds(Random.Range(timeToSpawn, timeToSpawn * 3));
        }
    }





    private GameObject SpawnElement()
    {
        GameObject spawnobject = Instantiate(spawnee, (Random.insideUnitSphere * 4) + transform.position, transform.rotation) as GameObject;
        float scale = Random.Range(0.5f, 2f);
        spawnobject.transform.localScale = new Vector3(scale, scale, scale);
        return spawnobject;
    
    
    
    
    
    }



}


