using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 1.0f;
    [SerializeField] float TurnSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector2 movDir = new Vector2(horz,vert);
        float mag = Mathf.Clamp01(movDir.magnitude);
        transform.Translate(movDir*PlayerSpeed*Time.deltaTime,Space.World);
        movDir.Normalize();
        

        if(movDir != Vector2.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(transform.forward,movDir);
            Quaternion rot = Quaternion.RotateTowards(transform.rotation,targetRot,TurnSpeed*Time.deltaTime);
            transform.rotation = rot;
        }
    }
}
