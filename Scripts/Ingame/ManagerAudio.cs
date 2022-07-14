using UnityEngine;

namespace Ingame
{
    /// <summary>
    /// Manager Audio and Source 
    /// </summary>
    public class ManagerAudio : Singleton<ManagerAudio>
    {

        [Header("Audio")]
    
        [SerializeField] 
        private AudioSource shootAudio;
        [SerializeField] 
        private AudioSource boomAudio;
        [SerializeField] 
        private AudioSource rewindAudio;

        //shoot
        public void AudioShoot()
        {
            shootAudio.Play();
        }
        //boom 
        public void AudioBoom()
        {
            boomAudio.Play();
        }
        //Rewind
        public void AudioRewind()
        {
            rewindAudio.Play();
        }
    }
}
