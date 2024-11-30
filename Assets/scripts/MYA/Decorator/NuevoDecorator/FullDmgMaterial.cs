using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullDmgMaterial : MaterialChangeDecorator
{
    public FullDmgMaterial(MaterialD materialToDecorate) : base(materialToDecorate)
    { }

    public override MaterialD GetMaterial()
    {
        ChangeMaterial();
        return _fullDmgMaterial.GetMaterial();
    }

   void ChangeMaterial()
    {
        Debug.LogError("material Cambiado");
    }
}
