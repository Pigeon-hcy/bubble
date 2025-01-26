using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool blockInput;
    public PlayerMove score1;
    public PlayerMove score2;

    public MMF_Player P1Winning;
    public bool P1WnPlayed;
    public MMF_Player P2Winning;
    public bool P2WinningPlayed;
    public MMF_Player P1Win;
    public bool P1WinPlayed;
    public MMF_Player P2Win;
    public bool P2WinPlayed;

    public AudioSource BGM1;
    public AudioSource BGM2;


    public GameObject Spawnner;
    public AudioSource BGM3;
    public MMF_Player onGameStart;
   
    public void Update()
    {
        //almost win!
        if (score1.score == 15 && P1WnPlayed == false)
        {
            P1Winning.PlayFeedbacks();
            P1WnPlayed = true;
            BGM1.volume = 0;
            BGM2.volume = 1;
        }

        if (score2.score == 15 && P2WinningPlayed == false)
        {
            P2Winning.PlayFeedbacks();
            P2WinningPlayed = true;
            BGM1.volume = 0;
            BGM2.volume = 1;
        }

        //win!
        if (score1.score >= 20 && P1WinPlayed == false)
        {
            P1Win.PlayFeedbacks();
            P1WinPlayed = true;
            P2WinPlayed=true;
        }
        if (score2.score >= 20 && P2WinPlayed == false)
        {
            P2Win.PlayFeedbacks();
            P1WnPlayed = true;
            P2WinPlayed = true;
        }
    }

    public void reload()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void OnGamestart()
    {
        StartCoroutine(startYourEngine());
    }

    private IEnumerator startYourEngine()
    {
        onGameStart.PlayFeedbacks();
        yield return new WaitForSeconds(3);
        Spawnner.SetActive(true);
        score1.enabled = true;
        score2.enabled = true;
        BGM3.volume = 0;
        BGM1.volume = 1;
    }
}
