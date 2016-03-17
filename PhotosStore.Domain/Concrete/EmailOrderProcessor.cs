using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "krasnyuk-photo@mail.ru";
        public string MailFromAddress = "krasnyuk.photo@gmail.com";
        public bool UseSsl = true;
        public string Username = "krasnyuk.photo@gmail.com";
        public string Password = "bafnet123";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"D:\Programming\photo_store_emails";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private readonly EmailSettings _emailSettings;
        private readonly IOrdersRepository _ordersRepository;
        public EmailOrderProcessor(EmailSettings settings, IOrdersRepository ordersRepository)
        {
            _emailSettings = settings;
            this._ordersRepository = ordersRepository;
        }
       

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                smtpClient.Host = _emailSettings.ServerName;
                smtpClient.Port = _emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.Username,_emailSettings.Password);
                MailMessage msg = new MailMessage
                {
                    From = new MailAddress(_emailSettings.MailFromAddress)
                };
                msg.To.Add(new MailAddress(_emailSettings.MailToAddress));
                msg.Subject = "Заказ";
                
                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ обработан")
                    .AppendLine("---")
                    .AppendLine("Товары:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.PhotoTechnique.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (итого: {2:c}",
                        line.Quantity, line.PhotoTechnique.Name, subtotal);
                }

                body.AppendFormat("Общая стоимость: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Доставка:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Email)
                    .AppendLine(shippingInfo.Adress ?? "")
                    .AppendLine(shippingInfo.Telephone ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.Country)
                    .AppendLine("---")
                    .AppendFormat("Подарочная упаковка: {0}",
                        shippingInfo.GiftWrap ? "Да" : "Нет");
                msg.Body = body.ToString();
                smtpClient.Send(msg);

                Order order = new Order()
                {
                    Adress = shippingInfo.Adress,
                    City = shippingInfo.City,
                    Date = DateTime.Now,
                    Email = shippingInfo.Email,
                    Name = shippingInfo.Name,
                    Telephone = shippingInfo.Telephone,
                    OrderID = _ordersRepository.Orders.Max(x=>x.OrderID) + 1
                    
                };
                OrderDetail orderDetails = new OrderDetail
                {
                        OrderDetailsID = _ordersRepository.OrderDetails
                            .Max(x => x.OrderDetailsID) + 1,
                        
                        Orders = order,
                        PhotoTechniqueID = cart.Lines.FirstOrDefault().PhotoTechnique.PhotoTechniqueId,
                        PhotoTechniques = cart.Lines.FirstOrDefault().PhotoTechnique,
                        Quantity = 5,
                };

                _ordersRepository.SaveOrder(orderDetails);
            }
        }
    }
}
