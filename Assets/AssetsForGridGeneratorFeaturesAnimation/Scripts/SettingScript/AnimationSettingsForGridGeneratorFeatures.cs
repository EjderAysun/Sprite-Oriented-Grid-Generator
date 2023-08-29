using UnityEngine;

namespace GridGeneratorFeaturesAnimation {
    [CreateAssetMenu(menuName = "Settings/Animation Settings For Grid Generator Features")]
    internal class AnimationSettingsForGridGeneratorFeatures : ScriptableObject {
        [Header("Settings For Drawing Coordinate System")]
        [SerializeField] private GameObject[] horizontalGoList;
        internal GameObject[] HorizontalGoList {
            get => horizontalGoList;
            set => horizontalGoList = value;
        }
        [SerializeField] private GameObject[] verticalGoList;
        internal GameObject[] VerticalGoList {
            get => verticalGoList;
            set => verticalGoList = value;
        }
        [SerializeField] private float time = 2.5f;
        internal float Time {
            get => time;
            set => time = value;
        }
        [SerializeField] private float targetXScale = 35.6f;
        internal float TargetXScale {
            get => targetXScale;
            set => targetXScale = value;
        }
        [SerializeField] private float targetYScale = 20f;
        internal float TargetYScale {
            get => targetYScale;
            set => targetYScale = value;
        }
        [SerializeField] private Color32 color32 = new Color32(77,77,77,255);
        internal Color32 Color32 {
            get => color32;
            set => color32 = value;
        }
    }
    
}