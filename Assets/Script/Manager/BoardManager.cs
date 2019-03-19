using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

namespace Completed
{

    [Serializable]

    public class Count
    {
        public int minimum;
        public int maximum;


        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public class BoardManager : MonoBehaviour
    {


        public int columns = 8;
        public int rows = 8;

        public Count WallCount = new Count(5, 3);
        public Count FoodCount = new Count(1, 5);

        public GameObject exit;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;
        public GameObject[] enemyTiles;
        public GameObject[] outterWallTiles;

        private Transform boardHolder;
        private List<Vector3> gridPosition = new List<Vector3>();


        private void Start()
        {
            
        }

        private void InitialiseList()
        {
            gridPosition.Clear();

            for (int x = 1; x < columns - 1; x++)
            {
                for (int y = 1; y < rows - 1; y++)
                {
                    gridPosition.Add(new Vector3(x, y, 0f));
                }
            }
        }

        private void BoardSetup()
        {
            boardHolder = new GameObject("Board").transform;

            for (int x = -1; x < columns + 1; x++)
            {
                for (int y = -1; y < rows + 1; y++)
                {
                    GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                    if (x == -1 || x == columns || y == -1 || y == rows)
                    {
                        toInstantiate = outterWallTiles[Random.Range(0, outterWallTiles.Length)];
                    }

                    GameObject instance =
                        Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity);
                    instance.transform.SetParent(boardHolder);

                }
            }
        }


        private Vector3 RandomPosition()
        {
            int randomIndex = Random.Range(0, gridPosition.Count);
            Vector3 randomPostion = gridPosition[randomIndex];
            gridPosition.RemoveAt(randomIndex);
            return randomPostion;

        }


        private void LayoutObjectAtRandom(GameObject[] tileArray, int min, int max)
        {
            int objectCount = Random.Range(min, max + 1);

            for (int n = 0; n < objectCount; n++)
            {
                Vector3 randomPos   = RandomPosition();
                GameObject tile = tileArray[Random.Range (0, tileArray.Length)];
                Instantiate(tile, randomPos, Quaternion.identity); 
            }
        }

        public void SetupScene(int level)
        {
            BoardSetup();
            InitialiseList();
            //Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
            LayoutObjectAtRandom(wallTiles, WallCount.minimum, WallCount.maximum);

            //Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
            LayoutObjectAtRandom(foodTiles, FoodCount.minimum, FoodCount.maximum);

            int enemyCount = (int)Math.Log(level, 2f);
            LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);

            //Instantiate the exit tile in the upper right hand corner of our game board
            Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);



        }



    }

}



