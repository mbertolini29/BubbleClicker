using UnityEngine;

namespace BubbleClicker
{
    public class Fish : MonoBehaviour
    {
        private FishSO fishData;
        private Vector2 moveDirection;
        private Aquarium aquarium;
        private Vector2 boundsX;
        private Vector2 boundsY;

        public void Initialize(FishSO data)
        {
            fishData = data;

            //encuentra el acuario:
            aquarium = FindFirstObjectByType<Aquarium>();
            boundsX = aquarium.GetBoundsWidth();
            boundsY = aquarium.GetBoundsHeight();

            //configurar la dirección inicial.
            //si queres que sea random, tenes que flipearlo tmb.
            //bool movingLeft = Random.value > 0.5f; 
            bool movingLeft = true;
            bool movingUp = true;
            moveDirection = new Vector2(movingLeft ? -1 : 1, movingUp ? 1 : -1).normalized;
        }

        private void Update()
        {
            MoveFish();
        }

        private void MoveFish()
        {
            transform.Translate(moveDirection * fishData.speed * Time.deltaTime);

            //horizontal
            if (transform.position.x > boundsX.y|| 
                transform.position.x <= boundsX.x)
            {
                moveDirection.x = -moveDirection.x;
                FlipHorizontal();
            }

            if (transform.position.y > boundsY.y|| 
                transform.position.y <= boundsY.x)
            {
                moveDirection.y = -moveDirection.y;
            }
        }

        private void FlipHorizontal()
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
