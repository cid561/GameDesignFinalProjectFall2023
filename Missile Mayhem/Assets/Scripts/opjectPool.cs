using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opjectPool : MonoBehaviour
{
    private List<GameObject> objs = new List<GameObject>();
    private int size = 20;
    [SerializeField] GameObject proj;
    // Start is called before the first frame update
    void Start()
    {
        for(int a = 0;a<size;a++)
        {
            GameObject ob = Instantiate(proj);
            ob.SetActive(false);
            objs.Add(ob);
        }
    }
    public GameObject getProjectile()
    {
        Debug.Log("start");
        for(int i = 0; i < objs.Count;i++)
        {
            Debug.Log("Here");
            if(!objs[i].activeInHierarchy)
            {
                Debug.Log(objs[i]);
                return objs[i];
            }
        }
        return null;
    }
}
