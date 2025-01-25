using UnityEngine;

public class FuelShooter1 : MonoBehaviour
{
    [SerializeField] private GameObject fuel;
    public float shootTimer;
    public float shootTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootTimer = shootTime;
    }


    private void FixedUpdate()
    {
        shootTimer--;
        if (shootTimer <= 0)
        {
            Instantiate(fuel, this.gameObject.transform.position, Quaternion.identity);
            shootTimer = shootTime;
        }
    }
    
}
