using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public static class Calculations
{

    public static float[,] OneDimToTwoDim(List<Test.Matrix> matrix)
    {
        float[,] output = new float[matrix.Count, matrix[0].Rows.Length];
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[0].Rows.Length; j++)
            {
                output[i, j] = matrix[i].Rows[j];
            }
        }
        return output;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix1"></param>
    /// <param name="matrix2"></param>
    /// <returns></returns>
    public static float[,] DotProduct(float[,] matrix1, float[,] matrix2)
    {
        
        float[,] output = new float[matrix1.GetLength(0), matrix2.GetLength(1)];

        //matrix 1 = mxn
        //matrix 2 = axb

        for (int i = 0; i < matrix2.GetLength(1); i++)
        {
            for (int j = 0; j < matrix1.GetLength(0); j++)
            {
                for (int k = 0; k < matrix1.GetLength(1); k++)
                {
                    output[j, i] += matrix2[k, i] * matrix1[j, k];
                    //output[j, i] = output[j, i] > .95f ? 1 : (Mathf.Abs( output[j, i]) < .1f ? 0 :
                      //  (output[j, i] > -.9f ? -1 : output[j, i]));
                }
            }
        }

        return output;
    }



    public static float[,] TensorProduct(float[,] matrix1, float[,] matrix2)
    {
        return null;
        float[,] output = new float[matrix1.GetLength(0) * matrix2.GetLength(0),
            matrix2.GetLength(1) * matrix2.GetLength(1)];

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(0); j++)
            {
                for (int k = 0; k < matrix1.GetLength(1); k++)
                {
                    for (int w = 0; w < matrix2.GetLength(1); w++)
                    {
                        //output[i + w, k + j] = matrix1[i, j] * matrix2[k, w];
                    }
                }
            }
        }
        return output;
    }
}
