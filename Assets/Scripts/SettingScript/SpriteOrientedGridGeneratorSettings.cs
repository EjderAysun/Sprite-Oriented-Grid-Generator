using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Sprite Based Grid Generator Settings")]
public class SpriteOrientedGridGeneratorSettings : ScriptableObject {

    [Header("Grid Settings")]
    [SerializeField] private int numOfVertGrids = 5;
    internal int NumOfVertGrids {
        get => numOfVertGrids;
        set => numOfVertGrids = value;
    }

    [SerializeField] private int numOfHorGrids = 5;
    internal int NumOfHorGrids {
        get => numOfHorGrids;
        set => numOfHorGrids = value;
    }

    [Header("How many coordinate units are between horizontal grids?")]
    [SerializeField] private float horSpaceUnit = 0.2f;
    internal float HorSpaceUnit {
        get => horSpaceUnit;
        set => horSpaceUnit = value;
    }

    [Header("How many coordinate units are between vertical grids?")]
    [SerializeField] private float vertSpaceUnit = 0.2f;
    internal float VertSpaceUnit {
        get => vertSpaceUnit;
        set => vertSpaceUnit = value;
    }

    // ---------------------------------------------

    [Header("How many coordinate units is the upper frame thickness?")]
    [SerializeField] private float upperFrameThickness = 0.4f;
    internal float UpperFrameThickness {
        get => upperFrameThickness;
        set => upperFrameThickness = value;
    }


    [Header("How many coordinate units is the lower frame thickness?")]
    [SerializeField] private float lowerFrameThickness = 0.4f;
    internal float LowerFrameThickness {
        get => lowerFrameThickness;
        set => lowerFrameThickness = value;
    }

    [Header("How many coordinate units is the left frame thickness?")]
    [SerializeField] private float leftFrameThickness = 0.5f;
    internal float LeftFrameThickness {
        get => leftFrameThickness;
        set => leftFrameThickness = value;
    }

    [Header("How many coordinate units is the right frame thickness?")]
    [SerializeField] private float rightFrameThickness = 0.5f;
    internal float RightFrameThickness {
        get => rightFrameThickness;
        set => rightFrameThickness = value;
    }

}