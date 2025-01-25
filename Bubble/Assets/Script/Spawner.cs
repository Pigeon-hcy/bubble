using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Coin;
    public float shootTimer;
    public float shootTime;
    public float randomRad;
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
            Vector3 spawnPoint = new Vector3(Random.Range(randomRad, -randomRad), this.transform.position.y, 0);
            Instantiate(Coin, spawnPoint, Quaternion.identity);
            shootTimer = shootTime;
        }
    }
}
