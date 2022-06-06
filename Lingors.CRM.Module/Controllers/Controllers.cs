using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.XtraReports.UI;
using DevExpress.Utils.CommonDialogs.Internal;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using DevExpress.ExpressApp.DC;
using Lingors.CRM.Module.BusinessObjects.AccessCodeOrder;
using System.IO;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Spreadsheet;

namespace Lingors.CRM.Module.Controllers
{
    public partial class ModuleViewController : ViewController
    {
        public event EventHandler<SimpleActionExecuteEventArgs> Action_Execute;
        public ModuleViewController() : base()
        {
            //InitializeComponent();

            //var actionUpdate = new SimpleAction(components) { Caption = "Систем шинэчлэх", Id = "SystemUpdate", ImageName = "ModelEditor_IndexDown" };
            //actionUpdate.Execute += (sender, e) => Action_Execute?.Invoke(sender, e);
            //actionUpdate.Category = "File";
            //Actions.Add(actionUpdate);

            CreateSimpleAction<AccessCodeOrder>("Файл хуулах", "actionExcelImport", ViewType.DetailView, null, null, ActionItemPaintStyle.Default, actionExcelImportExecute);
        }

        //private void actionTest(object sender, CustomizePopupWindowParamsEventArgs args)
        //{
        //    IObjectSpace objectSpace = Application.CreateObjectSpace();
        //    args.Context = TemplateContext.ApplicationWindow;
        //    args.View = Application.CreateListView(Application.FindListViewId(typeof(Item)), new CollectionSource(objectSpace, typeof(Item)), true);
        //    args.Maximized = true;
        //    args.View.Closing += testClosed;
        //}
        private void ShowConfirmationPopup(string prompt, string ok = "За", string cancel = "Хаах")
        {
            var confirmationView = Application.CreateDetailView(Application.CreateObjectSpace(), new ConfirmationPopup(prompt), View);
            Application.ShowViewStrategy.ShowViewInPopupWindow(confirmationView, PopupConfirmed, PopupCancelled, ok, cancel);
        }

        private void PopupCancelled()
        {
        }

        private void PopupConfirmed()
        {
        }

        private void actionExcelImportExecute(object sender, SimpleActionExecuteEventArgs e)
        {
            
        }
        private void CreateSimpleAction<T>(string caption, string id, ViewType viewType, string category = null, string imageName = null, ActionItemPaintStyle style = ActionItemPaintStyle.Default, SimpleActionExecuteEventHandler eventHandler = null, bool isSingleAction = false)

        //private void ImportTemplateData_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        //{
        //    if (ImportDataParam.FileImport! = null)
        //    {
        //        var fileData = ImportDataParam.FileImport;
        //        using (MemoryStream stream = new MemoryStreamStream())
        //        {
        //            fileData.SaveToStream(stream);
        //            stream.Position = 0;
        //            Workbook workbook = new Workbook();
        //            workbook.LoadDocument(stream, DocumentFormat.Xlsx);
        //            IWorkbook iwb = workbook;
        //            bool result = Importer.ProcessImportAction(iwb);
        //            if (result)
        //                Application.ShowViewStrategy.ShowMessage("");
        //            else
        //                Application.ShowViewStrategy.ShowMessage("");
        //        }
        //    }
        //    else
        //        Application.ShowViewStrategy.ShowMessage("");
        //    ObjectSpaceCreatedEventArgs.CommitChanges();
        //    ObjectSpaceCreatedEventArgs.Refresh();
        //    View.Refresh();

        //}
        {
            var action = new SimpleAction()
            {
                Caption = caption,
                Id = id,
                TargetViewType = viewType,
                TargetObjectType = typeof(T),
                ImageName = imageName,
                Category = category,
                PaintStyle = style,
            };
            if (eventHandler != null)
                action.Execute += new SimpleActionExecuteEventHandler(eventHandler);
            else
                action.Execute += action_Execute;
            Actions.Add(action);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
        //private void ImportTemplateData_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        //{
        //    if (ImportDataParam.FileImport! = null)
        //    {
        //        var fileData = ImportDataParam.FileImport;
        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            fileData.SaveToStream(stream);
        //            stream.Position = 0;
        //            Workbook workbook = new Workbook();
        //            workbook.LoadDocument(stream, DocumentFormat.Xlsx);
        //            IWorkbook iwb = (IWorkbook)workbook;
        //            bool result = Importer.ProcessImportAction(iwb);
        //            if (result)
        //                Application.ShowViewStrategy.ShowMessage("");
        //            else
        //                Application.ShowViewStrategy.ShowMessage("");
        //        }
        //    }
        //    else
        //        Application.ShowViewStrategy.ShowMessage("");
        //    View.Refresh();

        //}
        void Action_PosItemExecute(object sender, SimpleActionExecuteEventArgs e)
        {
            //var pos = (ObjectSpace.Owner as DetailView).CurrentObject as Pos;
            //foreach (var item in Item.GetProducts(ObjectSpace))
            //{
            //  var posItem = pos.PosItems.FirstOrDefault(t => t.ItemId == item);
            //  if (posItem == null)
            //  {
            //    posItem = ObjectSpace.CreateObject<PosItem>();
            //    posItem.ItemId = item;
            //    posItem.IsSale = true;
            //    pos.PosItems.Add(posItem);
            //  }
            //}
            //View.Refresh();
        }
        void action_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (Action_Execute != null)
                Action_Execute(sender, e);
        }
    }

    [NonPersistent]
    [XafDisplayName("")]
    public class ConfirmationPopup
    {
        public ConfirmationPopup(string prompt)
        {
            Prompt = prompt;
        }

        [XafDisplayName("Анхаар")]
        public string Prompt { get; private set; }
    }

    [NonPersistent]
    [XafDisplayName("TestObj sgu sda mnine")]
    public class TestObj
    {
        public TestObj(string prompt)
        {
            Prompt = prompt;
        }

        [XafDisplayName("Анхаар")]
        public string Prompt { get; set; }
    }
}
