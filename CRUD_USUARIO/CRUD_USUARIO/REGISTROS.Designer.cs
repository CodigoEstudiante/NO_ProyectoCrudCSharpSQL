namespace CRUD_USUARIO
{
    partial class REGISTROS
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.datagridPersona = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPersona)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(27, 12);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(144, 23);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // datagridPersona
            // 
            this.datagridPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridPersona.Location = new System.Drawing.Point(27, 41);
            this.datagridPersona.Name = "datagridPersona";
            this.datagridPersona.Size = new System.Drawing.Size(730, 254);
            this.datagridPersona.TabIndex = 1;
            this.datagridPersona.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridPersona_CellContentClick);
            // 
            // REGISTROS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 313);
            this.Controls.Add(this.datagridPersona);
            this.Controls.Add(this.btnNuevo);
            this.Name = "REGISTROS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "REGISTROS";
            this.Load += new System.EventHandler(this.REGISTROS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridPersona)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView datagridPersona;
    }
}