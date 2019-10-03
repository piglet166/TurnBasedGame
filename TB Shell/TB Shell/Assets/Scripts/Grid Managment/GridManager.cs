using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    public class GridManager : MonoBehaviour
    {
        /*
        #region Variables
        //Node[,] grid;
        public float xzScale = 1.5f;
        float yScale = 2f;
        Vector3 minPos, maxPos;
        int maxX, maxY, maxZ;

        #endregion

        void WriteGrid()
        {
            //GridSpace[] gridPosition = GameObject.FindObjectsOfType < GridSpace >();

            float minX = float.MaxValue;
            float maxX = float.MinValue;

            float minZ = minX;
            float maxZ = maxX;

            for(int i = 0; i < gridPosition.Length; i++)
            {
                Transform t = gridPosition[i].transform;

                #region Read Positions
                if(t.position.x < minX)
                {
                    minX = t.position.x;
                }

                if (t.position.x > maxX)
                {
                    maxX = t.position.x;
                }

                if (t.position.z < minZ)
                {
                    minZ = t.position.z;
                }

                if (t.position.z > maxZ)
                {
                    maxZ = t.position.z;
                }

                #endregion
            }

            int x = Mathf.FloorToInt((maxX - minX) / xzScale);
            int z = Mathf.FloorToInt((maxX - minX) / xzScale);

            minPos = Vector3.zero;
            minPos.x = minX;
            minPos.z = minZ;
        }

        void CreateGrid(int x, int z)
        {
            grid = new Node[x, z];

            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < z; j++)
                {

                }
            }
        }*/
    }
}