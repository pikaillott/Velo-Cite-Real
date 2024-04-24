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

    [SerializeField] private LineRenderer lineRenderer;

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
    private void _OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && _tileManager.NewTiles != null) //to do : "vérifier si elle peut se connecter a la prochaine tile + si elles sont bien à côté".
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

    private void ChangeTile() //to do
    {
        if (_tileManager.NewTiles._up && _tileManager.PreviousTiles._down || _tileManager.NewTiles._down && _tileManager.PreviousTiles._up || _tileManager.NewTiles._left && _tileManager.PreviousTiles._right || _tileManager.NewTiles._right && _tileManager.PreviousTiles._left) 
        {

        }

    }

    #region Function LINE RENDERER CONTROLLER

    private void UpdateLineRenderer()
    {
        lineRenderer.positionCount = 3;
        lineRenderer.SetPosition(1, _centerTransform.position);

        if (_up)
        {
            lineRenderer.SetPosition(0, _upTransform.position);
            if (_down) lineRenderer.SetPosition(2, new Vector2(-0.5f, 0));
            else if (_left) lineRenderer.SetPosition(2, new Vector2(0, -0.5f));
            else if (_right) lineRenderer.SetPosition(2, new Vector2(0, 0.5f));
        }

        else if (_down)
        {
            lineRenderer.SetPosition(0, _downTransform.position);
            if (_up) lineRenderer.SetPosition(2, new Vector2(0.5f, 0));
            else if (_left) lineRenderer.SetPosition(2, new Vector2(0, -0.5f));
            else if (_right) lineRenderer.SetPosition(2, new Vector2(0, 0.5f));
        }

        else if (_left)
        {
            lineRenderer.SetPosition(0, _leftTransform.position);
            if (_up) lineRenderer.SetPosition(2, new Vector2(0.5f, 0));
            else if (_down) lineRenderer.SetPosition(2, new Vector2(-0.5f, 0));
            else if (_right) lineRenderer.SetPosition(2, new Vector2(0, 0.5f));
        }

        else if (_right)
        {
            lineRenderer.SetPosition(0, _rightTransform.position);
            if (_up) lineRenderer.SetPosition(2, new Vector2(0.5f, 0));
            else if (_down) lineRenderer.SetPosition(2, new Vector2(-0.5f, 0));
            else if (_left) lineRenderer.SetPosition(2, new Vector2(0, -0.5f));
        }

    }

    #endregion





}
