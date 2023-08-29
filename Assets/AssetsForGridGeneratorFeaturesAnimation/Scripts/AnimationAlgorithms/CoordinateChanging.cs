using System.Collections;
using UnityEngine;
using TMPro;

namespace GridGeneratorFeaturesAnimation {
    internal class CoordinateChanging {
        
        internal IEnumerator InfinitySignAnimation(GameObject targetObject, int howManyTimesRepeat, float animSpeed, float amplitudeX, float frequencyY, float amplitudeY, TMP_Text textForCoordinates) {
            int sign = 0;
            float elapsedTime = 0;
            bool lastSign = false;  // false = - / true = +
            if(animSpeed < 0) lastSign = true;
            else if (animSpeed > 0) lastSign = false;
            while(sign <= howManyTimesRepeat * 2) {
                elapsedTime += Time.fixedDeltaTime;
                float x = Mathf.Sin(elapsedTime * animSpeed) * amplitudeX;
                float y = Mathf.Sin(elapsedTime * animSpeed * frequencyY) * amplitudeY;
                Vector3 vector = new Vector3(x, y, 0f);
                targetObject.transform.position = vector;
                textForCoordinates.text = vector.ToString();
                yield return new WaitForFixedUpdate();
                if (targetObject.transform.position.x > 0 && lastSign == false) {
                    lastSign = true;
                    sign++;
                } else if (targetObject.transform.position.x < 0 && lastSign == true) {
                    lastSign = false;
                    sign++;
                }
            }
            // targetObject.transform.position = Vector3.zero;
            textForCoordinates.text = targetObject.transform.position.ToString();
        }

        internal IEnumerator SinusAnimation(GameObject targetObject, float animDur, float frequency, float amplitude, float animSpeed) {
            float smoothnessValue = animDur / Time.fixedDeltaTime;
            float elapsedTime = 0;
            for(;smoothnessValue>=0; smoothnessValue--) {
                elapsedTime += Time.fixedDeltaTime;
                float sinValue = Mathf.Sin(elapsedTime * frequency * animSpeed) * amplitude;
                targetObject.transform.position = new Vector3(targetObject.transform.position.x + Time.fixedDeltaTime * frequency * animSpeed, sinValue, 0f);
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
        }

        internal IEnumerator CosxPlusSinxOver5Animation(GameObject targetObject, float animDur, float frequency, float amplitude, float animSpeed) {
            float smoothnessValue = animDur / Time.fixedDeltaTime;
            float elapsedTime = 0;
            for(;smoothnessValue>=0; smoothnessValue--) {
                elapsedTime += Time.fixedDeltaTime;
                float p = Mathf.Sin(elapsedTime * frequency * animSpeed);
                float value = (Mathf.Cos(elapsedTime * frequency * animSpeed) + Mathf.Pow(p, 5f)) * amplitude;
                targetObject.transform.position = new Vector3(targetObject.transform.position.x + Time.fixedDeltaTime * frequency * animSpeed, value, 0f);
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
        }
        
    }
}