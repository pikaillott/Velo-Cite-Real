using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Tiles : MonoBehaviour
{

    [SerializeField] private bool _up = false;
    [SerializeField] private bool _upConnected = false;
    [SerializeField] private bool _upEx = false;
    [SerializeField] private bool _down = false;
    [SerializeField] private bool _downConnected = false;
    [SerializeField] private bool _downEx = false;
    [SerializeField] private bool _left = false;
    [SerializeField] private bool _leftConnected = false;
    [SerializeField] private bool _leftEx = false;
    [SerializeField] private bool _right = false;
    [SerializeField] private bool _rightConnected = false;
    [SerializeField] private bool _rightEx = false;
    [SerializeField] private bool _isAlreadySet  = false;
    [SerializeField] private bool _isMonument  = false;
    [SerializeField] private bool _isFinish  = false;
    
    [SerializeField] private Transform _upTransform;
    [SerializeField] private Transform _downTransform;
    [SerializeField] private Transform _leftTransform;
    [SerializeField] private Transform _rightTransform;
    [SerializeField] private Transform _centerTransform;

    [SerializeField] private TileManager _tileManager;
    [SerializeField] private Vector2 _position;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Color _baseColor = Color.blue; 
    [SerializeField] private Color _previousColor = Color.red; //previous
    [SerializeField] private Color _alreadyColor = Color.green;//already
    [SerializeField] private Sprite _spriteBase;
    [SerializeField] private Sprite _spritePrevuiys;
    [SerializeField] private Sprite _spriteAlready;

    public Vector2 Position { get => _position; set => _position = value; }
    public bool DownConnected { get => _downConnected; set => _downConnected = value; }
    public bool UpConnected { get => _upConnected; set => _upConnected = value; }
    public bool LeftConnected { get => _leftConnected; set => _leftConnected = value; }
    public bool RightConnected { get => _rightConnected; set => _rightConnected = value; }
    public bool IsMonument { get => _isMonument; set => _isMonument = value; }
    public bool Up { get => _up; set => _up = value; }
    public bool Down { get => _down; set => _down = value; }
    public bool Left { get => _left; set => _left = value; }
    public bool Right { get => _right; set => _right = value; }
    


    //private bool up, down, left, right = false;

    private void Start()
    {
        _tileManager = FindObjectOfType<TileManager>();
        this.GetComponent<SpriteRenderer>().color = _baseColor;
        //this.GetComponent<SpriteRenderer>().sprite = _spriteBase;
        _lineRenderer.positionCount = 0;

    }
    #region Function TILE ONMOUSE OVER
    private void OnMouseOver()  
    {
        if (Input.GetMouseButtonDown(0) && _tileManager.NewTilesUI != null && !_isAlreadySet) //to do : "vérifier si elle peut se connecter a la prochaine tile + si elles sont bien à côté".
        {
            bool isPreviousTileRight = this._position.x == _tileManager.PreviousTiles.Position.x + 1 &&
                                       this._position.y == _tileManager.PreviousTiles.Position.y;
            
            bool isPreviousTileLeft = this._position.x == _tileManager.PreviousTiles.Position.x - 1 &&
                                      this._position.y == _tileManager.PreviousTiles.Position.y;
            
            bool isPreviousTileUp = this._position.y == _tileManager.PreviousTiles.Position.y + 1 &&
                                    this._position.x == _tileManager.PreviousTiles.Position.x;
            
            bool isPreviousTileDown = this._position.y == _tileManager.PreviousTiles.Position.y - 1 &&
                                      this._position.x == _tileManager.PreviousTiles.Position.x;
            
            if ( isPreviousTileRight || isPreviousTileLeft || isPreviousTileUp || isPreviousTileDown) //take pos x, check if pos x is +1 in x, & if pos.y is = to this tile.
            {
                ChangeTile();
            } 
        }
    }
    #endregion

    private void GetDirectionConnected()
    {
        /*if (_tileManager.PreviousTiles.IsMonument)
        {
            print(this._position.x);
            print(_tileManager.PreviousTiles.Position.x + 1);
            print(_tileManager.NewTilesUI.Left);
            if (this._position.x == _tileManager.PreviousTiles.Position.x - 1 && _tileManager.NewTilesUI.Left)
            {
                this._leftConnected = true;
            }
            else if (this._position.x == _tileManager.PreviousTiles.Position.x + 1 && _tileManager.NewTilesUI.Right)
            {
                this._rightConnected = true;
            }
            else if (this._position.y == _tileManager.PreviousTiles.Position.y - 1 && _tileManager.NewTilesUI.Down)
            {
                this._downConnected = true;
            }
            else if (this._position.y == _tileManager.PreviousTiles.Position.y + 1 && _tileManager.NewTilesUI.Up)
            {
                this._upConnected = true;
            }
            
        }
        else*/
        {
            if(_tileManager.NewTilesUI.Up && _tileManager.PreviousTiles._down)
                this._upConnected = true;
            if(_tileManager.NewTilesUI.Down && _tileManager.PreviousTiles._up)
                this._downConnected = true;
            if(_tileManager.NewTilesUI.Left && _tileManager.PreviousTiles._right)
                this._leftConnected = true;
            if(_tileManager.NewTilesUI.Right && _tileManager.PreviousTiles._left)
                this._rightConnected = true;
        }
        
    }
    private void ChangeTile() //change UI Tile to Map tile
    {
        bool isUpCheck = (_tileManager.NewTilesUI.Up && _tileManager.PreviousTiles._down &&
                          !_tileManager.PreviousTiles.DownConnected &&
                          this._position.y == _tileManager.PreviousTiles.Position.y - 1);
        
        bool isDownCheck = (_tileManager.NewTilesUI.Down && _tileManager.PreviousTiles._up &&
                            !_tileManager.PreviousTiles.UpConnected &&
                            this._position.y == _tileManager.PreviousTiles.Position.y + 1);
        
        bool isLeftCheck = ( _tileManager.NewTilesUI.Left && _tileManager.PreviousTiles._right && 
                             !_tileManager.PreviousTiles.RightConnected && 
                             this._position.x == _tileManager.PreviousTiles.Position.x - 1);
        
        bool isRightCheck = (_tileManager.NewTilesUI.Right && _tileManager.PreviousTiles._left && 
                             !_tileManager.PreviousTiles.LeftConnected && 
                             this._position.x == _tileManager.PreviousTiles.Position.x + 1);
        
        if ( isUpCheck || isDownCheck || isLeftCheck || isRightCheck)
        {
            
            CheckExtremTiles();
            if(_tileManager.NewTilesUI.Up && _upEx || _tileManager.NewTilesUI.Down && _downEx || _tileManager.NewTilesUI.Left && _leftEx || _tileManager.NewTilesUI.Right && _rightEx)
            {
                Debug.Log("Tile is extrem");
                return;
            }
            GetDirectionConnected();
            print("Change Tile");
            this._up = _tileManager.NewTilesUI.Up;
            this._down = _tileManager.NewTilesUI.Down;
            this._left = _tileManager.NewTilesUI.Left;
            this._right = _tileManager.NewTilesUI.Right;
            _tileManager.PreviousTiles.GetComponent<SpriteRenderer>().color = _alreadyColor;
            _tileManager.PreviousTiles = this;
            this.GetComponent<SpriteRenderer>().color = _previousColor;
            _isAlreadySet = true;
            UpdateLineRenderer();
        }

    }

    #region Function LINE RENDERER CONTROLLER

    private void UpdateLineRenderer() //update line renderer 
    {
        _lineRenderer.positionCount = 3;
        _lineRenderer.SetPosition(1, _centerTransform.position);
        //line renderer will always go through center
        
        //check what direction is taken for tile

        if (_up)
        {
            _lineRenderer.SetPosition(0, _upTransform.position);
            if (_down) _lineRenderer.SetPosition(2, _downTransform.position);
            else if (_left) _lineRenderer.SetPosition(2, _leftTransform.position);
            else if (_right) _lineRenderer.SetPosition(2, _rightTransform.position);
            
        }
        

        else if (_down)
        {
            _lineRenderer.SetPosition(0, _downTransform.position);
            if (_up) _lineRenderer.SetPosition(2,_upTransform.position);
            else if (_left) _lineRenderer.SetPosition(2, _leftTransform.position);
            else if (_right) _lineRenderer.SetPosition(2, _rightTransform.position);
        }

        else if (_left)
        {
            _lineRenderer.SetPosition(0, _leftTransform.position);
            if (_up) _lineRenderer.SetPosition(2, _upTransform.position);
            else if (_down) _lineRenderer.SetPosition(2, _downTransform.position);
            else if (_right) _lineRenderer.SetPosition(2, _rightTransform.position);
        }

        else if (_right)
        {
            _lineRenderer.SetPosition(0, _rightTransform.position);
            if (_up) _lineRenderer.SetPosition(2, _upTransform.position);
            else if (_down) _lineRenderer.SetPosition(2, _downTransform.position);
            else if (_left) _lineRenderer.SetPosition(2, _leftTransform.position);
        }

    }

    public void StartTile() //start tile
    {
        _lineRenderer.positionCount = 9;
        this._up = true;
        this._down = true;
        this._left = true;
        this._right = true;
        CheckExtremTiles();
        if(_upEx)
            _up = false;
        if(_downEx)
            _down = false;
        if(_leftEx)
            _left = false;
        if(_rightEx)
            _right = false;
            
        for(int i = 0; i < _lineRenderer.positionCount; i++)
        {
            if (i % 2 == 0)
            {
                _lineRenderer.SetPosition(i, _centerTransform.position);
            }
            else if (i == 1)
            {
                _lineRenderer.SetPosition(i, _upTransform.position);
            }
            else if (i == 3)
            {
                _lineRenderer.SetPosition(i, _downTransform.position);
            }
            else if (i == 5 )
            {
                _lineRenderer.SetPosition(i, _leftTransform.position);
            }
            else if (i == 7 )
            {
                _lineRenderer.SetPosition(i, _rightTransform.position);
            }
        }
        this.GetComponent<SpriteRenderer>().color = _previousColor;
        _isMonument = true;
        _isAlreadySet = true;
            
    }

    public void LastTile()
    {
        this._isFinish = true;
        this.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    private void CheckExtremTiles()
    {
        if(_position.x == 0)
        {
            _leftEx = true;
        }
        else if(_position.x == _tileManager.LenghtCube.x)
        {
            _rightEx = true;
        }
        else if(_position.y == 0)
        {
            _downEx = true;
        }
        else if(_position.y == _tileManager.LenghtCube.y)
        {
            _upEx = true;
        }
    }

    #endregion

}
