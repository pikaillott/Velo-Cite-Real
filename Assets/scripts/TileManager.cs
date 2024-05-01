using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileManager : MonoBehaviour
{

    [SerializeField] private Tiles _previousTiles = null;
    [SerializeField] private Tiles _lastTile = null;
    [SerializeField] private TileSelection _newTilesUI = null;
    [SerializeField] private Vector2 _lenghtCube;
    
    public Vector2 LenghtCube { get => _lenghtCube; set => _lenghtCube = value; }
    public Tiles PreviousTiles { get => _previousTiles; set => _previousTiles = value; }
    public TileSelection NewTilesUI { get => _newTilesUI; set => _newTilesUI = value; }

    private void Start()
    {
        SetStartTile();
    }

    public void OnSelectUITile(TileSelection tileSelection)
    {
        if (tileSelection == null)
            return;
        _newTilesUI = tileSelection;
    }

    private void SetStartTile()
    {
        Tiles[] allTiles = FindObjectsOfType<Tiles>();
        int StartTile = Random.Range(0, allTiles.Length);
        PreviousTiles = allTiles[StartTile];
        PreviousTiles.StartTile();
        int FinishTile = Random.Range(0, allTiles.Length);
        while (StartTile == FinishTile)
        {
            FinishTile = Random.Range(0, allTiles.Length);
        }
        _lastTile = allTiles[FinishTile];
        _lastTile.LastTile();

    }

    public void CheckPass()
    {
        

        bool isLeft = PreviousTiles.Left && !PreviousTiles.LeftConnected;
        bool isRight = PreviousTiles.Right && !PreviousTiles.RightConnected;
        bool isUp = PreviousTiles.Up && !PreviousTiles.UpConnected;
        bool isDown = PreviousTiles.Down && !PreviousTiles.DownConnected;
        bool posLeft = PreviousTiles.Position.x == _lastTile.Position.x - 1;
        bool posRight = PreviousTiles.Position.x == _lastTile.Position.x + 1;
        bool posUp = PreviousTiles.Position.y == _lastTile.Position.y - 1;
        bool posDown = PreviousTiles.Position.y == _lastTile.Position.y + 1;
        print(isLeft + " " + posLeft);
        print(isRight + " " + posRight);
        print(isUp + " " + posUp);
        print(isDown + " " + posDown);
        
        if (isLeft && posLeft)
        {
            ResetGame();
        }
        else if (isRight && posRight)
        {
            ResetGame();
        }
        else if (isUp && posUp)
        {
            ResetGame();
        }
        else if (isDown && posDown)
        {
            ResetGame();
        }
        else
        {
            print("lose");
        }
            
    }

    public void ResetGame()
    {
        print("win");
    }
    



}
