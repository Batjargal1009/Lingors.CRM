using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lingors.CRM.Module.BusinessObjects.AccessCodeOrder
{
    [DefaultClassOptions]
    [XafDisplayName("Access code захиалгын жагсаалт")]
    public class AccessCodeItem : BaseObject
    {
        public AccessCodeItem(Session session) : base(session) { }

        private AccessCodeOrder _accessCodeOrderId;
        [Association("accessCodeOrder-items")]
        public AccessCodeOrder accessCodeOrderId { get { return _accessCodeOrderId; } set { SetPropertyValue(nameof(accessCodeOrderId), ref _accessCodeOrderId, value); } }

        private AccessCodeType _type;
        [ImmediatePostData]
        public AccessCodeType type { get { return _type; } set { SetPropertyValue(nameof(type), ref _type, value); } }

        private int _qty;
        public int qty { get { return _qty; } set { SetPropertyValue(nameof(qty), ref _qty, value); } }

        private double _price;
        [ModelDefault("AllowEdit", "false")]
        public double price { get { return _price; } set { SetPropertyValue(nameof(price), ref _price, value); } }

        private double _totalPrice;
        [ModelDefault("AllowEdit", "false")]
        public double totalPrice { get { return _totalPrice; } set { SetPropertyValue(nameof(totalPrice), ref _totalPrice, value); } }

        //private AccessCodeUpload _upload;
        //public AccessCodeUpload upload { get { return _upload; } set { SetPropertyValue(nameof(upload), ref _upload, value); } }

        private AccessCodeStatus _status;
        [ModelDefault("AllowEdit", "false")]
        public AccessCodeStatus status { get { return _status; } set { SetPropertyValue(nameof(status), ref _status, value); } }

        public object ImportDataParam { get; private set; }

        [Action(Caption = "Батлах", ConfirmationMessage = "", AutoCommit = true)]
        public void ActionToOrder()
        {
            this.status = AccessCodeStatus.Approved;
        }

        
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == "qty")
            {
                if (this.qty < 0)
                    throw new Exception("Тоо ширхэг хасах утгатай байж болохгүй.");
            }
            else if (propertyName == "type") {
                switch (type)
                {
                    case AccessCodeType.None:
                        price = 0;
                        break;
                    case AccessCodeType.Month1:
                        price = 1;
                        break;
                    case AccessCodeType.Month2:
                        price = 2;
                        break;
                    case AccessCodeType.Month3:
                        price = 3;
                        break;
                    case AccessCodeType.Month4:
                        price = 4;
                        break;
                    case AccessCodeType.Month6:
                        price = 8;
                        break;
                    case AccessCodeType.Month12:
                        price = 10;
                        break;
                    default:
                        price = 0;
                        break;
                }
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            totalPrice = qty * price;
        }
        
    }
}