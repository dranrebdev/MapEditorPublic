using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadMap : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _groundMaps;
    private int width;
    private int height;




    private void Start()
    {
        GenerateMap();
    }


    private void Update()
    {
        
    }


    private void GenerateMap()
    {
        //Get the Data
        string[] mapData = ReadMapText();


        //Get Map Size
        int mapSizeX = mapData[0].ToCharArray().Length;
        int mapSizeY = mapData.Length;
        width = mapSizeX;
        height = mapSizeY;


        //Generate the GroundMaps
        for (int y = 0; y < mapSizeY; y++) //Height
        {
            //Get Horizontal Map Data Char
            char[] newTiles = mapData[y].ToCharArray();

            for (int x = 0; x < mapSizeX; x++) //Width
            {
                int groundCode = MapDataConverter(newTiles[x]);
                GameObject spawnedMap = Instantiate(_groundMaps[groundCode], new Vector3(x, y, 0), Quaternion.identity);
            }
        }

    }

    //Reads the Data
    private string[] ReadMapText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;
        string data = bindData.text.Replace(Environment.NewLine, string.Empty); //Remove the newlines

        return data.Split('-');
    }


    // Converts the Data to Int Index
    private int MapDataConverter(char charCode)
    {
        int output = 0;
        string levelCode = charCode.ToString();

        //Dirt
        if (levelCode == "d") output = 0;
        //Grass
        if (levelCode == "g") output = 1;
        //Wall
        if (levelCode == "w") output = 2;
        //Floor
        if (levelCode == "f") output = 3;

        return output;

    }


}//End of Class
