using UnityEngine;

namespace BubbleClicker
{
    public class Producer : MonoBehaviour
    {
        public ProducerSO data;

        private float productionRate;
        private int quantity; 

        private float elapsedTime; //tiempo acumulado.

        void Start()
        {
            productionRate = data.baseProduction;
        }

        void Update()
        {
            //elapsedTime += Time.deltaTime;
            //if(elapsedTime >= 1f)
            //{
            //    ProduceBubbles();
            //    elapsedTime = 0f;
            //}
        }

        public void ProduceBubbles()
        {
            float totalProduction = productionRate * quantity;
            //EconomyManager.Instance.AddBubbles(totalProduction);
        }

        //public void BuyProducer()
        //{
        //    if(EconomyManager.Instance.SpendBubbles(data.cost))
        //    {
        //        quantity++;
        //        data.cost *= data.costMultiplier;
        //        //UIManager.Instance.UpdateProducerUI(this);
        //    }
        //}
    }
}
