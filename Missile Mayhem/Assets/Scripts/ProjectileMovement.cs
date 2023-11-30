using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] public Vector2 target;
    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)//when the projectile has a target
        {
            transform.Translate(target*speed*Time.deltaTime,Space.World);//move to the target
        }
    }
    public void SetTarget(Vector2 goal)
    {
        target = goal;
    }
}
