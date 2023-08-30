using UnityEngine;

namespace GridGeneratorFeaturesAnimation {

    [CreateAssetMenu(menuName = "Settings/Animation Settings For Grid Generator Features")]
    internal class AnimationSettingsForGridGeneratorFeatures : ScriptableObject {

        [Header("Settings For Drawing Coordinate System Animation")]
        [SerializeField] private GameObject[] goListForHorizontalAnim;
        internal GameObject[] GoListForHorizontalAnim {
            get => goListForHorizontalAnim;
            set => goListForHorizontalAnim = value;
        }
        
        [SerializeField] private GameObject[] goListForVerticalAnim;
        internal GameObject[] GoListForVerticalAnim {
            get => goListForVerticalAnim;
            set => goListForVerticalAnim = value;
        }

        [SerializeField] private float animDur = 2.5f;
        internal float AnimDur {
            get => animDur;
            set => animDur = value;
        }

        [SerializeField] private float targetYScaleForHorizontalAnim = 35.6f;
        internal float TargetYScaleForHorizontalAnim {
            get => targetYScaleForHorizontalAnim;
            set => targetYScaleForHorizontalAnim = value;
        }

        [SerializeField] private float targetYScaleForVerticalAnim = 20f;
        internal float TargetYScaleForVerticalAnim {
            get => targetYScaleForVerticalAnim;
            set => targetYScaleForVerticalAnim = value;
        }

        [SerializeField] private Color32 color32 = new Color32(77,77,77,255);
        internal Color32 Color32 {
            get => color32;
            set => color32 = value;
        }

        [Header("Settings For Changing Coordinate Animation")]
        [SerializeField] internal int howManyTimesRepeat = 3;
        internal int HowManyTimesRepeat {
            get => howManyTimesRepeat;
            set => howManyTimesRepeat = value;
        }

        [SerializeField] internal float animSpeed = 2f;
        internal float AnimSpeed {
            get => animSpeed;
            set => animSpeed = value;
        }

        [SerializeField] internal float amplitudeX = 3f;
        internal float AmplitudeX {
            get => amplitudeX;
            set => amplitudeX = value;
        }

        [SerializeField] internal float frequencyY = 2f;
        internal float FrequencyY {
            get => frequencyY;
            set => frequencyY = value;
        }

        [SerializeField] internal float amplitudeY = 1.5f;
        internal float AmplitudeY {
            get => amplitudeY;
            set => amplitudeY = value;
        }

        [Header("Settings For Changing Pixels Per Unit Animation")]
        [SerializeField] internal float ppuAnimDur = 2.5f;
        internal float PpuAnimDur {
            get => ppuAnimDur;
            set => ppuAnimDur = value;
        }

        [SerializeField] internal float howMuchPPUDecrease = 50f;
        internal float HowMuchPPUDecrease {
            get => howMuchPPUDecrease;
            set => howMuchPPUDecrease = value;
        }

        [SerializeField] internal float refPPU = 100f;
        internal float RefPPU {
            get => refPPU;
            set => refPPU = value;
        }

    }
}