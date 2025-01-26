using MoreMountains.Feedbacks;
using UnityEngine;

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
        if (score1.score == 20 && P1WnPlayed == false)
        {
            P1Win.PlayFeedbacks();
            P1WnPlayed=true;
            P2WinPlayed=true;
        }
        if (score2.score == 20 && P2WinPlayed == false)
        {
            P2Win.PlayFeedbacks();
            P1WnPlayed = true;
            P2WinPlayed = true;
        }
    }
}
