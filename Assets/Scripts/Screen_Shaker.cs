using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Shaker : MonoBehaviour
{
    
        public IEnumerator Shake (float duration, float magnitude)
        {
            Vector3 originalPos = transform.localPosition;

            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-0.15f, 0.15f) * magnitude;
                float y = Random.Range(-0.15f, 0.15f) * magnitude;

                transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);

                elapsed += Time.deltaTime;

                yield return null;
            }

        transform.localPosition = new Vector3(originalPos.x, originalPos.y, originalPos.z);
        transform.localPosition = originalPos;

        }

}
