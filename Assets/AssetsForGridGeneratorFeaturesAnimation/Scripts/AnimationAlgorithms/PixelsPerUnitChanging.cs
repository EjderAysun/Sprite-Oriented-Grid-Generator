using System.Collections;
using UnityEngine;
using TMPro;

namespace GridGeneratorFeaturesAnimation {
    internal class PixelsPerUnitChanging {

        internal IEnumerator PixelsPerUnitIncrease(GameObject targetObject, TMP_Text textForPPU, float time, float howMuchPPUIncrease, float refPPU) {
            float smoothnessValue = time/Time.fixedDeltaTime;
            float incrementValue = howMuchPPUIncrease/smoothnessValue;
            Vector3 firstScale = targetObject.transform.localScale;
            for(int i = 0; smoothnessValue>=0; i++, smoothnessValue--){
                Vector3 newScale = firstScale;
                newScale *= refPPU / (refPPU + incrementValue*i);
                targetObject.transform.localScale = newScale;
                textForPPU.text = "Pixels Per Unit: " + (refPPU + incrementValue*i);
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
            textForPPU.text = "";
        }

        internal IEnumerator PixelsPerUnitDecrease(GameObject targetObject, TMP_Text textForPPU, float time, float howMuchPPUDecrease, float refPPU) {
            float smoothnessValue = time/Time.fixedDeltaTime;
            float incrementValue = howMuchPPUDecrease/smoothnessValue;
            Vector3 firstScale = targetObject.transform.localScale;
            for(int i = 0; smoothnessValue>=0; i++, smoothnessValue--){
                Vector3 newScale = firstScale;
                newScale *= refPPU / (refPPU - incrementValue*i);
                targetObject.transform.localScale = newScale;
                textForPPU.text = "Pixels Per Unit: " + (refPPU - incrementValue*i);
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
            textForPPU.text = "";
        }

    }
}