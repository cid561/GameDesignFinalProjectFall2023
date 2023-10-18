using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeSpawner : MonoBehaviour
{
    [SerializeField] GameObject foe;
    [SerializeField] float waitTime = 1f;
    [SerializeField] Camera cam;
    private float val = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFoesOffScreenRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFoesOffScreenRoutine()
    {
        yield return new WaitForSeconds(waitTime);
        float timer = 0f;
        while(timer < 30)
        {
        yield return new WaitForSeconds(1);
        Vector3 loc = new Vector3(0,0,0);
        float PickSpawnSide = Random.Range(0f,1f);
        //if the value is between 0-0.25 spawn on left side
        if(PickSpawnSide<=0.25f)
        {
            loc = new Vector3(-0.1f,Random.Range(0f,1f),0f);
        }
        //if the value is between 0.26-0.5 spawn on bottom side
        else if(PickSpawnSide<=0.50f)
        {
            loc = new Vector3(Random.Range(0f,1f),-0.1f,0f);
        }
        //if the value is between 0.51-0.75 spawn on right side
        else if(PickSpawnSide<=0.75f)
        {
            loc = new Vector3(1.1f,Random.Range(0f,1f),0f);
        }
        //if the value is more than 0.76 spawn on top side
        else
        {
            loc = new Vector3(Random.Range(0f,1f),1.1f,0f);
        }
        loc = cam.ViewportToWorldPoint(loc);
        loc.z = 0;
        yield return null;
        Instantiate(foe,loc,Quaternion.identity);
        }
    }
    IEnumerator SpawnFoeCornerRoutine()
    {
        yield return null;
    }
}
