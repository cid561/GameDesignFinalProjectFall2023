using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Image im;
    [SerializeField] Color fill = Color.black;
    [SerializeField] Canvas can;
    [SerializeField] float fadeTime;
    Image local;
    // Start is called before the first frame update
    
    void Awake()
    {
                local = Instantiate(im,can.transform);//set image over screen
        StartCoroutine(FadeInRoutine());//start a co routine
        IEnumerator FadeInRoutine()//define the co routine
        {
            float tempTime = 0f;
            yield return null;
            while (tempTime<fadeTime)
            {
                yield return null;
                tempTime += Time.deltaTime;
                float fade = 1f-(tempTime/fadeTime);
                local.color = new Color(fill.r,fill.g,fill.b,fade);
                yield return null;
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeOut()
    {
        //local = Instantiate(im,can.transform);//instantiate a local transparent image over the scene as a child of the canvas
        StartCoroutine(FadeOutRoutine());//start a co routine
        IEnumerator FadeOutRoutine()//define the co routine
        {
            float tempTime = 0f;//local temp time var
            yield return null;
            while(tempTime<fadeTime)//while the ammount of passed time is less than the fade time
            {
                yield return null;
                tempTime += Time.deltaTime;//add time passed to temp time
                float fade =  (tempTime/fadeTime);//fade is the % of time has passed compared to fade time
                local.color = new Color(fill.r,fill.g,fill.b,fade);// adjust color
                yield return null;
            }
            yield return null;
            string temp = SceneManager.GetActiveScene().name;//get name of current scene
            if(temp == "MainMenue")//if we are at the main menue
            {
                SceneManager.LoadScene("BattleRoom");//go to battle
            }
            else
            {
                SceneManager.LoadScene("MainMenue");//go to main
            }

        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
