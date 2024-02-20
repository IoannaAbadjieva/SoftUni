namespace Artillery;

using Artillery.DataProcessor.ExportDto;
using AutoMapper;

using Data.Models;
using DataProcessor.ImportDto;

 public class ArtilleryProfile : Profile
{
    // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
    public ArtilleryProfile()
    {
        this.CreateMap<ImportCountryDto, Country>();
        
        this.CreateMap<ImportManufacturerDto, Manufacturer>();
       
        this.CreateMap<ImportShellDto,Shell>();
        
     
     
    }
}