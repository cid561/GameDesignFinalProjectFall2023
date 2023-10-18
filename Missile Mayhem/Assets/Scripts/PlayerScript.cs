using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float health = 10;
    [SerializeField] float MaxHealth = 10;
    [SerializeField] int gold = 0;
    [SerializeField] Text textBox;
    Text score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = textBox.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            SceneManager.LoadScene("MainMenue");
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {   
        if(coll.gameObject.name.Contains("Gold"))
        {
            gold+=10;
            score.text = "Gold: "+ gold.ToString();
            textBox.text = "Gold: "+ gold.ToString();
        }
        else
        {
        TakeDamage(1f);
        }
        Destroy(coll.gameObject);
    }
    //IEnumerator ShowLowHealth()
   // {

   // }
}
