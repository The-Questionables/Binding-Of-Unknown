using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


    public class ChangeVolume : MonoBehaviour
    {

        [SerializeField] AudioMixer p_mixer;
        //[SerializeField] Slider s_master;
        [SerializeField] Slider s_music;
        [SerializeField] Slider s_effects;

        private void Awake()
        {
            float tmp;

         //   p_mixer.GetFloat("Master Volume", out tmp);
         //   s_master.value = Mathf.InverseLerp(-30, 20, tmp) * 10;

            p_mixer.GetFloat(SpaceShip_Const.Volume_Music, out tmp);
            s_music.value = Mathf.InverseLerp(-30, 20, tmp) * 10;

            p_mixer.GetFloat(SpaceShip_Const.Volume_Sfx, out tmp);
            s_effects.value = Mathf.InverseLerp(-30, 20, tmp) * 10;
        }
        /*
        public void ChangeMasterVolume(float value)
        {
            p_mixer.SetFloat("Master Volume", Mathf.Lerp(-30, 20, value / 10));
        }
        */
        public void ChangeMusicVolume(float value)
        {
            p_mixer.SetFloat(SpaceShip_Const.Volume_Music, Mathf.Lerp(-30, 20, value / 10));
        }

        public void ChangeEffectsVolume(float value)
        {
            p_mixer.SetFloat(SpaceShip_Const.Volume_Sfx, Mathf.Lerp(-30, 20, value / 10));
        }
    }
