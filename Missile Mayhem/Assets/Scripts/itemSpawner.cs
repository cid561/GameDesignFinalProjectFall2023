using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemSpawner : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameObject key;
    [SerializeField] int limit = 50;
    GameObject singleton;
    int gold = 0;
    string txt;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt = text.text;
        txt = txt.Substring(5);
        gold = int.Parse(txt);
        Vector2 temp = new Vector2(0,0);
        if(singleton == null && gold >=limit)//singleson right here, if there is no key present make one
        {
            singleton = Instantiate(key,temp,Quaternion.identity);
            Destroy(singleton,3);
        }
    }
}
