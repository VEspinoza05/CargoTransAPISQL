using CargoTransAPISQL.DTOs.Purchase;
using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Mappers
{
    public static class PurchaseMapper
    {
        public static PurchaseDTO ToPurchaseDTO(this PurchaseModel purchaseModel)
        {
            return new PurchaseDTO()
            {
                Id = purchaseModel.Id,
                SupplierId = purchaseModel.SupplierId,
                Supplier = purchaseModel.Supplier.ToSupplierDTO(),
                RequestDate = purchaseModel.RequestDate,
                ProductName = purchaseModel.ProductName,
                ProductDescription = purchaseModel.ProductDescription,
                Quantity = purchaseModel.Quantity,
                UnitPrice = purchaseModel.UnitPrice,
                Total = purchaseModel.Total,
                RevisionDate = purchaseModel.RevisionDate,
                RevisionDescription = purchaseModel.RevisionDescription,
                SenderEmployeeId = purchaseModel.SenderEmployeeId,
                Status = purchaseModel.Status,
            };
        }

        public static PurchaseModel ToPurchaseFromNewDTO(this NewPurchaseDTO newPurchaseDTO)
        {
            return new PurchaseModel()
            {
                SupplierId = newPurchaseDTO.SupplierId,
                ProductName = newPurchaseDTO.ProductName,
                ProductDescription = newPurchaseDTO.ProductDescription,
                Quantity = newPurchaseDTO.Quantity,
                UnitPrice = newPurchaseDTO.UnitPrice,
                Total = newPurchaseDTO.Total,
                SenderEmployeeId = newPurchaseDTO.SenderEmployeeId,
                Status = newPurchaseDTO.Status,
            };
        }

        public static PurchaseModel ToPurchaseFromUpdateDTO(this UpdatePurchaseDTO updatePurchaseDTO, int id)
        {
            return new PurchaseModel()
            {
                Id = id,
                SupplierId = updatePurchaseDTO.SupplierId,
                ProductName = updatePurchaseDTO.ProductName,
                ProductDescription = updatePurchaseDTO.ProductDescription,
                Quantity = updatePurchaseDTO.Quantity,
                UnitPrice = updatePurchaseDTO.UnitPrice,
                Total = updatePurchaseDTO.Total,
            };
        }

        public static PurchaseModel ToPurchaseFromRevisionDTO(this PurchaseRevisionDTO purchaseRevisionDTO, int id)
        {
            return new PurchaseModel()
            {
                Id = id,
                Status = purchaseRevisionDTO.Status,
                RevisionDescription = purchaseRevisionDTO.RevisionDescription,
            };
        }
    }
}