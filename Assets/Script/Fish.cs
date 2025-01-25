using UnityEngine;

public class Fish : MonoBehaviour
{
    [Header("Costo")]
    public int cost;

    [Header("movement")]
    public float speed = 1f;
    public float leftBound = -2f;
    public float rightBound = 2f;

    private bool movingLeft = true;

    void Start()
    {
        
    }

    private void Update()
    {
        MoveFish();
    }

    private void MoveFish()
    {
        //
        if(movingLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if( transform.position.x >= rightBound)
        {
            Flip();
        }
        else if (transform.position.x <= leftBound)
        {
            Flip();
        }
    }

    private void Flip()
    {
        movingLeft = !movingLeft;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
