using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);

       // void SendEmail(string email, string subject, string body);
    }
}