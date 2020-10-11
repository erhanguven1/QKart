using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [System.Serializable]
    public class Matrix
    {
        public float[] Rows;
    }

    public List<Matrix> NOT_GATE1, NOT_GATE2, Haddamard1, Haddamard2, Z_GATE1, Z_GATE2, CNOT, CNOT2;

    public List<Matrix> matrix1, matrix2, q0;
    public Vector4 q0Vector4;
    // Start is called before the first frame update
    void Start()
    {

        InitializeHaddamard();
        var matrix1TwoDim = (Calculations.OneDimToTwoDim(matrix1));
        var matrix2TwoDim = (Calculations.OneDimToTwoDim(matrix2));

        var dotProduct = (Calculations.DotProduct(matrix1TwoDim, matrix2TwoDim));

        for (int i = 0; i < dotProduct.GetLength(0); i++)
        {
            for (int j = 0; j < dotProduct.GetLength(1); j++)
            {
                //print(dotProduct[i, j]);
            }
        }
    }

    void InitializeHaddamard()
    {
        foreach (var item in Haddamard1)
        {
            for (int i = 0; i < item.Rows.Length; i++)
            {
                item.Rows[i] *= 1 / Mathf.Sqrt(2);

            }
        }
        foreach (var item in Haddamard2)
        {
            for (int i = 0; i < item.Rows.Length; i++)
            {
                item.Rows[i] *= 1 / Mathf.Sqrt(2);

            }
        }
    }

    public void NotGate1()
    {
        var dotProduct = Calculations.DotProduct(Calculations.OneDimToTwoDim(NOT_GATE1), Calculations.OneDimToTwoDim(q0));
        for (int i = 0; i < dotProduct.GetLength(0); i++)
        {
            for (int j = 0; j < dotProduct.GetLength(1); j++)
            {
                q0[i].Rows[j] = dotProduct[i, j];
                print(dotProduct[i, j]);
            }
        }
    }

    public void Haddamard1Gate()
    {
        var dotProduct = Calculations.DotProduct(Calculations.OneDimToTwoDim(Haddamard1), Calculations.OneDimToTwoDim(q0));
        for (int i = 0; i < dotProduct.GetLength(0); i++)
        {
            for (int j = 0; j < dotProduct.GetLength(1); j++)
            {
                q0[i].Rows[j] = dotProduct[i, j];
                print(dotProduct[i, j]);
            }
        }
    }

    public void ZGate1()
    {
        var dotProduct = Calculations.DotProduct(Calculations.OneDimToTwoDim(Z_GATE1), Calculations.OneDimToTwoDim(q0));
        for (int i = 0; i < dotProduct.GetLength(0); i++)
        {
            for (int j = 0; j < dotProduct.GetLength(1); j++)
            {
                q0[i].Rows[j] = dotProduct[i, j];
                print(dotProduct[i, j]);
            }
        }
    }

    public void CNot()
    {
        var dotProduct = Calculations.DotProduct(Calculations.OneDimToTwoDim(CNOT), Calculations.OneDimToTwoDim(q0));
        for (int i = 0; i < dotProduct.GetLength(0); i++)
        {
            for (int j = 0; j < dotProduct.GetLength(1); j++)
            {
                q0[i].Rows[j] = dotProduct[i, j];
                print(dotProduct[i, j]);
            }
        }
    }

    public void NotGate2()
    {
        var dotProduct = Calculations.DotProduct(Calculations.OneDimToTwoDim(NOT_GATE2), Calculations.OneDimToTwoDim(q0));
        for (int i = 0; i < dotProduct.GetLength(0); i++)
        {
            for (int j = 0; j < dotProduct.GetLength(1); j++)
            {
                q0[i].Rows[j] = dotProduct[i, j];
                print(dotProduct[i, j]);
            }
        }
    }

    public void Haddamard2Gate()
    {
        var dotProduct = Calculations.DotProduct(Calculations.OneDimToTwoDim(Haddamard2), Calculations.OneDimToTwoDim(q0));
        for (int i = 0; i < dotProduct.GetLength(0); i++)
        {
            for (int j = 0; j < dotProduct.GetLength(1); j++)
            {
                q0[i].Rows[j] = dotProduct[i, j];
                print(dotProduct[i, j]);
            }
        }
    }

    public void ZGate2()
    {
        var dotProduct = Calculations.DotProduct(Calculations.OneDimToTwoDim(Z_GATE2), Calculations.OneDimToTwoDim(q0));
        for (int i = 0; i < dotProduct.GetLength(0); i++)
        {
            for (int j = 0; j < dotProduct.GetLength(1); j++)
            {
                q0[i].Rows[j] = dotProduct[i, j];
                print(dotProduct[i, j]);
            }
        }
    }

    public void CNot2()
    {
        var dotProduct = Calculations.DotProduct(Calculations.OneDimToTwoDim(CNOT2), Calculations.OneDimToTwoDim(q0));
        for (int i = 0; i < dotProduct.GetLength(0); i++)
        {
            for (int j = 0; j < dotProduct.GetLength(1); j++)
            {
                q0[i].Rows[j] = dotProduct[i, j];
                print(dotProduct[i, j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NotGate1();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Haddamard1Gate();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ZGate1();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CNot();
        }

        q0Vector4.x = Mathf.Pow(q0[0].Rows[0], 2);
        q0Vector4.y = Mathf.Pow(q0[1].Rows[0], 2);
        q0Vector4.z = Mathf.Pow(q0[2].Rows[0], 2);
        q0Vector4.w = Mathf.Pow(q0[3].Rows[0], 2);
    }
}
