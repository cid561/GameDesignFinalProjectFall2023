using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject missile;
    [SerializeField] GameObject gold;
    [SerializeField] GameObject heal;
    [SerializeField] Camera cam;
    [SerializeField] GameObject poolManager;
    GameObject local;
    Vector3 target;
    // Start is called before the first frame update
    
    void Awake()
    {
        poolManager = GameObject.Find("pool");
        Player = GameObject.Find("Player");
        Vector2 start = transform.position;//set current postion to gameobj postion
        Vector2 play = Player.transform.position;//set target location to player's position
        target = play - start;
        cam = Camera.main;
        //ThrowProjectileAtPlayer(target);
        StartCoroutine(MoveIntoCameraRoutine());  
    }
    
    void Start()
    {


  
    }

    // Update is called once per frame
    void Update()
    {   
        //Vector3 curLoc = transform.position;
        //if(IsVisible1(transform.position))
        //{
            //ThrowProjectileAtPlayer(target);
       // }
        //transform.position += target * Time.deltaTime;
        IsVisible1(transform.position);
    }
    private void ThrowProjectileAtPlayer(Vector2 tar)
    {
        IEnumerator disableAfter2Seconds(GameObject here)
        {
            Debug.Log("disable");
            yield return new WaitForSeconds(1f);//wait two seconds
            here.SetActive(false);//disable object
        }

        //local = Instantiate(missile,foeLoc,Quaternion.identity);
        //local.GetComponent<ProjectileMovement>().target = direction;
        GameObject proj = poolManager.GetComponent<opjectPool>().getProjectile();
        Debug.Log(proj);
        if(proj != null)
        {
            Vector2 foeLoc = transform.position;//set current location
            Vector2 direction = new Vector2(0,0);
            direction = tar - foeLoc;
            proj.transform.position = foeLoc;
            proj.GetComponent<ProjectileMovement>().SetTarget(direction);
            proj.SetActive(true);
            StartCoroutine(disableAfter2Seconds(proj));
        }
    }
    private bool IsVisible1(Vector3 pos)
    {
        Vector3 temp = cam.WorldToViewportPoint(pos);
        if(temp.x<1 && temp.x > 0 && temp.y > 0 && temp.y < 1)
        {
            return true;
        }
        else{
            return false;
        }
    }
    IEnumerator MoveIntoCameraRoutine()
    {
        yield return null;
        Vector3 here = transform.position;
        while(IsVisible1(transform.position) != true)//while the gameobject is not in the camera view loop
        {   
            yield return new WaitForSeconds(0.05f);
            transform.position += target *5f* Time.deltaTime;//move toward player (Player.transform.position-transform.position)
        }
        int count = 0;
        while(count<25)
        {
            yield return null;
            transform.position += target *0.9f* Time.deltaTime;
            count++;
        }
        ThrowProjectileAtPlayer(target);
        Debug.Log("here");
        Destroy(gameObject,2);
        count = 0;
        while(count<5)
        {
            yield return null;
            transform.position -= target *1.9f* Time.deltaTime;
            count++;
        }
        Destroy(gameObject,1);//after entering the camera's view desroy self after time
        Vector3 temp = transform.position;
        float loot = Random.Range(0f,1f);
        if(loot>0.1)
        {
        Instantiate(gold,temp,Quaternion.identity);
        }
        else{
        Instantiate(heal,temp,Quaternion.identity);
        }
    }
}
