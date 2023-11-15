using System.CodeDom;
using Npgsql;
using System.Data;

namespace FactoryDatabase
{
    public partial class Form1 : Form
    {
        private readonly NpgsqlConnection _connection;
        public Form1()
        {
            InitializeComponent();
            _connection = Program.GetConnection();
            _connection.Open();
            foreach (var textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = string.Empty;
            }
            InputBox1.Clear();
            OutputBox.Columns.Clear();
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            ManageAreaButton = new Button();
            ManageEquipmentButton = new Button();
            ManageFailureButton = new Button();
            ManagePlanButton = new Button();
            ManageEmployeeButton = new Button();
            FailedEquipmentViewButton = new Button();
            InspectionHistoryViewButton = new Button();
            EmployeesViewButton = new Button();
            label2 = new Label();
            OutputBox = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            InputBox1 = new TextBox();
            InputBox2 = new TextBox();
            InputBox3 = new TextBox();
            InputBox4 = new TextBox();
            InputBox5 = new TextBox();
            InputBox6 = new TextBox();
            MessageBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)OutputBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 26);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 2;
            label1.Text = "InputBoxes";
            // 
            // ManageAreaButton
            // 
            ManageAreaButton.Anchor = AnchorStyles.Top;
            ManageAreaButton.Location = new Point(743, 142);
            ManageAreaButton.Name = "ManageAreaButton";
            ManageAreaButton.Size = new Size(103, 76);
            ManageAreaButton.TabIndex = 3;
            ManageAreaButton.Text = "Manage area";
            ManageAreaButton.UseVisualStyleBackColor = true;
            ManageAreaButton.Click += ManageAreaButton_Click;
            // 
            // ManageEquipmentButton
            // 
            ManageEquipmentButton.Location = new Point(615, 233);
            ManageEquipmentButton.Name = "ManageEquipmentButton";
            ManageEquipmentButton.Size = new Size(105, 89);
            ManageEquipmentButton.TabIndex = 4;
            ManageEquipmentButton.Text = "Manage equipment";
            ManageEquipmentButton.UseVisualStyleBackColor = true;
            ManageEquipmentButton.Click += ManageEquipmentButton_Click;
            // 
            // ManageFailureButton
            // 
            ManageFailureButton.Location = new Point(504, 233);
            ManageFailureButton.Name = "ManageFailureButton";
            ManageFailureButton.Size = new Size(94, 89);
            ManageFailureButton.TabIndex = 5;
            ManageFailureButton.Text = "Manage failure revisions";
            ManageFailureButton.UseVisualStyleBackColor = true;
            ManageFailureButton.Click += ManageFailureButton_Click;
            // 
            // ManagePlanButton
            // 
            ManagePlanButton.BackColor = Color.White;
            ManagePlanButton.Location = new Point(505, 142);
            ManagePlanButton.Name = "ManagePlanButton";
            ManagePlanButton.Size = new Size(93, 76);
            ManagePlanButton.TabIndex = 6;
            ManagePlanButton.Text = "Manage plan revision";
            ManagePlanButton.UseVisualStyleBackColor = false;
            ManagePlanButton.Click += ManagePlanButton_Click;
            // 
            // ManageEmployeeButton
            // 
            ManageEmployeeButton.Location = new Point(615, 142);
            ManageEmployeeButton.Name = "ManageEmployeeButton";
            ManageEmployeeButton.Size = new Size(105, 76);
            ManageEmployeeButton.TabIndex = 7;
            ManageEmployeeButton.Text = "Manage employee";
            ManageEmployeeButton.UseVisualStyleBackColor = true;
            ManageEmployeeButton.Click += ManageEmployeeButton_Click;
            // 
            // FailedEquipmentViewButton
            // 
            FailedEquipmentViewButton.Location = new Point(883, 142);
            FailedEquipmentViewButton.Name = "FailedEquipmentViewButton";
            FailedEquipmentViewButton.Size = new Size(106, 74);
            FailedEquipmentViewButton.TabIndex = 8;
            FailedEquipmentViewButton.Text = "View failed equipment";
            FailedEquipmentViewButton.UseVisualStyleBackColor = true;
            FailedEquipmentViewButton.Click += FailedEquipmentViewButton_Click;
            // 
            // InspectionHistoryViewButton
            // 
            InspectionHistoryViewButton.Location = new Point(884, 233);
            InspectionHistoryViewButton.Name = "InspectionHistoryViewButton";
            InspectionHistoryViewButton.Size = new Size(105, 89);
            InspectionHistoryViewButton.TabIndex = 9;
            InspectionHistoryViewButton.Text = "View inspection history";
            InspectionHistoryViewButton.UseVisualStyleBackColor = true;
            InspectionHistoryViewButton.Click += InspectionHistoryViewButton_Click;
            // 
            // EmployeesViewButton
            // 
            EmployeesViewButton.Location = new Point(743, 233);
            EmployeesViewButton.Name = "EmployeesViewButton";
            EmployeesViewButton.Size = new Size(103, 89);
            EmployeesViewButton.TabIndex = 10;
            EmployeesViewButton.Text = "View technical department employees";
            EmployeesViewButton.UseVisualStyleBackColor = true;
            EmployeesViewButton.Click += EmployeesViewButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 390);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 11;
            label2.Text = "OutputBox";
            // 
            // OutputBox
            // 
            OutputBox.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OutputBox.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OutputBox.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            OutputBox.Location = new Point(39, 424);
            OutputBox.Name = "OutputBox";
            OutputBox.RowHeadersWidth = 51;
            OutputBox.RowTemplate.Height = 29;
            OutputBox.Size = new Size(950, 264);
            OutputBox.TabIndex = 13;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // InputBox1
            // 
            InputBox1.Location = new Point(39, 74);
            InputBox1.Multiline = true;
            InputBox1.Name = "InputBox1";
            InputBox1.Size = new Size(385, 31);
            InputBox1.TabIndex = 0;
            // 
            // InputBox2
            // 
            InputBox2.Location = new Point(39, 127);
            InputBox2.Multiline = true;
            InputBox2.Name = "InputBox2";
            InputBox2.Size = new Size(385, 31);
            InputBox2.TabIndex = 14;
            // 
            // InputBox3
            // 
            InputBox3.Location = new Point(39, 185);
            InputBox3.Multiline = true;
            InputBox3.Name = "InputBox3";
            InputBox3.Size = new Size(385, 31);
            InputBox3.TabIndex = 15;
            // 
            // InputBox4
            // 
            InputBox4.Location = new Point(39, 233);
            InputBox4.Multiline = true;
            InputBox4.Name = "InputBox4";
            InputBox4.Size = new Size(385, 31);
            InputBox4.TabIndex = 16;
            // 
            // InputBox5
            // 
            InputBox5.Location = new Point(39, 291);
            InputBox5.Multiline = true;
            InputBox5.Name = "InputBox5";
            InputBox5.Size = new Size(385, 31);
            InputBox5.TabIndex = 17;
            // 
            // InputBox6
            // 
            InputBox6.Location = new Point(41, 343);
            InputBox6.Multiline = true;
            InputBox6.Name = "InputBox6";
            InputBox6.Size = new Size(385, 31);
            InputBox6.TabIndex = 18;
            // 
            // MessageBox
            // 
            MessageBox.Enabled = false;
            MessageBox.Location = new Point(605, 34);
            MessageBox.Name = "MessageBox";
            MessageBox.ReadOnly = true;
            MessageBox.Size = new Size(425, 27);
            MessageBox.TabIndex = 19;
            // 
            // Form1
            // 
            ClientSize = new Size(1107, 716);
            Controls.Add(MessageBox);
            Controls.Add(InputBox6);
            Controls.Add(InputBox5);
            Controls.Add(InputBox4);
            Controls.Add(InputBox3);
            Controls.Add(InputBox2);
            Controls.Add(OutputBox);
            Controls.Add(label2);
            Controls.Add(EmployeesViewButton);
            Controls.Add(InspectionHistoryViewButton);
            Controls.Add(FailedEquipmentViewButton);
            Controls.Add(ManageEmployeeButton);
            Controls.Add(ManagePlanButton);
            Controls.Add(ManageFailureButton);
            Controls.Add(ManageEquipmentButton);
            Controls.Add(ManageAreaButton);
            Controls.Add(label1);
            Controls.Add(InputBox1);
            Name = "Form1";
            Load += Form1_Load;
            foreach (Control control in Controls)
            {
                control.Anchor = AnchorStyles.Top;
            }
            ((System.ComponentModel.ISupportInitialize)OutputBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void ManagePlanButton_Click(object sender, EventArgs e)
        {
            try
            {
                using var cmd = new NpgsqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT manage_plan_revision(@action, @revision_id, @revision_date, @revision_result, @fail_reason, @equipment_id)";
                cmd.Parameters.AddWithValue("action", InputBox1.Text);
                cmd.Parameters.AddWithValue("revision_id", InputBox2.Text);
                cmd.Parameters.AddWithValue("revision_date", Convert.ToInt32(InputBox3.Text));
                cmd.Parameters.AddWithValue("revision_result", InputBox4.Text);
                cmd.Parameters.AddWithValue("fail_reason", InputBox5.Text);
                cmd.Parameters.AddWithValue("equipment_id", InputBox6.Text);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Text = $@"{ex.Message}";
            }

        }

        private void ManageEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {

                using var cmd = new NpgsqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT manage_area(@action, @employee_id, @employee_table_num, @employee_fullname, @employee_position)";
                cmd.Parameters.AddWithValue("action", InputBox1.Text);
                cmd.Parameters.AddWithValue("employee_id", InputBox2.Text);
                cmd.Parameters.AddWithValue("employee_table_num", Convert.ToInt32(InputBox3.Text));
                cmd.Parameters.AddWithValue("employee_fullname", InputBox4.Text);
                cmd.Parameters.AddWithValue("employee_position", InputBox5.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Text = $@"{ex.Message}";
            }

        }

        private void ManageAreaButton_Click(object sender, EventArgs e)
        {
            try
            {
                using var cmd = new NpgsqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT manage_area(@action, @area_id, @area_number, @area_name)";
                cmd.Parameters.AddWithValue("action", InputBox1.Text);
                cmd.Parameters.AddWithValue("area_id", Convert.ToInt32(InputBox2.Text));
                cmd.Parameters.AddWithValue("area_number", Convert.ToInt32(InputBox3.Text));
                cmd.Parameters.AddWithValue("area_name", InputBox4.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Text = $@"{ex.Message}";
            }

        }

        private void ManageFailureButton_Click(object sender, EventArgs e)
        {
            try
            {
                using var cmd = new NpgsqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT manage_failure_revision(@action, @revision_id, @revision_date, @fail_reason, @equipment_id)";
                cmd.Parameters.AddWithValue("action", InputBox1.Text);
                cmd.Parameters.AddWithValue("revision_id", InputBox2.Text);
                cmd.Parameters.AddWithValue("revision_date", Convert.ToInt32(InputBox3.Text));
                cmd.Parameters.AddWithValue("fail_reason", InputBox4.Text);
                cmd.Parameters.AddWithValue("equipment_id", InputBox5.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Text = $@"{ex.Message}";
            }
        }

        private void ManageEquipmentButton_Click(object? sender, EventArgs e)
        {
            try
            {

                using var cmd = new NpgsqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT manage_equipment(@action, @equipment_type, @equipment_name, @area_id)";
                cmd.Parameters.AddWithValue("action", InputBox1.Text);
                cmd.Parameters.AddWithValue("equipment_type", InputBox2.Text);
                cmd.Parameters.AddWithValue("equipment_name", InputBox3.Text);
                cmd.Parameters.AddWithValue("area_id", Convert.ToInt32(InputBox4.Text));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Text = $@"{ex.Message}";
            }
        }

        private void FailedEquipmentViewButton_Click(object sender, EventArgs e)
        {
            using var adapter = new NpgsqlDataAdapter("SELECT * FROM view_failed_equipment", _connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OutputBox.DataSource = dataTable;
        }

        private void EmployeesViewButton_Click(object sender, EventArgs e)
        {
            using var adapter = new NpgsqlDataAdapter("SELECT * FROM view_technical_department_employees", _connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OutputBox.DataSource = dataTable;

        }

        private void InspectionHistoryViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                using var adapter = new NpgsqlDataAdapter("SELECT * FROM view_equipment_inspection_history(@inventory_number)", _connection);
                adapter.SelectCommand.Parameters.AddWithValue("@inventory_number", Convert.ToInt32(InputBox1.Text));
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                OutputBox.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Text = $@"{ex.Message}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MinimumSize = new Size(1080, 1080);
        }
    }
}