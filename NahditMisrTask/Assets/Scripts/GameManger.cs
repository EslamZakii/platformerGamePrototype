using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
 

public class GameManger : MonoBehaviour
{
    [SerializeField] GameObject HowToPlay;
    [SerializeField] GameObject Paused;
 public int Apple { set; get; }
    public    int Melon { set; get; }
    public int Score { set; get; } 
 public TextMeshProUGUI totalMelon;
 public   TextMeshProUGUI totalApple;
 public   TextMeshProUGUI collectedMelon;
 public   TextMeshProUGUI collectedApple;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    

    void Start()
    {
        collectedMelon= GameObject.FindGameObjectWithTag("collectedMelon").GetComponentInChildren<TextMeshProUGUI>();
        collectedApple = GameObject.FindGameObjectWithTag("collectedapples").GetComponentInChildren<TextMeshProUGUI>();
        totalApple = GameObject.FindGameObjectWithTag("totalAppletxt").GetComponentInChildren<TextMeshProUGUI>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponentInChildren<TextMeshProUGUI>();
        totalMelon = GameObject.FindGameObjectWithTag("totalMelontxt").GetComponentInChildren<TextMeshProUGUI>();
        totalApple.text = GameObject.FindGameObjectsWithTag("CollectableApple").Length.ToString();
        totalMelon.text = GameObject.FindGameObjectsWithTag("Collectables").Length.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        collectedMelon.text = Melon.ToString();
        collectedApple.text= Apple.ToString();
        score.text = Score.ToString();
    }
    public void howtplay()
    {
        if (HowToPlay.activeInHierarchy == true)
        {
            HowToPlay.gameObject.SetActive(false);
        }
       else  if (HowToPlay.activeInHierarchy == false)
        {
            HowToPlay.gameObject.SetActive(true);
        }
    }
    public void PauseandPlay()
    {
        if (Time.timeScale==0)
        {
            Time.timeScale = 1;
            Paused.gameObject.SetActive(false);
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Paused.gameObject.SetActive(true);

        }
    }

    public void relodScnen()
    {
        SceneManager.LoadScene(0);
    }
}
