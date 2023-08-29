using UnityEngine;

namespace GridGeneratorFeaturesAnimation {
    internal class Scenario : MonoBehaviour {
        private DrawCoordinateSystem _drawCoordinateSystem;
        [SerializeField] private AnimationSettingsForGridGeneratorFeatures animationSettingsForGridGeneratorFeatures;
        [SerializeField] private GameObject _lineHolder;
        private GameObject[] _horizontalGoList;
        private GameObject[] _verticalGoList;
        private float _time;
        private float _targetXScale;
        private float _targetYScale;
        private Color32 _color32;
        private void Start() {

            _drawCoordinateSystem = new DrawCoordinateSystem();
            _horizontalGoList = animationSettingsForGridGeneratorFeatures.HorizontalGoList;
            _verticalGoList = animationSettingsForGridGeneratorFeatures.VerticalGoList;
            _time = animationSettingsForGridGeneratorFeatures.Time;
            _targetXScale = animationSettingsForGridGeneratorFeatures.TargetXScale;
            _targetYScale = animationSettingsForGridGeneratorFeatures.TargetYScale;
            _color32 = animationSettingsForGridGeneratorFeatures.Color32;

            GameObject instantiatedPrefab;
            for(int i = 0; i < _horizontalGoList.Length; i++) {
                instantiatedPrefab = Instantiate(_horizontalGoList[i]);
                instantiatedPrefab.transform.parent = _lineHolder.transform;
                StartCoroutine(_drawCoordinateSystem.LineAnimationWithScale(instantiatedPrefab, _time, _targetXScale, 0f, _color32));
                // StartCoroutine(DrawCoordinateSystem.LineAnimationWithDrawLine(instantiatedPrefab.transform.position, endPoint, _time, waitingTimeAfterAnim, _color32));
            }
            for(int i = 0; i < _verticalGoList.Length; i++) {
                instantiatedPrefab = Instantiate(_verticalGoList[i]);
                instantiatedPrefab.transform.parent = _lineHolder.transform;
                StartCoroutine(_drawCoordinateSystem.LineAnimationWithScale(instantiatedPrefab, _time, 0f, _targetYScale, _color32));
                // StartCoroutine(DrawCoordinateSystem.LineAnimationWithDrawLine(instantiatedPrefab.transform.position, endPoint, _time, waitingTimeAfterAnim, _color32));
            }
        }
        
    }
}