using System.Collections;
using UnityEngine;

namespace GridGeneratorFeaturesAnimation {
    internal class CoordinateSystemDrawing {

        // set the scale of all objects to increase on the y-axis
        internal IEnumerator LineAnimationWithScale(GameObject goToBeRescaled, float animDur, float targetYScale, Color32 color32) {
            float smoothnessValue = animDur / Time.fixedDeltaTime;
            float incrementYValue = targetYScale / smoothnessValue;
            Vector3 incrementVector = new Vector3(0f, incrementYValue, 0f);
            goToBeRescaled.GetComponent<SpriteRenderer>().color = color32;
            Transform tf = goToBeRescaled.transform;
            for(;smoothnessValue>=0; smoothnessValue--){
                tf.localScale += incrementVector;
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
        }

        internal IEnumerator LineAnimationWithDrawLine(Vector3 startPoint, Vector3 endPoint, float time, float waitingTimeAfterAnim, Color32 color32) {
            float smoothnessValue = time / Time.fixedDeltaTime;
            Vector3 incrementVector = (endPoint - startPoint) / smoothnessValue;
            Vector3 targetPoint = startPoint;
            for(;smoothnessValue>=0; smoothnessValue--){
                targetPoint += incrementVector;
                Debug.DrawLine(startPoint, targetPoint, color32, Time.fixedDeltaTime);
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
            Debug.DrawLine(startPoint, targetPoint, color32, waitingTimeAfterAnim);
        }

    }
}