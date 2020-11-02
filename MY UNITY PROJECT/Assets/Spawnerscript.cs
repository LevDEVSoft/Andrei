using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Spawnerscript : MonoBehaviour
{
    public int Totalspawnee;
    public float timeToSpawn;
    public GameObject spawnee;
    public GameObject[] SpawneeList;
    private bool positionSet;
    private IEnumeratot Spawnloop()
    {
        StartCorountine(Change.Position());
        yield return new WaitForSeconds(0, 2f);
        int i = 0;
        while(i < Totalspawnee - 1)
        {
            SpawneeList[i];
        }
    }





    private GameObject SpawnElement()
    {
        GameObject spawnobject = Instiate(spawnee, (Random.insideUnitSphere * 4) + transform.rotation, transform.ratation) as gameObject;
        float scale = Random.Range(0.5f, 2f);
        spawnobject.transform.localScale = new Vector3(scale, scale, scale);
        return spawnobject;
    }
}
