using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float health = 10;
    //[SerializeField] float MaxHealth = 10;
    [SerializeField] int gold = 0;
    [SerializeField] Text textBox;
    [SerializeField] GameObject sce;
    [SerializeField] GameObject collectSound;
    [SerializeField] GameObject damageSound;
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
            Destroy(coll.gameObject);
            GameObject local = Instantiate(collectSound);
            Destroy(local,2);
        }
        else if(coll.gameObject.name.Contains("health_up"))
        {
            health+=1;
            Destroy(coll.gameObject);
            GameObject local = Instantiate(collectSound);
            Destroy(local,2);
        }
        else if(coll.gameObject.name.Contains("key"))
        {
            sce.GetComponent<SceneTransition>().FadeOut();
        }
        else if(coll.gameObject.name.Contains("Square"))
        {

        }
        else
        {
        TakeDamage(1f);
        coll.gameObject.SetActive(false);
        GameObject local = Instantiate(damageSound);
        Destroy(local,2);
        }
        
    }
    //IEnumerator ShowLowHealth()
   // {

   // }
}
