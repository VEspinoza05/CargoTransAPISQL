using CargoTransAPISQL.Models;
using CargoTransAPISQL.Data;
using Microsoft.EntityFrameworkCore;
using CargoTransAPISQL.Repositories.Interfaces;

namespace CargoTransAPISQL.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly AppDbContext _context;

        public PurchaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchaseModel>> GetAllAsync()
        {
            return await _context.Purchases
                .Include(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<PurchaseModel?> GetByIdAsync(int id)
        {
            return await _context.Purchases
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);  
        }

        public async Task<PurchaseModel?> AddAsync(PurchaseModel purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            
            return await _context.Purchases
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == purchase.Id);  ;
        }

        public async Task<PurchaseModel?> UpdateAsync(PurchaseModel purchaseModel)
        {
            var existingPurchase = await _context.Purchases.FindAsync(purchaseModel.Id);

            if(existingPurchase == null)
            {
                return null;
            }

            //TODO: Add existingPurchase with its properties
            existingPurchase.SupplierId = purchaseModel.SupplierId;
            existingPurchase.ProductName = purchaseModel.ProductName;
            existingPurchase.ProductDescription = purchaseModel.ProductDescription;
            existingPurchase.Quantity = purchaseModel.Quantity;
            existingPurchase.UnitPrice = purchaseModel.UnitPrice;
            existingPurchase.Total = purchaseModel.Total;

            await _context.SaveChangesAsync();

            var updatedPurchase = await _context.Purchases
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == purchaseModel.Id);  ;


            return updatedPurchase;
        }

        public async Task<PurchaseModel?> ReviewAsync(PurchaseModel purchaseModel)
        {
            var existingPurchase = await _context.Purchases.FindAsync(purchaseModel.Id);

            if(existingPurchase == null)
            {
                return null;
            }

            existingPurchase.RevisionDate = purchaseModel.RevisionDate;
            existingPurchase.RevisionDescription = purchaseModel.RevisionDescription;
            existingPurchase.Status = purchaseModel.Status;

            await _context.SaveChangesAsync();

            var updatedPurchase = await _context.Purchases
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == purchaseModel.Id);  ;


            return updatedPurchase;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var purchaseModel = await _context.Purchases.FirstOrDefaultAsync(x => x.Id == id);

            if(purchaseModel == null)
            {
                return false;
            }

            _context.Purchases.Remove(purchaseModel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}