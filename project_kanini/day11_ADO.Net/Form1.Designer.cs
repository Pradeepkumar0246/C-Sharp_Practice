using System.Windows.Forms;

namespace ProductManagerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private Label lblPrice;
        private Label lblQuantity;
        private Label lblSearch;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnDisplay;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCount;
        private DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1062, 253);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
    }
}
