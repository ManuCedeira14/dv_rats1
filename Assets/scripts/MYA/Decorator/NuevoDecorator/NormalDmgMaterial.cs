using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDmgMaterial : MaterialChangeDecorator
{
    public NormalDmgMaterial(MaterialD materialToDecorate) : base(materialToDecorate)
    { }

    public override MaterialD GetMaterial()
    {
        return _normalDmgMaterial.GetMaterial();
    }

    
}
