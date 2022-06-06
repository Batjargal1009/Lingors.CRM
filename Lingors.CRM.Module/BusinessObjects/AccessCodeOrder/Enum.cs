using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
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
    public enum AccessCodeType
    {
        None = 0,
        Month1 = 1,
        Month2 = 2,
        Month3 = 3,
        Month4 = 4,
        Month6 = 5,
        Month12 = 6,
    }
    public enum AccessCodeStatus
    {
        None=0,
        New=1,
        Approved=2,
        Pendingpayment=3,
        Paid=4,
    }
    public enum AccessCodeItems
    {
        [XafDisplayName("Батлах")]
        approve=0,

    }
}