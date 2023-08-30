using UnityEngine;

public class SpriteOrientedGridGenerator : MonoBehaviour {

    // ref ==> reference
    // pref ==> prefab
    // num ==> number
    // vert ==> vertical
    // hor ==> horizontal
    // tex ==> texture
    // coord ==> coordinate
    // calc ==> calculate

    [SerializeField] private SpriteBasedGridGeneratorSettings spriteBasedGridGeneratorSettings;

    [Header("Game Objects")]
    [SerializeField] private GameObject _refSpriteHolders;
    [SerializeField] private GameObject _gridPref;
    
    // ---------------------------------------------

    private int _numOfVertGrids, _numOfHorGrids;
    private float _horSpaceUnit, _vertSpaceUnit;
    private float _upperFrameThickness, _lowerFrameThickness, _leftFrameThickness, _rightFrameThickness;

    // ---------------------------------------------

    private float _canvasWidth, _canvasHeight, _canvasPixelsPerUnit, _canvasScaleX, _canvasScaleY;
    private Vector3 _canvasCoord;

    private void Start() {

        _numOfVertGrids = spriteBasedGridGeneratorSettings.NumOfVertGrids;
        _numOfHorGrids = spriteBasedGridGeneratorSettings.NumOfHorGrids;
        _horSpaceUnit = spriteBasedGridGeneratorSettings.HorSpaceUnit;
        _vertSpaceUnit = spriteBasedGridGeneratorSettings.VertSpaceUnit;
        _upperFrameThickness = spriteBasedGridGeneratorSettings.UpperFrameThickness;
        _lowerFrameThickness = spriteBasedGridGeneratorSettings.LowerFrameThickness;
        _leftFrameThickness = spriteBasedGridGeneratorSettings.LeftFrameThickness;
        _rightFrameThickness = spriteBasedGridGeneratorSettings.RightFrameThickness;
        
        Sprite canvasSprite = _refSpriteHolders.GetComponent<SpriteRenderer>().sprite;
        Texture canvasTex = canvasSprite.texture;
        Vector3 canvasScale = _refSpriteHolders.transform.localScale;

        _canvasCoord = _refSpriteHolders.transform.position;
        _canvasWidth = canvasTex.width;
        _canvasHeight = canvasTex.height;
        _canvasPixelsPerUnit = canvasSprite.pixelsPerUnit;

        _canvasScaleX = canvasScale.x;
        if(_canvasScaleX == 0) _canvasScaleX = 1;

        _canvasScaleY = canvasScale.y;
        if(_canvasScaleY == 0) _canvasScaleY = 1;

        if(_numOfVertGrids < 0) _numOfVertGrids = Mathf.Abs(_numOfVertGrids);
        if(_numOfHorGrids < 0) _numOfHorGrids = Mathf.Abs(_numOfHorGrids);

        if(_upperFrameThickness < 0 || _upperFrameThickness * _canvasPixelsPerUnit >= _canvasHeight) _upperFrameThickness = 0;
        if(_lowerFrameThickness < 0 || _lowerFrameThickness * _canvasPixelsPerUnit >= _canvasHeight) _lowerFrameThickness = 0;
        if((_upperFrameThickness + _lowerFrameThickness) * _canvasPixelsPerUnit >= _canvasHeight) {
            _upperFrameThickness = 0;
            _lowerFrameThickness = 0;
        }

        if(_leftFrameThickness < 0 || _leftFrameThickness * _canvasPixelsPerUnit >= _canvasWidth) _leftFrameThickness = 0;
        if(_rightFrameThickness < 0 || _rightFrameThickness * _canvasPixelsPerUnit >= _canvasWidth) _rightFrameThickness = 0;
        if((_leftFrameThickness + _rightFrameThickness) * _canvasPixelsPerUnit >= _canvasWidth) {
            _leftFrameThickness = 0;
            _rightFrameThickness = 0;
        }

        CreateGrid();
    }

    private void CreateGrid() {

        Vector3 centerOfGrid = new (_canvasCoord.x - ((_rightFrameThickness - _leftFrameThickness) / 2f), _canvasCoord.y - ((_upperFrameThickness - _lowerFrameThickness) / 2f), 0);

        float widthOfGridTable = _canvasWidth * Mathf.Abs(_canvasScaleX) - (_leftFrameThickness + _rightFrameThickness) * _canvasPixelsPerUnit;
        float heightOfGridTable = _canvasHeight * Mathf.Abs(_canvasScaleY) - (_upperFrameThickness + _lowerFrameThickness) * _canvasPixelsPerUnit;

        if(_horSpaceUnit < 0 || _horSpaceUnit * _canvasPixelsPerUnit * (_numOfHorGrids - 1f) >= widthOfGridTable) _horSpaceUnit = 0;
        if(_vertSpaceUnit < 0 || _vertSpaceUnit * _canvasPixelsPerUnit * (_numOfVertGrids - 1f) >= heightOfGridTable) _vertSpaceUnit = 0;

        float consPosX = (widthOfGridTable / _canvasPixelsPerUnit - (_numOfHorGrids - 1f) * _horSpaceUnit) / 2f;
        float consPosY = (heightOfGridTable / _canvasPixelsPerUnit - (_numOfVertGrids - 1f) * _vertSpaceUnit) / 2f;

        float consGridScX = ((widthOfGridTable / _canvasPixelsPerUnit) - (_numOfHorGrids - 1f) * _horSpaceUnit) / _numOfHorGrids;
        float consGridScY = ((heightOfGridTable / _canvasPixelsPerUnit) - (_numOfVertGrids - 1f) * _vertSpaceUnit) / _numOfVertGrids;

        for (int i = 0; i < _numOfVertGrids; i++) {
            
            float posY;
            posY = centerOfGrid.y + consPosY * ((_numOfVertGrids - 1f - i * 2f) / _numOfVertGrids) + ((_numOfVertGrids - 1f) / 2f - i) * _vertSpaceUnit;

            for (int j = 0; j < _numOfHorGrids; j++) {

                float posX;
                posX = centerOfGrid.x - consPosX * ((_numOfHorGrids - 1f - j * 2f) / _numOfHorGrids) - ((_numOfHorGrids - 1f) / 2f - j) * _horSpaceUnit;

                // take it as a degree
                Vector3 vector = RotatePointAroundAnotherPoint(new Vector3(posX, posY, 0f), transform.position, transform.eulerAngles.z);

                GameObject grid = Instantiate(_gridPref) as GameObject;
                grid.gameObject.transform.localScale = new Vector2(consGridScX, consGridScY);
                grid.name = "index" + (i * _numOfVertGrids + j);
                grid.transform.position = vector;
                grid.transform.rotation = transform.rotation;
                grid.transform.parent = transform;
            }
        }

    }

    private Vector3 RotatePointAroundAnotherPoint(Vector3 originalPoint, Vector3 centerOfCircle, float clockwiseRotationAngle) {
        // cw ==> clockwise
        float x1 = originalPoint.x - centerOfCircle.x;
        float y1 = originalPoint.y - centerOfCircle.y;
        // radians must be used in this formula
        float cwDeg2Rad = clockwiseRotationAngle * Mathf.Deg2Rad;
        float x2 = x1 * Mathf.Cos(cwDeg2Rad) - y1 * Mathf.Sin(cwDeg2Rad);
        float y2 = x1 * Mathf.Sin(cwDeg2Rad) + y1 * Mathf.Cos(cwDeg2Rad);
        float m = x2 + centerOfCircle.x;
        float n = y2 + centerOfCircle.y;
        return new Vector3(m, n, 0);
    }
    
}