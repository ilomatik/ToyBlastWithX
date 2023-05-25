using UnityEngine;

namespace RunnerGame.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        public void PlayAudio(float perfectSeries)
        {
            audioSource.pitch = 1f + perfectSeries;
            audioSource.Play();
        }
    }
}