using System.Collections;
using TMPro;
using UnityEngine;

namespace GridGeneratorFeaturesAnimation {
    internal class Scenario : MonoBehaviour {
        
        [SerializeField] private GameObject _targetObject;
        [SerializeField] private TMP_Text _text;
        
        ///
        
        private CoordinateSystemDrawing _drawCoordinateSystem;
        [SerializeField] private AnimationSettingsForGridGeneratorFeatures animationSettingsForGridGeneratorFeatures;
        [SerializeField] private GameObject _lineHolder;
        private GameObject[] _goListForHorizontalAnim;
        private GameObject[] _goListForVerticalAnim;
        private float _animDurForDrawingCoordinateSystem;
        private float _targetYScaleForHorizontalAnim;
        private float _targetYScaleForVerticalAnim;
        private Color32 _color32;

        ///

        private CoordinateChanging _coordinateChanging;
        private int _howManyTimesRepeat;
        private float _animSpeed;
        private float _amplitudeX;
        private float _frequencyY;
        private float _amplitudeY;

        ///
        
        private PixelsPerUnitChanging _pixelsPerUnitChanging;
        private float _ppuAnimDur;
        private float _howMuchPPUDecrease;
        private float _refPPU;

        private IEnumerator Start() {

            _drawCoordinateSystem = new CoordinateSystemDrawing();
            _goListForHorizontalAnim = animationSettingsForGridGeneratorFeatures.GoListForHorizontalAnim;
            _goListForVerticalAnim = animationSettingsForGridGeneratorFeatures.GoListForVerticalAnim;
            _animDurForDrawingCoordinateSystem = animationSettingsForGridGeneratorFeatures.AnimDur;
            _targetYScaleForHorizontalAnim = animationSettingsForGridGeneratorFeatures.TargetYScaleForHorizontalAnim;
            _targetYScaleForVerticalAnim = animationSettingsForGridGeneratorFeatures.TargetYScaleForVerticalAnim;
            _color32 = animationSettingsForGridGeneratorFeatures.Color32;

            _coordinateChanging = new CoordinateChanging();
            _howManyTimesRepeat = animationSettingsForGridGeneratorFeatures.HowManyTimesRepeat;
            _animSpeed = animationSettingsForGridGeneratorFeatures.AnimSpeed;
            _amplitudeX = animationSettingsForGridGeneratorFeatures.AmplitudeX;
            _frequencyY = animationSettingsForGridGeneratorFeatures.FrequencyY;
            _amplitudeY = animationSettingsForGridGeneratorFeatures.AmplitudeY;

            _pixelsPerUnitChanging = new PixelsPerUnitChanging();
            _ppuAnimDur = animationSettingsForGridGeneratorFeatures.PpuAnimDur;
            _howMuchPPUDecrease = animationSettingsForGridGeneratorFeatures.HowMuchPPUDecrease;
            _refPPU = animationSettingsForGridGeneratorFeatures.RefPPU;

            GameObject instantiatedPrefab;

            for(int i = 0; i < _goListForHorizontalAnim.Length; i++) {
                instantiatedPrefab = Instantiate(_goListForHorizontalAnim[i]);
                instantiatedPrefab.transform.parent = _lineHolder.transform;
                StartCoroutine(_drawCoordinateSystem.LineAnimationWithScale(instantiatedPrefab, _animDurForDrawingCoordinateSystem, _targetYScaleForHorizontalAnim, _color32));
                // StartCoroutine(DrawCoordinateSystem.LineAnimationWithDrawLine(instantiatedPrefab.transform.position, endPoint, _time, waitingTimeAfterAnim, _color32));
            }
            for(int i = 0; i < _goListForVerticalAnim.Length-1; i++) {
                instantiatedPrefab = Instantiate(_goListForVerticalAnim[i]);
                instantiatedPrefab.transform.parent = _lineHolder.transform;
                StartCoroutine(_drawCoordinateSystem.LineAnimationWithScale(instantiatedPrefab, _animDurForDrawingCoordinateSystem, _targetYScaleForVerticalAnim, _color32));
                // StartCoroutine(DrawCoordinateSystem.LineAnimationWithDrawLine(instantiatedPrefab.transform.position, endPoint, _time, waitingTimeAfterAnim, _color32));
            }
            instantiatedPrefab = Instantiate(_goListForVerticalAnim[_goListForVerticalAnim.Length-1]);
            instantiatedPrefab.transform.parent = _lineHolder.transform;
            yield return StartCoroutine(_drawCoordinateSystem.LineAnimationWithScale(instantiatedPrefab, _animDurForDrawingCoordinateSystem, _targetYScaleForVerticalAnim, _color32));

            yield return StartCoroutine(_coordinateChanging.InfinitySignAnimation(_targetObject, _howManyTimesRepeat, _animSpeed, _amplitudeX, _frequencyY, _amplitudeY, _text));

            yield return StartCoroutine(_pixelsPerUnitChanging.PixelsPerUnitDecrease(_targetObject, _text, _ppuAnimDur/4f, _howMuchPPUDecrease, _refPPU));
            yield return StartCoroutine(_pixelsPerUnitChanging.PixelsPerUnitIncrease(_targetObject, _text, _ppuAnimDur/2f, _howMuchPPUDecrease*2f, _refPPU-_howMuchPPUDecrease));
            yield return StartCoroutine(_pixelsPerUnitChanging.PixelsPerUnitDecrease(_targetObject, _text, _ppuAnimDur/4f, _howMuchPPUDecrease, _howMuchPPUDecrease + _refPPU));
        }

    }
}