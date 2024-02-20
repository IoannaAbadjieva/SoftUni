namespace Artillery.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Common;

public class ImportGunDto
{
    public int Id { get; set; }

    [Range(ValidationConstants.GunWeightMinValue,ValidationConstants.GunWeightMaxValue)]
    public int GunWeight { get; set; }

    [Range(ValidationConstants.BarrelLengthMinValue, ValidationConstants.BarrelLengthMaxValue)]
    public double BarrelLength { get; set; }

    public int? NumberBuild { get; set; }

    [Range(ValidationConstants.GunRangeMinValue, ValidationConstants.GunRangeMaxValue)]
    public int Range { get; set; }

    public string GunType { get; set; } = null!;

    public int ManufacturerId { get; set; }

    public int ShellId { get; set; }

    public InportGunCountryDto[] Countries { get; set; } = null!;
}
