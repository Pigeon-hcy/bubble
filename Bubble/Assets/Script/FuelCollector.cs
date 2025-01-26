using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using TMPro;
using UnityEngine;

public class FuelCollector : MonoBehaviour
{
    public PlayerMove playerMove;
    public TMP_Text test_Text;
    public MMF_Player onCollect;
    public MMProgressBar fuelBar;
    public MMF_Player onIce;
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
            if (playerMove.fuel < 1000)
            {
                playerMove.fuel += 1;
            }
            fuelBar.UpdateBar(playerMove.fuel, 0, 1000);
        }

        if (collision.gameObject.tag == "Ice")
        {
            Destroy(collision.gameObject);

            if (playerMove.fuel < 1000)
            {
                playerMove.fuel += 25;

            }
            onIce.PlayFeedbacks();
            fuelBar.UpdateBar(playerMove.fuel, 0, 1000);
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            playerMove.score += 1;
            onCollect.PlayFeedbacks();
        }
    }
}
