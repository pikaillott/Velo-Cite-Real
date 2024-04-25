using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{

    [SerializeField] private bool _up = false;
    [SerializeField] private bool _down = false;
    [SerializeField] private bool _left = false;
    [SerializeField] private bool _right = false;

    [SerializeField] private Transform _upTransform;
    [SerializeField] private Transform _downTransform;
    [SerializeField] private Transform _leftTransform;
    [SerializeField] private Transform _rightTransform;
    [SerializeField] private Transform _centerTransform;

    [SerializeField] private TileManager _tileManager;

    [SerializeField] private Vector2 _position;

    [SerializeField] private LineRenderer _lineRenderer;

    public Vector2 _Position { get => _position; set => _position = value; }


    //private bool up, down, left, right = false;

    private void Start()
    {
        _tileManager = FindObjectOfType<TileManager>();

    }

    private void Update()
    {
        UpdateLineRenderer();
    }

    #region Function TILE ONMOUSE OVER
    private void OnMouseOver()  
    {
        if (Input.GetMouseButtonDown(0) && _tileManager.NewTilesUI != null) //to do : "vérifier si elle peut se connecter a la prochaine tile + si elles sont bien à côté".
        {
            if (this._position.x == _tileManager.PreviousTiles._Position.x + 1 && this._position.y == _tileManager.PreviousTiles._Position.y) //take pos x, check if pos x is +1 in x, & if pos.y is = to this tile.
            {
                ChangeTile();

            } else if (this._position.x == _tileManager.PreviousTiles._Position.x - 1 && this._position.y == _tileManager.PreviousTiles._Position.y) //take pos x, check if pos x is -1 in x, & if pos.y is = to this tile.
            {
                ChangeTile();

            } else if (this._position.y == _tileManager.PreviousTiles._Position.y + 1 && this._position.x == _tileManager.PreviousTiles._Position.x)
            {
                ChangeTile();

            } else if (this._position.y == _tileManager.PreviousTiles._Position.y - 1 && this._position.x == _tileManager.PreviousTiles._Position.x)
            {
                ChangeTile();
            } else
            {
                return;  //pas necessaire || no use
            }

        }

    }

    #endregion

    private void ChangeTile() //change UI Tile to Map tile
    {
        if (_tileManager.NewTilesUI.Up && _tileManager.PreviousTiles._down || _tileManager.NewTilesUI.Down && _tileManager.PreviousTiles._up || _tileManager.NewTilesUI.Left && _tileManager.PreviousTiles._right || _tileManager.NewTilesUI.Right && _tileManager.PreviousTiles._left)
        {
            print("Change Tile");
            this._up = _tileManager.NewTilesUI.Up;
            this._down = _tileManager.NewTilesUI.Down;
            this._left = _tileManager.NewTilesUI.Left;
            this._right = _tileManager.NewTilesUI.Right;
            UpdateLineRenderer();
        }

    }

    #region Function LINE RENDERER CONTROLLER

    private void UpdateLineRenderer() //update line renderer 
    {
        _lineRenderer.positionCount = 3;
        _lineRenderer.SetPosition(1, _centerTransform.position);
        //le line renderer va forcément passé par le milieu de la tuille
        
        //puis on regarde quelle direction est prise par la tile

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
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, _centerTransform.position);
        if(_up)
            _lineRenderer.SetPosition(1, _upTransform.position);
        else if (_down)
            _lineRenderer.SetPosition(1, _downTransform.position);
        else if (_left)
            _lineRenderer.SetPosition(1, _leftTransform.position);
        else if (_right)
            _lineRenderer.SetPosition(1, _rightTransform.position);
            
    }

    #endregion





}
