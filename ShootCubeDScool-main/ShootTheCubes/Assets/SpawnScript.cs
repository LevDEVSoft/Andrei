using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;// Use Vuforia AR camera 

public class SpawnScript : MonoBehaviour
{   public GameObject spawnee;
    public int TotalSpawnee;
    public float TimeToSpawn;
    private GameObject[] SpawneeList;
    private bool PositionSet;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Spawnloop());// Mistake it was missing
        SpawneeList = new GameObject[TotalSpawnee];
    }

    // Update is called once per frame
    void Update()
    {
         

    }

    private bool SetPosition()
    {
        Transform cam = Camera.main.transform;
        transform.position = cam.forward * 10;
        return true;
    }

    private IEnumerator ChangePosition()
    {
        yield return new WaitForSeconds(0.2f);
            if (!PositionSet) // Mistake !
        {
            if (VuforiaBehaviour.Instance.enabled) 
            {
                SetPosition();
            }
        }
    }

    private IEnumerator Spawnloop()
    {
        StartCoroutine(ChangePosition());
        yield return new WaitForSeconds(0.2f);
        int i = 0;
        while (i<= (TotalSpawnee - 1))//Mistake ()// ["Arkadi", "Taniel","Lev"]
        {
            SpawneeList[i] = SpawnElement();
            i++;
            yield return new WaitForSeconds(Random.Range(TimeToSpawn,TimeToSpawn*3));// mistake inside while
        }
        
    } 
    private GameObject SpawnElement()
    {
        GameObject spawnobject = Instantiate(spawnee, (Random.insideUnitSphere * 4)+transform.position, transform.rotation) as GameObject;//mistake +transform position
        float scale = Random.Range(0.5f, 2f);
        spawnobject.transform.localScale = new Vector3(scale, scale, scale);
        return spawnobject;
    }

}
