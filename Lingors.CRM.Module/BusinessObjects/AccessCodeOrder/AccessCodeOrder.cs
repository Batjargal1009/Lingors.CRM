
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace Lingors.CRM.Module.BusinessObjects.AccessCodeOrder
{
    [DefaultClassOptions, XafDefaultProperty(nameof(date))]
    public class AccessCodeOrder : BaseObject
    {
        public AccessCodeOrder(Session session) : base(session) { }

        private DateTime _date;
        [ModelDefault("AllowEdit", "false")]
        public DateTime date { get { return _date; } set { SetPropertyValue(nameof(date), ref _date, value); } }

        private int _totalQty;
        [ModelDefault("AllowEdit", "false")]
        public int totalQty { get { return _totalQty; } set { SetPropertyValue(nameof(totalQty), ref _totalQty, value); } }

        private double _totalPrice;
        [ModelDefault("AllowEdit", "false")]
        public double totalPrice { get { return _totalPrice; } set { SetPropertyValue(nameof(totalPrice), ref _totalPrice, value); } }

        private AccessCodeStatus _status;
        [ModelDefault("AllowEdit", "false")]
        public AccessCodeStatus status { get { return _status; } set { SetPropertyValue(nameof(status), ref _status, value); } }

        [Action(Caption = "Захиалах", ConfirmationMessage = "", AutoCommit = true)]
        public void ActionToOrder()
        {
            this.status = AccessCodeStatus.New;
            this.Save();
            Session.SaveAsync(this);
            Session.Save(this);
        }

        [DevExpress.Xpo.Aggregated, Association("accessCodeOrder-items")]
        [XafDisplayName("Access code захиалга")]
        public XPCollection<AccessCodeItem> items { get { return GetCollection<AccessCodeItem>(nameof(items)); } }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            date = DateTime.Now;
            this.status = AccessCodeStatus.None;
        }

        protected override void OnSaving()
        {
            if (items != null && items.Count > 0)
            {
                this.totalQty = this.items.Sum(x => x.qty);
                this.totalPrice = this.items.Sum(x => x.totalPrice);
            }
            //base.OnSaving();
        }
        protected override void OnSaved()
        {
            this.totalQty = this.items.Sum(x => x.qty);
            this.totalPrice = this.items.Sum(x => x.totalPrice);
            base.OnSaved();
        }
    }
}