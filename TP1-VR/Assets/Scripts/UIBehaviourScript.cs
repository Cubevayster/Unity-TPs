using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIBehaviour : MonoBehaviour
{
    TMP_Text headText;
    TMP_Text timerText;
    int nbCatsHits = 0;
    public randomBotCat spawner;
    void Start()
    {
        headText = GameObject.Find("lblCats").GetComponent<TMPro.TMP_Text>();
        timerText = GameObject.Find("lblTime").GetComponent<TMPro.TMP_Text>();
        StartCoroutine(TimerTick());
    }

    void Update()
    {
        
    }

    public void AddHit()
    {
        nbCatsHits++;
        headText.SetText("NbChats Détruits: " + nbCatsHits);
    }

    IEnumerator TimerTick()
    {
        while (GameVariables.currentTime > 0)
        {
            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;
            timerText.text = "Time :" + GameVariables.currentTime.ToString();

            if(nbCatsHits == spawner.nbObjects)
            {
                SceneManager.LoadScene("DragonVersus");
            }
        }


        GameVariables.currentTime = 90;
        SceneManager.LoadScene("CatBots"); 
    }
}
