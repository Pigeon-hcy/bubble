using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Star;
    [SerializeField] private GameObject Fuel;
    public float shootTimer;
    public float shootTime;
    public float starshootTimer;
    public float starshootTime;
    public float randomRad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootTimer = shootTime;
        starshootTimer = starshootTime;
    }


    private void FixedUpdate()
    {
        shootTimer--;
        if (shootTimer <= 0)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(randomRad, -randomRad), this.transform.position.y, 0);
            Instantiate(Coin, spawnPoint, Quaternion.identity);
            shootTimer = shootTime + Random.Range(-100, 100);
        }


        starshootTimer--;
        if (starshootTimer <= 0)
        {
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                Vector3 spawnPoint = new Vector3(Random.Range(randomRad, -randomRad), this.transform.position.y, 0);
                var j = Random.Range(0, 4);
                if (j <= 1)
                {
                    Instantiate(Fuel, spawnPoint, Quaternion.identity);
                }
                else
                {
                    Instantiate(Star, spawnPoint, Quaternion.identity);
                }

                starshootTimer = starshootTime + Random.Range(0, 300);
            }

        }
    }
}
