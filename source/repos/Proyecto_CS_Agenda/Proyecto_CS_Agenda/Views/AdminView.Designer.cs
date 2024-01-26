namespace Proyecto_CS_Agenda.Views
{
    partial class AdminView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tabctrlAdmin = new Guna.UI2.WinForms.Guna2TabControl();
            tPageGestionRol = new TabPage();
            label3 = new Label();
            txtbContactRolDesc = new RichTextBox();
            btnDeleteRol = new Guna.UI2.WinForms.Guna2Button();
            btnEditRol = new Guna.UI2.WinForms.Guna2Button();
            btnAddRol = new Guna.UI2.WinForms.Guna2Button();
            cbContactRolState = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            txtbContactRolName = new Guna.UI2.WinForms.Guna2TextBox();
            dgvListSystemRol = new DataGridView();
            label1 = new Label();
            tPageGestionEmpleados = new TabPage();
            tabctrlAdmin.SuspendLayout();
            tPageGestionRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListSystemRol).BeginInit();
            SuspendLayout();
            // 
            // tabctrlAdmin
            // 
            tabctrlAdmin.Alignment = TabAlignment.Left;
            tabctrlAdmin.Controls.Add(tPageGestionRol);
            tabctrlAdmin.Controls.Add(tPageGestionEmpleados);
            tabctrlAdmin.ItemSize = new Size(180, 40);
            tabctrlAdmin.Location = new Point(0, 1);
            tabctrlAdmin.Name = "tabctrlAdmin";
            tabctrlAdmin.SelectedIndex = 0;
            tabctrlAdmin.Size = new Size(1183, 664);
            tabctrlAdmin.TabButtonHoverState.BorderColor = Color.Empty;
            tabctrlAdmin.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            tabctrlAdmin.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tabctrlAdmin.TabButtonHoverState.ForeColor = Color.White;
            tabctrlAdmin.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            tabctrlAdmin.TabButtonIdleState.BorderColor = Color.Empty;
            tabctrlAdmin.TabButtonIdleState.FillColor = Color.FromArgb(33, 42, 57);
            tabctrlAdmin.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tabctrlAdmin.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            tabctrlAdmin.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            tabctrlAdmin.TabButtonSelectedState.BorderColor = Color.Empty;
            tabctrlAdmin.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            tabctrlAdmin.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tabctrlAdmin.TabButtonSelectedState.ForeColor = Color.White;
            tabctrlAdmin.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            tabctrlAdmin.TabButtonSize = new Size(180, 40);
            tabctrlAdmin.TabIndex = 0;
            tabctrlAdmin.TabMenuBackColor = Color.FromArgb(33, 42, 57);
            // 
            // tPageGestionRol
            // 
            tPageGestionRol.Controls.Add(label3);
            tPageGestionRol.Controls.Add(txtbContactRolDesc);
            tPageGestionRol.Controls.Add(btnDeleteRol);
            tPageGestionRol.Controls.Add(btnEditRol);
            tPageGestionRol.Controls.Add(btnAddRol);
            tPageGestionRol.Controls.Add(cbContactRolState);
            tPageGestionRol.Controls.Add(label2);
            tPageGestionRol.Controls.Add(txtbContactRolName);
            tPageGestionRol.Controls.Add(dgvListSystemRol);
            tPageGestionRol.Controls.Add(label1);
            tPageGestionRol.Location = new Point(184, 4);
            tPageGestionRol.Name = "tPageGestionRol";
            tPageGestionRol.Padding = new Padding(3);
            tPageGestionRol.Size = new Size(995, 656);
            tPageGestionRol.TabIndex = 0;
            tPageGestionRol.Text = "Gestion de Roles";
            tPageGestionRol.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(609, 166);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 11;
            label3.Text = "Decripcion";
            // 
            // txtbContactRolDesc
            // 
            txtbContactRolDesc.Location = new Point(609, 189);
            txtbContactRolDesc.Name = "txtbContactRolDesc";
            txtbContactRolDesc.Size = new Size(298, 100);
            txtbContactRolDesc.TabIndex = 10;
            txtbContactRolDesc.Text = "";
            // 
            // btnDeleteRol
            // 
            btnDeleteRol.BorderRadius = 3;
            btnDeleteRol.CustomizableEdges = customizableEdges1;
            btnDeleteRol.DisabledState.BorderColor = Color.DarkGray;
            btnDeleteRol.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDeleteRol.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDeleteRol.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDeleteRol.FillColor = Color.Tomato;
            btnDeleteRol.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteRol.ForeColor = Color.White;
            btnDeleteRol.Location = new Point(156, 421);
            btnDeleteRol.Name = "btnDeleteRol";
            btnDeleteRol.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDeleteRol.Size = new Size(98, 38);
            btnDeleteRol.TabIndex = 8;
            btnDeleteRol.Text = "Eliminar";
            btnDeleteRol.Click += btnDeleteRol_Click;
            // 
            // btnEditRol
            // 
            btnEditRol.BorderRadius = 3;
            btnEditRol.CustomizableEdges = customizableEdges3;
            btnEditRol.DisabledState.BorderColor = Color.DarkGray;
            btnEditRol.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditRol.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditRol.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditRol.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditRol.ForeColor = Color.White;
            btnEditRol.Location = new Point(25, 421);
            btnEditRol.Name = "btnEditRol";
            btnEditRol.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEditRol.Size = new Size(98, 38);
            btnEditRol.TabIndex = 7;
            btnEditRol.Text = "Editar";
            btnEditRol.Click += btnEditRol_Click;
            // 
            // btnAddRol
            // 
            btnAddRol.BorderRadius = 3;
            btnAddRol.CustomizableEdges = customizableEdges5;
            btnAddRol.DisabledState.BorderColor = Color.DarkGray;
            btnAddRol.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddRol.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddRol.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddRol.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddRol.ForeColor = Color.White;
            btnAddRol.Location = new Point(708, 401);
            btnAddRol.Name = "btnAddRol";
            btnAddRol.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAddRol.Size = new Size(98, 38);
            btnAddRol.TabIndex = 6;
            btnAddRol.Text = "Agregar";
            btnAddRol.Click += btnAddRol_Click;
            // 
            // cbContactRolState
            // 
            cbContactRolState.BackColor = Color.Transparent;
            cbContactRolState.CustomizableEdges = customizableEdges7;
            cbContactRolState.DrawMode = DrawMode.OwnerDrawFixed;
            cbContactRolState.DropDownStyle = ComboBoxStyle.DropDownList;
            cbContactRolState.FocusedColor = Color.FromArgb(94, 148, 255);
            cbContactRolState.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbContactRolState.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbContactRolState.ForeColor = Color.FromArgb(68, 88, 112);
            cbContactRolState.ItemHeight = 30;
            cbContactRolState.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cbContactRolState.Location = new Point(609, 333);
            cbContactRolState.Name = "cbContactRolState";
            cbContactRolState.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbContactRolState.Size = new Size(298, 36);
            cbContactRolState.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(613, 310);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 4;
            label2.Text = "Estado";
            // 
            // txtbContactRolName
            // 
            txtbContactRolName.CustomizableEdges = customizableEdges9;
            txtbContactRolName.DefaultText = "";
            txtbContactRolName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtbContactRolName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtbContactRolName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtbContactRolName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtbContactRolName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbContactRolName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtbContactRolName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbContactRolName.Location = new Point(609, 107);
            txtbContactRolName.Name = "txtbContactRolName";
            txtbContactRolName.PasswordChar = '\0';
            txtbContactRolName.PlaceholderText = "Nombre";
            txtbContactRolName.SelectedText = "";
            txtbContactRolName.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtbContactRolName.Size = new Size(298, 39);
            txtbContactRolName.TabIndex = 2;
            // 
            // dgvListSystemRol
            // 
            dgvListSystemRol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListSystemRol.Location = new Point(25, 97);
            dgvListSystemRol.Name = "dgvListSystemRol";
            dgvListSystemRol.RowHeadersWidth = 51;
            dgvListSystemRol.RowTemplate.Height = 29;
            dgvListSystemRol.Size = new Size(534, 306);
            dgvListSystemRol.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(25, 30);
            label1.Name = "label1";
            label1.Size = new Size(180, 29);
            label1.TabIndex = 0;
            label1.Text = "Lista de Roles";
            // 
            // tPageGestionEmpleados
            // 
            tPageGestionEmpleados.Location = new Point(184, 4);
            tPageGestionEmpleados.Name = "tPageGestionEmpleados";
            tPageGestionEmpleados.Padding = new Padding(3);
            tPageGestionEmpleados.Size = new Size(995, 656);
            tPageGestionEmpleados.TabIndex = 1;
            tPageGestionEmpleados.Text = "Gestion de Empleados";
            tPageGestionEmpleados.UseVisualStyleBackColor = true;
            // 
            // AdminView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 662);
            Controls.Add(tabctrlAdmin);
            Name = "AdminView";
            Text = "Admin Menu";
            tabctrlAdmin.ResumeLayout(false);
            tPageGestionRol.ResumeLayout(false);
            tPageGestionRol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListSystemRol).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tabctrlAdmin;
        private TabPage tPageGestionRol;
        private TabPage tPageGestionEmpleados;
        private Label label1;
        private DataGridView dgvListSystemRol;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtbContactRolName;
        private Guna.UI2.WinForms.Guna2ComboBox cbContactRolState;
        private Guna.UI2.WinForms.Guna2Button btnAddRol;
        private Guna.UI2.WinForms.Guna2Button btnDeleteRol;
        private Guna.UI2.WinForms.Guna2Button btnEditRol;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private RichTextBox txtbContactRolDesc;
        private Label label3;
    }
}