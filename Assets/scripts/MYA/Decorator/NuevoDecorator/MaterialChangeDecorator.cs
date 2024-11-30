
public abstract class MaterialChangeDecorator : MaterialD
{
    protected MaterialD _normalDmgMaterial;
    protected MaterialD _fullDmgMaterial;
    private MaterialD materialToDecorate;

    public MaterialChangeDecorator(MaterialD materialToDecorate, MaterialD fullDmgMaterialToDecorate)
    {
        _normalDmgMaterial = materialToDecorate;
        _fullDmgMaterial = fullDmgMaterialToDecorate;
    }

    protected MaterialChangeDecorator(MaterialD materialToDecorate)
    {
        this.materialToDecorate = materialToDecorate;
    }
}

