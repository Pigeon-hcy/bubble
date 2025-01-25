using System.Collections;
using MoreMountains.Feedbacks;
using MoreMountains.Feel;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMove : MonoBehaviour
{
    public enum PlayerType
    {
        Player1, 
        Player2
    };

    public PlayerType player;
    public PlayerHeight playerHeight;
    [Header("Common")]
    public Vector2 movement;
    public Rigidbody2D rb;
    public float movementMult;
    public GameManager gameManager;
    public bool canGoUp;

    [Header("Collision")]
    public PlayerMove anotherPlayer;
    public MMF_Player uprightCollision;
    public MMF_Player downrightCollision;
    public MMF_Player upleftCollision;
    public MMF_Player downleftCollision;

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        if (movement.x != 0)
        {
            rb.linearVelocity = new Vector2(movement.x * movementMult, 0);

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && gameManager.blockInput == false)
        {
            if (playerHeight.height < 5 && playerHeight.height >= -5)
            {
                if (!canGoUp)
                {
                    switch (player)
                    {
                        case PlayerType.Player1:
                            //playerHeight.ThisPlayerMoveUp();
                            StartCoroutine(StartKnockPlayer());
                            Debug.Log("P1");
                            break;
                        case PlayerType.Player2:
                            break;
                    }
                }
                else if (canGoUp)
                {
                    switch (player)
                    {
                        case PlayerType.Player1:
                            //playerHeight.ThisPlayerMoveUp();
                            StartCoroutine(StartMovePlayer());
                            Debug.Log("P1");
                            break;
                        case PlayerType.Player2:
                            break;
                    }
                }
            }
        }
        if (playerHeight.height < 5 && playerHeight.height >= -5)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && gameManager.blockInput == false)
            {
                if (!canGoUp)
                {
                    switch (player)
                    {
                        case PlayerType.Player2:
                            //playerHeight.ThisPlayerMoveUp();
                            StartCoroutine(StartKnockPlayer());
                            Debug.Log("P2");
                            break;
                        case PlayerType.Player1:
                            break;
                    }
                }
                else if (canGoUp)
                {
                    switch (player)
                    {
                        case PlayerType.Player2:
                            //playerHeight.ThisPlayerMoveUp();
                            StartCoroutine(StartMovePlayer());
                            Debug.Log("P2");
                            break;
                        case PlayerType.Player1:
                            break;
                    }
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (player)
            {
                case PlayerType.Player1:
                    int collisionResult = Random.Range(0, 2);
                    //Player 1 go up
                    if (collisionResult == 0)
                    {
                        //player 2 on the right
                        if (collision.transform.position.x > this.transform.position.x)
                        {
                            upleftCollision.PlayFeedbacks();
                            anotherPlayer.downrightCollision.PlayFeedbacks();
                        }
                        //player 2 on the left
                        else if (collision.transform.position.x < this.transform.position.x)
                        {
                            uprightCollision.PlayFeedbacks();
                            anotherPlayer.downleftCollision.PlayFeedbacks();
                        }
                    }
                    //player 1 go down
                    else
                    {
                        //player 2 on the right
                        if (collision.transform.position.x > this.transform.position.x)
                        {
                            downleftCollision.PlayFeedbacks();
                            anotherPlayer.uprightCollision.PlayFeedbacks();
                        }
                        //player 2 on the left
                        else if (collision.transform.position.x < this.transform.position.x)
                        {
                            downrightCollision.PlayFeedbacks();
                            anotherPlayer.upleftCollision.PlayFeedbacks();
                        }
                    }
                    break;
                case PlayerType.Player2:
                    //no need
                    break;
            }
        }
       
    }
    private IEnumerator StartMovePlayer()
    {
        playerHeight.ThisPlayerMoveUp();
        gameManager.blockInput = true;
        yield return new WaitForSeconds(0.5f);
        gameManager.blockInput = false;
    }


    private IEnumerator StartKnockPlayer()
    {
        playerHeight.ThisPlayerKnockHead();
        gameManager.blockInput = true;
        yield return new WaitForSeconds(0.5f);
        Vector3 currentPosition = transform.position;
        float roundedY = Mathf.Round(currentPosition.y * 2f) / 2f;
        this.transform.position = new Vector3(currentPosition.x, roundedY, currentPosition.z);
        gameManager.blockInput = false;
    }
}
