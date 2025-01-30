using UnityEngine;

public class Fish : MonoBehaviour
{
    [Header("Costo")]
    public int cost;

    [Header("movement")]
    public float speed = 1f;

    public float leftBound = -2f;
    public float rightBound = 2f;
    public float upperBound = 3f;
    public float lowerBound = -3f;

    private bool movingLeft = true;
    private bool movingUp = true;

    //
    private Vector2 moveDirection; 


    void Start()
    {
        moveDirection = new Vector2(movingLeft ? -1 : 1, movingUp ? 1 : -1).normalized;
    }

    private void Update()
    {
        MoveFish();
    }

    private void MoveFish()
    {
        //moveDirection = new Vector2(movingLeft ? -1 : 1,
        //                                     movingUp ? 1 : -1).normalized;

        //
        transform.Translate(moveDirection * speed * Time.deltaTime);

        //horizontal
        if(transform.position.x > rightBound || transform.position.x <= leftBound)
        {
            moveDirection.x = -moveDirection.x;
            FlipHorizontal();
        }

        if (transform.position.y > upperBound || transform.position.y <= lowerBound)
        {
            moveDirection.y = -moveDirection.y;
            //FlipVertical();
        }
    }

    private void FlipHorizontal()
    {
        //movingLeft = !movingLeft;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void FlipVertical()
    {
        //movingUp = !movingUp;
        Vector3 localScale = transform.localScale;
        localScale.y *= -1;
        transform.localScale = localScale;
    }
}
