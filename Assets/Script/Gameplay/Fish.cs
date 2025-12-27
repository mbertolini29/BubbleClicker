using UnityEngine;

namespace BubbleClicker
{
    public class Fish : MonoBehaviour
    {
        [SerializeField] private FishSO data;
        [SerializeField] private bool spriteFacesLeftByDefault = true;

        private Vector2 dir;
        private Aquarium aquarium;        
        private Vector2 boundsX;
        private Vector2 boundsY;

        private Vector3 baseScale;

        public FishSO Data => data;

        public void Init(Aquarium owner)
        {
            aquarium = owner;

            boundsX = aquarium.GetBoundsWidth();
            boundsY = aquarium.GetBoundsHeight();

            //configurar la dirección inicial.
            baseScale = transform.localScale;

            //si queres que sea random, tenes que flipearlo tmb.
            bool movingLeft = Random.value > 0.5f;
            bool movingUp = Random.value > 0.5f; 

            dir = new Vector2(movingLeft ? -1 : 1, movingUp ? 1 : -1).normalized;

            // Setear orientación inicial correcta
            UpdateFacing();
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
            if (transform.position.x > boundsX.y || 
                transform.position.x <= boundsX.x)
            {
                dir.x = -dir.x;
                UpdateFacing();
            }

            if (transform.position.y > boundsY.y ||
                transform.position.y <= boundsY.x)
            {
                dir.y = -dir.y;
            }
        }

        private void UpdateFacing()
        {
            Vector3 scale = baseScale;

            bool movingLeft = dir.x < 0;

            // XOR lógico: si la dirección NO coincide con la orientación base → flip
            bool shouldFlip = movingLeft != spriteFacesLeftByDefault;

            scale.x = shouldFlip
                ? -Mathf.Abs(baseScale.x) 
                : Mathf.Abs(baseScale.x);


            transform.localScale = scale;
        }

    }
}
