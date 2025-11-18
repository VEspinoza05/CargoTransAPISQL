
using CargoTransAPISQL.DTOs.Invoice;
using CargoTransAPISQL.DTOs.Package;
using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Mappers
{
    public static class PackageMapper
    {
        public static PackageModel ToPackageFromNewDTO(this NewPackageDTO newPackageDTO)
        {
            return new PackageModel()
            {
                Sender = newPackageDTO.Sender,
                Recipient = newPackageDTO.Recipient,
                Weight = newPackageDTO.Weight,
                Dimensions = newPackageDTO.Dimensions,
                ContentType = newPackageDTO.ContentType,
                Observations = newPackageDTO.Observations,
                Status = newPackageDTO.Status,
                ReceptionDate = newPackageDTO.ReceptionDate,
                LatitudeDestination = newPackageDTO.LatitudeDestination,
                LongitudeDestination = newPackageDTO.LongitudeDestination
            };
        }

    }
}