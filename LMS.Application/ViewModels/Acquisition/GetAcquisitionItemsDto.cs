namespace LMS.Application.ViewModels.Acquisition;

public record struct GetAcquisitionItemsDto(string BatchId,
                                            int BookId,
                                            string BookTitle,
                                            int Quantity,
                                            decimal SalePrice,
                                            decimal PurchasePrice,
                                            decimal GrossPrice);
