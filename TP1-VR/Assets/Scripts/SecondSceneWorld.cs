using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SecondSceneWorld : MonoBehaviour
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
        headText.SetText("Vous avez tué le Dragon Celeste");
    }

    IEnumerator TimerTick()
    {
        while (GameVariables.currentTime > 0)
        {
            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;
            timerText.text = "Time :" + GameVariables.currentTime.ToString();

            
        }


        GameVariables.currentTime = 90;
        SceneManager.LoadScene("CatBots");
    }
}
