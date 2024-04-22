using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    [SerializeField] private Tiles _previousTiles = null;
    [SerializeField] private Tiles _newTiles = null;
    [SerializeField] private Tiles _newTilesUI = null;


    public Tiles PreviousTiles { get => _previousTiles; set => _previousTiles = value; }
    public Tiles NewTiles { get => _newTiles; set => _newTiles = value; }


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void OnSelectUITile(TileSelection tileSelection)
    {

    }



}
