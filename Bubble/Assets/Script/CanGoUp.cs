using UnityEngine;

public class CanGoUp : MonoBehaviour
{
    public PlayerMove PlayerMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            PlayerMove.canGoUp = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMove.canGoUp = true;
        }
    }
}
