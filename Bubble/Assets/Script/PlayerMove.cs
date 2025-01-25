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

    [Header("Fuel")]
    public int fuel;
    [Header("Score")]
    public int score;

    [Header("Dash")]
    public int DoubleClickWindowTimer;
    public int DoubleClickWindow;
    public string Last;
    public bool inDoubleClick;
    public MMF_Player P1RightDash;
    public MMF_Player P1LeftDash;
    public MMF_Player P2RightDash;
    public MMF_Player P2LeftDash;
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        if (inDoubleClick && DoubleClickWindow > 0)
        {
            DoubleClickWindow--;


        }
        if (inDoubleClick && DoubleClickWindow <= 0)
        {
            inDoubleClick = false;
            DoubleClickWindow = DoubleClickWindowTimer;
        }
        if (movement.x != 0)
        {
            rb.linearVelocity = new Vector2(movement.x * movementMult, 0);

        }
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.W) && gameManager.blockInput == false && fuel >= 50)
        {
            if (playerHeight.height < 5 && playerHeight.height >= -5)
            {
                fuel -= 50;
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

        if (Input.GetKeyDown(KeyCode.UpArrow) && gameManager.blockInput == false && fuel >= 50)
        {
            if (playerHeight.height < 5 && playerHeight.height >= -5)
            {
                fuel -= 50;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!inDoubleClick)
            {
                switch (player)
                {
                    
                    case PlayerType.Player1:
                        Last = "A";
                        inDoubleClick = true;
                        break;
                    case PlayerType.Player2:
                        break;
                }
            }
            else if (inDoubleClick && Last == "A" && fuel >= 25)
            {
                switch (player)
                {
                    case PlayerType.Player1:
                        fuel -= 25;
                        doubleClick("P1Left");
                        inDoubleClick = false;
                        DoubleClickWindow = DoubleClickWindowTimer;
                        Debug.Log("Triggered");
                        break;
                    case PlayerType.Player2:
                        break;
                }
            }
             if (inDoubleClick && Last == "D")
            {
                switch (player)
                {
                    case PlayerType.Player1:
                        Last = "A";
                        DoubleClickWindow = DoubleClickWindowTimer;
                        inDoubleClick = true;
                        break;
                    case PlayerType.Player2:
                        break;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!inDoubleClick)
            {
                switch (player)
                {

                    case PlayerType.Player1:
                        Last = "D";
                        inDoubleClick = true;
                        break;
                    case PlayerType.Player2:
                        break;
                }
            }
            else if (inDoubleClick && Last == "D" && fuel >= 25)
            {
                switch (player)
                {
                    case PlayerType.Player1:
                        fuel -= 25;
                        doubleClick("P1Right");
                        inDoubleClick = false;
                        DoubleClickWindow = DoubleClickWindowTimer;
                        Debug.Log("Triggered");
                        break;
                    case PlayerType.Player2:
                        break;
                }
            }
             if (inDoubleClick && Last == "A")
            {
                switch (player)
                {
                    case PlayerType.Player1:
                        Last = "D";
                        DoubleClickWindow = DoubleClickWindowTimer;
                        inDoubleClick = true;
                        break;
                    case PlayerType.Player2:
                        break;
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!inDoubleClick)
            {
                switch (player)
                {
                    case PlayerType.Player2:
                        Last = "L";
                        inDoubleClick = true;
                        break;
                }
            }
            else if (inDoubleClick && Last == "L" && fuel >= 25)
            {
                switch (player)
                {
                    case PlayerType.Player2:
                        fuel -= 25;
                        doubleClick("P2Left");
                        inDoubleClick = false;
                        Last = "";  // 重置 Last
                        DoubleClickWindow = DoubleClickWindowTimer;
                        Debug.Log("Triggered");
                        break;
                }
            }
            else if (inDoubleClick && Last == "R")
            {
                switch (player)
                {
                    case PlayerType.Player2:
                        Last = "L";  // 更新 Last
                        DoubleClickWindow = DoubleClickWindowTimer;
                        inDoubleClick = true;
                        break;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!inDoubleClick)
            {
                switch (player)
                {
                    case PlayerType.Player2:
                        Last = "R";
                        inDoubleClick = true;
                        break;
                }
            }
            else if (inDoubleClick && Last == "R" && fuel >= 25)
            {
                switch (player)
                {
                    case PlayerType.Player2:
                        fuel -= 25;
                        doubleClick("P2Right");
                        inDoubleClick = false;
                        Last = "";  // 重置 Last
                        DoubleClickWindow = DoubleClickWindowTimer;
                        Debug.Log("Triggered");
                        break;
                }
            }
            else if (inDoubleClick && Last == "L")
            {
                switch (player)
                {
                    case PlayerType.Player2:
                        Last = "R";  // 更新 Last
                        DoubleClickWindow = DoubleClickWindowTimer;
                        inDoubleClick = true;
                        break;
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

    private void doubleClick(string move)
    {
        if (move == "P1Right")
        {
            P1RightDash.PlayFeedbacks();
        }
        else if (move == "P1Left")
        {
            P1LeftDash.PlayFeedbacks();
        }
        else if (move == "P2Right")
        {
            P2RightDash.PlayFeedbacks();
            
        }
        else if (move == "P2Left")
        {
            P2LeftDash.PlayFeedbacks();
        }
    }


}
