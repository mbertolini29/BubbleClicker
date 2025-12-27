using UnityEngine;

namespace BubbleClicker
{
    public class ClickManager : MonoBehaviour
    {
        [SerializeField] private ClickConfigSO clickConfig;
        [SerializeField] private EconomyManager economy;

        //[SerializeField] private AudioManager audioManager;

        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioClip[] clicksSound;

        private void Awake()
        {
            //economyManager = FindFirstObjectByType<EconomyManager>();
        }

        private void OnMouseDown()
        {
            if (economy != null && clickConfig != null)
            {
                economy.AddBubbles(clickConfig.bubblesPerClick);

                PlayRandomSFX();
            }

        }

        public void PlayRandomSFX()
        {
            if (clicksSound == null || clicksSound.Length == 0) return;

            int index = Random.Range(0, clicksSound.Length);
            sfxSource.PlayOneShot(clicksSound[index]);          
        }      

    }
}
