using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;
    public float speed;
    public int current;
    public Transform start;
    // Update is called once per frame
    void FixedUpdate()
    {
        float nextY1 = background1.transform.position.y - speed;
        float nextY2 = background2.transform.position.y - speed;

        if (background1.transform.position.y <= -55)
        {
            nextY1 = 70f;
        }

        if (background2.transform.position.y <= -55)
        {
            nextY2 = 70f;
        }



        background1.transform.position = new Vector3(background1.transform.position.x, nextY1, 0);
        background2.transform.position = new Vector3(background2.transform.position.x, nextY2, 0);

        
    }
}
