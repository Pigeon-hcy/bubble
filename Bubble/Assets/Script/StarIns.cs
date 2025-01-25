using Unity.VisualScripting;
using UnityEngine;

public class StarIns : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = Random.Range(0.1f, 1f);
    }
}
