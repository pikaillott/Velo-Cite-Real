using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelection : MonoBehaviour
{

    [SerializeField] private bool _up = false;
    [SerializeField] private bool _down = false;
    [SerializeField] private bool _left = false;
    [SerializeField] private bool _right = false;
    public bool Up { get => _up; set => _up = value; }
    public bool Down { get => _down; set => _down = value; }
    public bool Left { get => _left; set => _left = value; }
    public bool Right { get => _right; set => _right = value; }
    

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
