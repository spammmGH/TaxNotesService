namespace WindowsFormsClient
{
    partial class FormTripsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewTrips = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.To = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Extra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewTrips
            // 
            this.listViewTrips.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Cost,
            this.From,
            this.To,
            this.Extra});
            this.listViewTrips.Location = new System.Drawing.Point(0, 0);
            this.listViewTrips.Name = "listViewTrips";
            this.listViewTrips.Size = new System.Drawing.Size(272, 249);
            this.listViewTrips.TabIndex = 0;
            this.listViewTrips.UseCompatibleStateImageBehavior = false;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            // 
            // Cost
            // 
            this.Cost.Text = "Cost";
            // 
            // From
            // 
            this.From.Text = "From";
            // 
            // To
            // 
            this.To.Text = "To";
            // 
            // Extra
            // 
            this.Extra.Text = "Extra";
            // 
            // FormTripsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listViewTrips);
            this.Name = "FormTripsList";
            this.Text = "FormTripsList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewTrips;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Cost;
        private System.Windows.Forms.ColumnHeader From;
        private System.Windows.Forms.ColumnHeader To;
        private System.Windows.Forms.ColumnHeader Extra;
    }
}