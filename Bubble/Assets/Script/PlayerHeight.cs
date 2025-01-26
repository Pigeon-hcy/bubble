using MoreMountains.Feedbacks;
using UnityEngine;

public class PlayerHeight : MonoBehaviour
{
    public int height;
    public PlayerHeight AnotherPlayer;
    public MMF_Player PlayerMoveUp;
    
    public MMF_Player AnotherPlayerMoveDown;
    public MMF_Player starOnHead;
    public MMF_Player PlayerKnockHead;
    public MMF_Player BigMove;
    public void ThisPlayerMoveUp()
    {
        if (height == -5)
        {
            height += 3;
            BigMove.PlayFeedbacks();
            if (AnotherPlayer.height > -5)
            {
                AnotherPlayer.height -= 1;
                AnotherPlayerMoveDown.PlayFeedbacks();
            }
        }
        else
        {

            height += 1;
            if (AnotherPlayer.height > -5)
            {
                AnotherPlayer.height -= 1;
                AnotherPlayerMoveDown.PlayFeedbacks();
            }

            PlayerMoveUp.PlayFeedbacks();
        }
    }

    public void PlayerMoveDown()
    {
        height -= 1;
        starOnHead.PlayFeedbacks();
    }


    public void ThisPlayerKnockHead() 
    {
        PlayerKnockHead.PlayFeedbacks();
    }
}
