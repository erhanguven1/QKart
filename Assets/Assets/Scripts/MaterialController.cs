using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{

    public List<Material> carMaterials;
    public Material hologramMaterial;

    public void InitializeCarMaterials(MeshRenderer meshRenderer)
    {
        meshRenderer.gameObject.layer = 0;

        for (int i = 0; i < 4; i++)
        {
            meshRenderer.materials[i].shader = carMaterials[i].shader;
            meshRenderer.materials[i].SetColor ("_BaseColor",carMaterials[i].GetColor("_BaseColor"));
        }
    }

    public void InitializeHologramMaterials(MeshRenderer meshRenderer)
    {
        for (int i = 0; i < 4; i++)
        {
            if (Mathf.Abs(meshRenderer.GetComponentInParent<Car>().prob)<.01f)
            {
                meshRenderer.gameObject.layer = 9;
            }
            else
            {
                meshRenderer.gameObject.layer = 0;
                meshRenderer.materials[i].shader = hologramMaterial.shader;
            }
        }
    }
}
