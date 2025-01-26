using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class FuelCollector : MonoBehaviour
{
    public PlayerMove playerMove;
    public TMP_Text test_Text;
    public MMF_Player onCollect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        test_Text.text = playerMove.fuel.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fuel")
        {
            Destroy(collision.gameObject);
            playerMove.fuel += 1;
        }

        if (collision.gameObject.tag == "Ice")
        {
            Destroy(collision.gameObject);
            playerMove.fuel += 25;
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            playerMove.score += 1;
            onCollect.PlayFeedbacks();
        }
    }
}
