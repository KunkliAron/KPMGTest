
namespace MNBDataLoad
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.KunkliAron = this.Factory.CreateRibbonGroup();
            this.MNBDataLoad = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.KunkliAron.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.KunkliAron);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // KunkliAron
            // 
            this.KunkliAron.Items.Add(this.MNBDataLoad);
            this.KunkliAron.Label = "Kunkli Aron";
            this.KunkliAron.Name = "KunkliAron";
            // 
            // MNBDataLoad
            // 
            this.MNBDataLoad.Label = "MNB adatletoltes";
            this.MNBDataLoad.Name = "MNBDataLoad";
            this.MNBDataLoad.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.MNBDataLoad_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.KunkliAron.ResumeLayout(false);
            this.KunkliAron.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup KunkliAron;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton MNBDataLoad;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
