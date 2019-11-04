using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketCode.GiftCard.Model;
using WebAPI.ORM.Models;

namespace TicketCode.GiftCard
{
    public class AccessService : IAccessService
    {
        public ReturnResult ExchangeGiftCard(string GiftCardId, string GiftCardSecret, int CustomCode)
        {
            var ret = new ReturnResult();
            ret.Success = true;
            try
            {
                using (var dbContext = new GiftCardDBContext())
                {
                    var efGiftCard = new TgiftCard();
                    efGiftCard.GiftCardId = GiftCardId;
                    efGiftCard.TicketSecret = GiftCardSecret;
                    efGiftCard.CustomerId = CustomCode;
                    efGiftCard.UpdateTime = DateTime.Now;
                    dbContext.TgiftCard.Add(efGiftCard);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ret.Success = false;
                ret.Msg = ex.ToString();
            }
            return ret;
        }

        public CustomDeliveryModel GetCustomerDetail(int CustomerCode)
        {
            var ret = new CustomDeliveryModel();
            try
            {
                using (var dbContext = new GiftCardDBContext())
                {
                    var efCustomer = dbContext.Tcustomer.Find(CustomerCode);
                    if (efCustomer != null)
                    {
                        ret.CustomCode = efCustomer.CustomerId;
                        foreach (var item in efCustomer.TdeliveryAddress)
                        {
                            ret.Deliverys.Add(new DeliveryInfo
                            {
                                DeliveryIndex = item.DeliveryId,
                                Province = item.Province,
                                City = item.City,
                                District = item.District,
                                Address = item.Address,
                                ContactName = item.Receiver,
                                ContactPhone = item.Telephone,
                                ZipCode = item.ZipCode
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return ret;
        }

        public List<GiftCardModel> GetGiftCard(int CustomerCode)
        {
            var ret = new List<GiftCardModel>();
            try
            {
                using (var dbContext = new GiftCardDBContext())
                {
                    var efGiftCards = dbContext.TgiftCard.Where(item=>item.CustomerId == CustomerCode);
                    foreach (var item in efGiftCards)
                    {
                        ret.Add(new GiftCardModel
                        {
                            No=item.GiftCardId,
                            TotalCount = item.TotalCount,
                            UsedCount = item.UsedCount,
                            //有效期缺失
                            Description = item.Description
                        });
                    }
                }

            }
            catch (Exception ex)
            {
            }
 
            return ret;
        }

        public ReturnResult InsertNewAddress(int customerId ,int index, string province, string city, string district, string address)
        {
            var ret = new ReturnResult();
            ret.Success = true;
            try
            {
                using (var dbContext = new GiftCardDBContext())
                {
                    var efCustomer = dbContext.Tcustomer.Find(customerId);
                    var efAddress = efCustomer.TdeliveryAddress.FirstOrDefault(item => item.DeliveryId == index);
                    efAddress.Province = province;
                    efAddress.City = city;
                    efAddress.District = district;
                    efAddress.Address = address;
                    dbContext.TdeliveryAddress.Update(efAddress);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ret.Success = false;
                ret.Msg = ex.ToString();
            }

            return ret;
        }

        public ReturnResult Login(string username, string password)
        {
            var ret = new ReturnResult();
            ret.Success = true;
            try
            {
                using (var dbContext = new GiftCardDBContext())
                {
                    var efCustomer =  dbContext.Tcustomer.Where(item => item.UserName == username && item.Password == password).FirstOrDefault();
                    if (efCustomer == null)
                    {
                        ret.Success = false;
                        ret.Msg = "登录失败";
                        return ret;
                    }
                    ret.Msg = "登录成功";
                }
            }
            catch (Exception ex)
            {
                ret.Success = false;
            }
            return ret;
        }

        public ReturnResult Register(string username, string password, string activationCode)
        {
            var ret = new ReturnResult();
            ret.Success = true;
            try
            {
                using (var dbContext = new GiftCardDBContext())
                {
                    var efCustomer = new Tcustomer();
                    efCustomer.UserName = username;
                    efCustomer.Password = password;
                    efCustomer.CreateTime = DateTime.Now;
                    efCustomer.UpdateTime = DateTime.Now;
                    if (activationCode == "ACE123456")
                    {
                        dbContext.Tcustomer.Add(efCustomer);
                        dbContext.SaveChanges();
                    }
                    else {

                        ret.Success = false;
                        ret.Msg = "激活码无效";
                    }
                }
            }
            catch (Exception ex)
            {
                ret.Success = false;
                ret.Msg = ex.ToString();
            }
            return ret;
        }

        public ReturnResult RemoveAddress(int customerId,int index)
        {
            var ret = new ReturnResult();
            //using (var dbContext = new GiftCardDBContext())
            //{

            //}
            return ret;
        }

        public ReturnResult UpdateAddress(int customerId,int index, string province, string city, string district, string address)
        {
            var ret = new ReturnResult();
            //using (var dbContext = new GiftCardDBContext())
            //{

            //}
            return ret;
        }
    }
}
