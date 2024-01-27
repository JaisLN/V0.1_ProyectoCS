namespace Proyecto_CS_Agenda.Views
{
    partial class EditRolContactoView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            txtRolName = new Guna.UI2.WinForms.Guna2TextBox();
            cbRolState = new Guna.UI2.WinForms.Guna2ComboBox();
            lbRolID = new Label();
            label2 = new Label();
            dgvLinkedContacts = new DataGridView();
            txtRolDesc = new RichTextBox();
            label1 = new Label();
            lbContactsLinked = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLinkedContacts).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 3;
            btnSave.CustomizableEdges = customizableEdges1;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(280, 344);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSave.Size = new Size(98, 38);
            btnSave.TabIndex = 0;
            btnSave.Text = "Guardar";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 3;
            btnCancel.CustomizableEdges = customizableEdges3;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.Silver;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(410, 344);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancel.Size = new Size(98, 38);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancelar";
            btnCancel.Click += btnCancel_Click;
            // 
            // txtRolName
            // 
            txtRolName.CustomizableEdges = customizableEdges5;
            txtRolName.DefaultText = "";
            txtRolName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtRolName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtRolName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtRolName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtRolName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRolName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtRolName.ForeColor = Color.Black;
            txtRolName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRolName.Location = new Point(40, 122);
            txtRolName.Name = "txtRolName";
            txtRolName.PasswordChar = '\0';
            txtRolName.PlaceholderText = "Nombre";
            txtRolName.SelectedText = "";
            txtRolName.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtRolName.Size = new Size(315, 41);
            txtRolName.TabIndex = 2;
            // 
            // cbRolState
            // 
            cbRolState.BackColor = Color.Transparent;
            cbRolState.CustomizableEdges = customizableEdges7;
            cbRolState.DrawMode = DrawMode.OwnerDrawFixed;
            cbRolState.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRolState.FocusedColor = Color.FromArgb(94, 148, 255);
            cbRolState.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbRolState.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbRolState.ForeColor = Color.FromArgb(68, 88, 112);
            cbRolState.ItemHeight = 30;
            cbRolState.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cbRolState.Location = new Point(428, 254);
            cbRolState.Name = "cbRolState";
            cbRolState.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbRolState.Size = new Size(314, 36);
            cbRolState.TabIndex = 5;
            // 
            // lbRolID
            // 
            lbRolID.AutoSize = true;
            lbRolID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lbRolID.Location = new Point(40, 48);
            lbRolID.Name = "lbRolID";
            lbRolID.Size = new Size(92, 29);
            lbRolID.TabIndex = 6;
            lbRolID.Text = "Rol ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(428, 231);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 7;
            label2.Text = "Estado";
            // 
            // dgvLinkedContacts
            // 
            dgvLinkedContacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLinkedContacts.Location = new Point(40, 432);
            dgvLinkedContacts.Name = "dgvLinkedContacts";
            dgvLinkedContacts.RowHeadersWidth = 51;
            dgvLinkedContacts.RowTemplate.Height = 29;
            dgvLinkedContacts.Size = new Size(722, 255);
            dgvLinkedContacts.TabIndex = 8;
            // 
            // txtRolDesc
            // 
            txtRolDesc.Location = new Point(40, 214);
            txtRolDesc.Name = "txtRolDesc";
            txtRolDesc.Size = new Size(315, 87);
            txtRolDesc.TabIndex = 9;
            txtRolDesc.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 191);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 10;
            label1.Text = "Descripcion";
            // 
            // lbContactsLinked
            // 
            lbContactsLinked.AutoSize = true;
            lbContactsLinked.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lbContactsLinked.Location = new Point(428, 140);
            lbContactsLinked.Name = "lbContactsLinked";
            lbContactsLinked.Size = new Size(213, 23);
            lbContactsLinked.TabIndex = 11;
            lbContactsLinked.Text = "Total Contactos Asociados:";
            // 
            // EditRolContactoView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 721);
            Controls.Add(lbContactsLinked);
            Controls.Add(label1);
            Controls.Add(txtRolDesc);
            Controls.Add(dgvLinkedContacts);
            Controls.Add(label2);
            Controls.Add(lbRolID);
            Controls.Add(cbRolState);
            Controls.Add(txtRolName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Name = "EditRolContactoView";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvLinkedContacts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2TextBox txtRolName;
        private Guna.UI2.WinForms.Guna2ComboBox cbRolState;
        private Label lbRolID;
        private Label label2;
        private DataGridView dgvLinkedContacts;
        private RichTextBox txtRolDesc;
        private Label label1;
        private Label lbContactsLinked;
    }
}