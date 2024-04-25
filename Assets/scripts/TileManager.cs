using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileManager : MonoBehaviour
{

    [SerializeField] private Tiles _previousTiles = null;
    [SerializeField] private Tiles _newTiles = null;
    [SerializeField] private TileSelection _newTilesUI = null;


    public Tiles PreviousTiles { get => _previousTiles; set => _previousTiles = value; }
    public Tiles NewTiles { get => _newTiles; set => _newTiles = value; }
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
        Tiles[] allTiles= FindObjectsOfType<Tiles>();
        int randomTile = Random.Range(0, allTiles.Length);
        PreviousTiles = allTiles[randomTile];
        PreviousTiles.StartTile();

    }
    



}
