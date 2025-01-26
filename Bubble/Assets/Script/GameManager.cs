using MoreMountains.Feedbacks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool blockInput;
    public PlayerMove score1;
    public PlayerMove score2;

    public MMF_Player P1Winning;
    public MMF_Player P2Winning;
    public MMF_Player P1Win;
    public MMF_Player P2Win;

    public void Update()
    {
        //almost win!
        if (score1.score == 15)
        {
            P1Winning.PlayFeedbacks();
        }

        if (score2.score == 15)
        {
            P2Winning.PlayFeedbacks();
        }

        //win!
        if (score1.score == 20)
        {
            P1Win.PlayFeedbacks();
        }
        if (score2.score == 20)
        {
            P2Win.PlayFeedbacks();
        }
    }
}
