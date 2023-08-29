using System.Collections;
using UnityEngine;

namespace GridGeneratorFeaturesAnimation {
    internal class DrawCoordinateSystem {
        internal IEnumerator LineAnimationWithScale(GameObject go, float time, float targetXScale, float targetYScale, Color32 color32) {
            float smoothnessValue = time / Time.fixedDeltaTime;
            float incrementXValue = targetXScale / smoothnessValue;
            float incrementYValue = targetYScale / smoothnessValue;
            Vector3 incrementVector = new Vector3(incrementXValue, incrementYValue, 0f);
            go.GetComponent<SpriteRenderer>().color = color32;
            Transform tf = go.transform;
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