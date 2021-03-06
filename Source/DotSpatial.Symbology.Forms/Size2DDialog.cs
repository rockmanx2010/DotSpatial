// ********************************************************************************************************
// Product Name: DotSpatial.Symbology.Forms.dll
// Description:  The core assembly for the DotSpatial 6.0 distribution.
// ********************************************************************************************************
//
// The Original Code is DotSpatial.dll
//
// The Initial Developer of this Original Code is Ted Dunsford. Created 5/14/2009 1:57:07 PM
//
// Contributor(s): (Open source contributors should list themselves and their modifications here).
//
// ********************************************************************************************************

using System;
using System.Windows.Forms;
using DotSpatial.Serialization;

namespace DotSpatial.Symbology.Forms
{
    /// <summary>
    /// Size2DDialog
    /// </summary>
    public class Size2DDialog : Form
    {
        #region Events

        /// <summary>
        /// Occurs whenever the apply changes button is clicked, or else when the ok button is clicked.
        /// </summary>
        public event EventHandler ChangesApplied;

        #endregion

        #region Private Variables

        private Size2D _editValue;
        private ISymbol _original;
        private DoubleBox dbxHeight;
        private DoubleBox dbxWidth;
        private DialogButtons dialogButtons1;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Size2DDialog));
            this.dialogButtons1 = new DotSpatial.Symbology.Forms.DialogButtons();
            this.dbxHeight = new DotSpatial.Symbology.Forms.DoubleBox();
            this.dbxWidth = new DotSpatial.Symbology.Forms.DoubleBox();
            this.SuspendLayout();
            // 
            // dialogButtons1
            // 
            resources.ApplyResources(this.dialogButtons1, "dialogButtons1");
            this.dialogButtons1.Name = "dialogButtons1";
            // 
            // dbxHeight
            // 
            resources.ApplyResources(this.dbxHeight, "dbxHeight");
            this.dbxHeight.BackColorInvalid = System.Drawing.Color.Salmon;
            this.dbxHeight.BackColorRegular = System.Drawing.Color.Empty;
            this.dbxHeight.InvalidHelp = "The value entered could not be correctly parsed into a valid double precision flo" +
    "ating point value.";
            this.dbxHeight.IsValid = true;
            this.dbxHeight.Name = "dbxHeight";
            this.dbxHeight.NumberFormat = null;
            this.dbxHeight.RegularHelp = "Enter a double precision floating point value.";
            this.dbxHeight.Value = 0D;
            this.dbxHeight.TextChanged += new System.EventHandler(this.dbxHeight_TextChanged);
            // 
            // dbxWidth
            // 
            resources.ApplyResources(this.dbxWidth, "dbxWidth");
            this.dbxWidth.BackColorInvalid = System.Drawing.Color.Salmon;
            this.dbxWidth.BackColorRegular = System.Drawing.Color.Empty;
            this.dbxWidth.InvalidHelp = "The value entered could not be correctly parsed into a valid double precision flo" +
    "ating point value.";
            this.dbxWidth.IsValid = true;
            this.dbxWidth.Name = "dbxWidth";
            this.dbxWidth.NumberFormat = null;
            this.dbxWidth.RegularHelp = "Enter a double precision floating point value.";
            this.dbxWidth.Value = 0D;
            this.dbxWidth.TextChanged += new System.EventHandler(this.dbxWidth_TextChanged);
            // 
            // Size2DDialog
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dialogButtons1);
            this.Controls.Add(this.dbxHeight);
            this.Controls.Add(this.dbxWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Size2DDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of CollectionPropertyGrid
        /// </summary>
        public Size2DDialog()
        {
            InitializeComponent();
            Configure();
        }

        /// <summary>
        /// Creates a Size2DDialog with a specific symbol to edit when "Apply Changes" is clicked
        /// </summary>
        /// <param name="symbol"></param>
        public Size2DDialog(ISymbol symbol)
        : this()
        {
            _original = symbol;
            _editValue = _original.Size.Copy();
            dbxHeight.Value = _editValue.Height;
            dbxWidth.Value = _editValue.Width;
        }

        private void Configure()
        {
            dialogButtons1.OkClicked += cmdOk_Click;
            dialogButtons1.CancelClicked += btnCancel_Click;
            dialogButtons1.ApplyClicked += btnApply_Click;
        }

        #endregion

        #region Methods

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the symbol that should be edited whenever apply changes is clicked.
        /// </summary>
        public ISymbol Symbol
        {
            get { return _original; }
            set
            {
                _original = value;
                _editValue = _original.Size.Copy();
                dbxHeight.Value = _editValue.Height;
                dbxWidth.Value = _editValue.Width;
            }
        }

        #endregion

        #region Events

        #endregion

        #region Event Handlers

        private void dbxWidth_TextChanged(object sender, EventArgs e)
        {
            _editValue.Width = dbxWidth.Value;
        }

        private void dbxHeight_TextChanged(object sender, EventArgs e)
        {
            _editValue.Height = dbxHeight.Value;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            _original.Size = _editValue.Copy();
            OnApplyChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            _original.Size = _editValue.Copy();
            OnApplyChanges();
            Close();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Fires the ChangesApplied event
        /// </summary>
        protected virtual void OnApplyChanges()
        {
            if (ChangesApplied != null) ChangesApplied(this, EventArgs.Empty);
        }

        #endregion
    }
}