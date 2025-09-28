using UnityEngine;

namespace BubbleClicker
{
    public class Fish : MonoBehaviour
    {
        [SerializeField] private FishSO data;
        
        private Vector2 dir;

        private Aquarium aquarium;        
        private Vector2 boundsX;
        private Vector2 boundsY;

        public FishSO Data => data;

        public void Init(Aquarium owner)
        {
            aquarium = owner;

            //encuentra el acuario:
            //aquarium = FindFirstObjectByType<Aquarium>();

            boundsX = aquarium.GetBoundsWidth();
            boundsY = aquarium.GetBoundsHeight();

            //configurar la dirección inicial.
            //si queres que sea random, tenes que flipearlo tmb.
            //bool movingLeft = Random.value > 0.5f; 
            bool movingLeft = true;
            bool movingUp = true;
            dir = new Vector2(movingLeft ? -1 : 1, movingUp ? 1 : -1).normalized;
        }

        private void Update()
        {
            if (aquarium == null) return;

            MoveFish();
        }

        private void MoveFish()
        {
            transform.Translate(dir * data.speed * Time.deltaTime);

            //horizontal
            if (transform.position.x > boundsX.y|| 
                transform.position.x <= boundsX.x)
            {
                dir.x = -dir.x;
                FlipHorizontal();
            }

            if (transform.position.y > boundsY.y|| 
                transform.position.y <= boundsY.x)
            {
                dir.y = -dir.y;
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
