using UnityEngine;

namespace GridGeneratorFeaturesAnimation {
    internal class Scenario : MonoBehaviour {

        private DrawCoordinateSystem _drawCoordinateSystem;
        [SerializeField] private AnimationSettingsForGridGeneratorFeatures animationSettingsForGridGeneratorFeatures;
        // [SerializeField] private GameObject _targetObject;
        [SerializeField] private GameObject _lineHolder;
        private GameObject[] _goListForHorizontalAnim;
        private GameObject[] _goListForVerticalAnim;
        private float _animDur;
        private float _targetYScaleForHorizontalAnim;
        private float _targetYScaleForVerticalAnim;
        private Color32 _color32;
        
        private void Start() {

            _drawCoordinateSystem = new DrawCoordinateSystem();
            _goListForHorizontalAnim = animationSettingsForGridGeneratorFeatures.GoListForHorizontalAnim;
            _goListForVerticalAnim = animationSettingsForGridGeneratorFeatures.GoListForVerticalAnim;
            _animDur = animationSettingsForGridGeneratorFeatures.AnimDur;
            _targetYScaleForHorizontalAnim = animationSettingsForGridGeneratorFeatures.TargetYScaleForHorizontalAnim;
            _targetYScaleForVerticalAnim = animationSettingsForGridGeneratorFeatures.TargetYScaleForVerticalAnim;
            _color32 = animationSettingsForGridGeneratorFeatures.Color32;

            GameObject instantiatedPrefab;
            for(int i = 0; i < _goListForHorizontalAnim.Length; i++) {
                instantiatedPrefab = Instantiate(_goListForHorizontalAnim[i]);
                instantiatedPrefab.transform.parent = _lineHolder.transform;
                StartCoroutine(_drawCoordinateSystem.LineAnimationWithScale(instantiatedPrefab, _animDur, _targetYScaleForHorizontalAnim, _color32));
                // StartCoroutine(DrawCoordinateSystem.LineAnimationWithDrawLine(instantiatedPrefab.transform.position, endPoint, _time, waitingTimeAfterAnim, _color32));
            }
            for(int i = 0; i < _goListForVerticalAnim.Length; i++) {
                instantiatedPrefab = Instantiate(_goListForVerticalAnim[i]);
                instantiatedPrefab.transform.parent = _lineHolder.transform;
                StartCoroutine(_drawCoordinateSystem.LineAnimationWithScale(instantiatedPrefab, _animDur, _targetYScaleForVerticalAnim, _color32));
                // StartCoroutine(DrawCoordinateSystem.LineAnimationWithDrawLine(instantiatedPrefab.transform.position, endPoint, _time, waitingTimeAfterAnim, _color32));
            }
        }

    }
}