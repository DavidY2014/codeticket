using System;
using System.Collections.Generic;
using System.Text;
using TicketCode.GiftCard.Model;

namespace TicketCode.GiftCard
{
    public interface IAccessService
    {
        ReturnResult Login(string username, string password);

        ReturnResult Register(string username, string password, string activationCode);

        ReturnResult ExchangeGiftCard(string GiftCardId, string GiftCardSecret, int CustomCode);

        List<GiftCardModel> GetGiftCard(int CustomerCode);

        CustomDeliveryModel GetCustomerDetail(int CustomerCode);

        ReturnResult InsertNewAddress(int customerId,int index,string province, string city, string district, string address);
        ReturnResult UpdateAddress(int customerId,int index, string province, string city, string district, string address);
        ReturnResult RemoveAddress(int customerId,int index);

    }
}
