using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorScript : MonoBehaviour
{
    private float _minPosx;
    private float _maxPosx;

    private float _minPosy;
    private float _maxPosy;

    private float _howManyTilesx;
    private float _howManyTilesy;

    private float _posX;
    private float _posY;
    private Vector2 _posTile;

    [SerializeField] private GameObject _tile;
    [SerializeField] private GameObject _shopBackground;
    private int testint;

    private void Start()
    {
        {
            _minPosx = Screen.width / 2 - 20;
            _maxPosx = Screen.width + _minPosx;

            _minPosy = Screen.height / 2;
            _maxPosy = Screen.height + _minPosy;

            _howManyTilesy = Screen.height / 100;

            _posY = _minPosy;
            testint = 1;

            _posTile = new Vector2(_minPosx + 100,_minPosy + 100);
         
        }
    }

    private void Update()
    {
        this.gameObject.transform.position = new Vector2(Screen.width, Screen.height);
        _howManyTilesx = (Screen.width - _shopBackground.transform.localScale.x) / 100 - 1;

        if (testint == 1)
        {
            for (int i = 0; i < _howManyTilesy; i++)
            {
                _posY += 100;
                _posX = _minPosx;

                if(i == _howManyTilesy - 1)
                {
                    testint = 2;
                }
                for (int j = 0; j < _howManyTilesx; j++)
                {
                    _posX += 100;
                    _posTile = new Vector3(_posX, _posY, -1);
                    Instantiate(_tile, _posTile, Quaternion.identity);
                }
            }
        }
    }
}
