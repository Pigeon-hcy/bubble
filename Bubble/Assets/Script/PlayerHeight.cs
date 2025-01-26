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

    public void ThisPlayerMoveUp()
    {
        height += 1;
        AnotherPlayer.height -= 1;
        PlayerMoveUp.PlayFeedbacks();
        AnotherPlayerMoveDown.PlayFeedbacks();
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
