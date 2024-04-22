using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{

    [SerializeField] private bool _up = false;
    [SerializeField] private bool _down = false;
    [SerializeField] private bool _left = false;
    [SerializeField] private bool _right = false;

    [SerializeField] private TileManager _tileManager;

    [SerializeField] private Vector2 _position;

    public Vector2 _Position { get => _position; set => _position = value; }


    //private bool up, down, left, right = false;

    private void Start()
    {
        _tileManager = FindObjectOfType<TileManager>();

    }

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

    private void ChangeTile() //to do
    {

    }

}
