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
            ParameterBox1 = new Label();
            ParameterBox2 = new Label();
            ParameterBox3 = new Label();
            ParameterBox4 = new Label();
            ParameterBox5 = new Label();
            ParameterBox6 = new Label();
            ShowTableButton = new Button();
            ManyToManyEmployees = new Button();
            ManyToManyRevision = new Button();
            ((System.ComponentModel.ISupportInitialize)OutputBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 2;
            label1.Text = @"InputBoxes";
            // 
            // ManageAreaButton
            // 
            ManageAreaButton.Location = new Point(726, 108);
            ManageAreaButton.Name = "ManageAreaButton";
            ManageAreaButton.Size = new Size(103, 89);
            ManageAreaButton.TabIndex = 3;
            ManageAreaButton.Text = "Manage area";
            ManageAreaButton.UseVisualStyleBackColor = true;
            ManageAreaButton.Click += ManageAreaButton_Click;
            // 
            // ManageEquipmentButton
            // 
            ManageEquipmentButton.Location = new Point(616, 198);
            ManageEquipmentButton.Name = "ManageEquipmentButton";
            ManageEquipmentButton.Size = new Size(104, 89);
            ManageEquipmentButton.TabIndex = 4;
            ManageEquipmentButton.Text = "Manage equipment";
            ManageEquipmentButton.UseVisualStyleBackColor = true;
            ManageEquipmentButton.Click += ManageEquipmentButton_Click;
            // 
            // ManageFailureButton
            // 
            ManageFailureButton.Location = new Point(505, 198);
            ManageFailureButton.Name = "ManageFailureButton";
            ManageFailureButton.Size = new Size(105, 89);
            ManageFailureButton.TabIndex = 5;
            ManageFailureButton.Text = @"Manage failure revisions";
            ManageFailureButton.UseVisualStyleBackColor = true;
            ManageFailureButton.Click += ManageFailureButton_Click;
            // 
            // ManagePlanButton
            // 
            ManagePlanButton.BackColor = Color.White;
            ManagePlanButton.Location = new Point(505, 108);
            ManagePlanButton.Name = "ManagePlanButton";
            ManagePlanButton.Size = new Size(105, 89);
            ManagePlanButton.TabIndex = 6;
            ManagePlanButton.Text = @"Manage plan revision";
            ManagePlanButton.UseVisualStyleBackColor = false;
            ManagePlanButton.Click += ManagePlanButton_Click;
            // 
            // ManageEmployeeButton
            // 
            ManageEmployeeButton.Location = new Point(615, 108);
            ManageEmployeeButton.Name = "ManageEmployeeButton";
            ManageEmployeeButton.Size = new Size(105, 89);
            ManageEmployeeButton.TabIndex = 7;
            ManageEmployeeButton.Text = @"Manage employee";
            ManageEmployeeButton.UseVisualStyleBackColor = true;
            ManageEmployeeButton.Click += ManageEmployeeButton_Click;
            // 
            // FailedEquipmentViewButton
            // 
            FailedEquipmentViewButton.Location = new Point(835, 108);
            FailedEquipmentViewButton.Name = "FailedEquipmentViewButton";
            FailedEquipmentViewButton.Size = new Size(106, 89);
            FailedEquipmentViewButton.TabIndex = 8;
            FailedEquipmentViewButton.Text = "View failed equipment";
            FailedEquipmentViewButton.UseVisualStyleBackColor = true;
            FailedEquipmentViewButton.Click += FailedEquipmentViewButton_Click;
            // 
            // InspectionHistoryViewButton
            // 
            InspectionHistoryViewButton.Location = new Point(835, 198);
            InspectionHistoryViewButton.Name = "InspectionHistoryViewButton";
            InspectionHistoryViewButton.Size = new Size(106, 89);
            InspectionHistoryViewButton.TabIndex = 9;
            InspectionHistoryViewButton.Text = "View inspection history";
            InspectionHistoryViewButton.UseVisualStyleBackColor = true;
            InspectionHistoryViewButton.Click += InspectionHistoryViewButton_Click;
            // 
            // EmployeesViewButton
            // 
            EmployeesViewButton.Location = new Point(726, 198);
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
            Column1.HeaderText = @"Column1";
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
            InputBox4.Location = new Point(39, 242);
            InputBox4.Multiline = true;
            InputBox4.Name = "InputBox4";
            InputBox4.Size = new Size(385, 31);
            InputBox4.TabIndex = 16;
            // 
            // InputBox5
            // 
            InputBox5.Location = new Point(39, 299);
            InputBox5.Multiline = true;
            InputBox5.Name = "InputBox5";
            InputBox5.Size = new Size(385, 31);
            InputBox5.TabIndex = 17;
            // 
            // InputBox6
            // 
            InputBox6.Location = new Point(39, 356);
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
            // ParameterBox1
            // 
            ParameterBox1.AutoSize = true;
            ParameterBox1.Location = new Point(39, 51);
            ParameterBox1.Name = "ParameterBox1";
            ParameterBox1.Size = new Size(109, 20);
            ParameterBox1.TabIndex = 20;
            ParameterBox1.Text = "ParameterBox1";
            // 
            // ParameterBox2
            // 
            ParameterBox2.AutoSize = true;
            ParameterBox2.Location = new Point(41, 108);
            ParameterBox2.Name = "ParameterBox2";
            ParameterBox2.Size = new Size(109, 20);
            ParameterBox2.TabIndex = 21;
            ParameterBox2.Text = "ParameterBox2";
            // 
            // ParameterBox3
            // 
            ParameterBox3.AutoSize = true;
            ParameterBox3.Location = new Point(39, 161);
            ParameterBox3.Name = "ParameterBox3";
            ParameterBox3.Size = new Size(109, 20);
            ParameterBox3.TabIndex = 22;
            ParameterBox3.Text = "ParameterBox3";
            // 
            // ParameterBox4
            // 
            ParameterBox4.AutoSize = true;
            ParameterBox4.Location = new Point(39, 219);
            ParameterBox4.Name = "ParameterBox4";
            ParameterBox4.Size = new Size(109, 20);
            ParameterBox4.TabIndex = 23;
            ParameterBox4.Text = "ParameterBox4";
            // 
            // ParameterBox5
            // 
            ParameterBox5.AutoSize = true;
            ParameterBox5.Location = new Point(39, 276);
            ParameterBox5.Name = "ParameterBox5";
            ParameterBox5.Size = new Size(109, 20);
            ParameterBox5.TabIndex = 24;
            ParameterBox5.Text = "ParameterBox5";
            // 
            // ParameterBox6
            // 
            ParameterBox6.AutoSize = true;
            ParameterBox6.Location = new Point(39, 333);
            ParameterBox6.Name = "ParameterBox6";
            ParameterBox6.Size = new Size(109, 20);
            ParameterBox6.TabIndex = 25;
            ParameterBox6.Text = "ParameterBox6";
            // 
            // ShowTableButton
            // 
            ShowTableButton.Location = new Point(615, 293);
            ShowTableButton.Name = "ShowTableButton";
            ShowTableButton.Size = new Size(214, 86);
            ShowTableButton.TabIndex = 26;
            ShowTableButton.Text = "Show table";
            ShowTableButton.UseVisualStyleBackColor = true;
            ShowTableButton.Click += button1_Click;
            // 
            // ManyToManyEmployees
            // 
            ManyToManyEmployees.Location = new Point(505, 291);
            ManyToManyEmployees.Name = "ManyToManyEmployees";
            ManyToManyEmployees.Size = new Size(105, 88);
            ManyToManyEmployees.TabIndex = 27;
            ManyToManyEmployees.Text = "RevisionEmployees";
            ManyToManyEmployees.UseVisualStyleBackColor = true;
            ManyToManyEmployees.Click += ManyToManyEmployees_Click;
            // 
            // ManyToManyRevision
            // 
            ManyToManyRevision.Location = new Point(835, 293);
            ManyToManyRevision.Name = "ManyToManyRevision";
            ManyToManyRevision.Size = new Size(106, 86);
            ManyToManyRevision.TabIndex = 28;
            ManyToManyRevision.Text = "EmployeeRevisions";
            ManyToManyRevision.UseVisualStyleBackColor = true;
            ManyToManyRevision.Click += ManyToManyRevision_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1107, 716);
            Controls.Add(ManyToManyRevision);
            Controls.Add(ManyToManyEmployees);
            Controls.Add(ShowTableButton);
            Controls.Add(ParameterBox6);
            Controls.Add(ParameterBox5);
            Controls.Add(ParameterBox4);
            Controls.Add(ParameterBox3);
            Controls.Add(ParameterBox2);
            Controls.Add(ParameterBox1);
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
            ((System.ComponentModel.ISupportInitialize)OutputBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void ManagePlanButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using var cmd = new NpgsqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT manage_plan_revision(@action, @revision_id, @revision_date, @revision_result, @fail_reason, @equipment_id)";
                cmd.Parameters.AddWithValue("action", InputBox1.Text);
                cmd.Parameters.AddWithValue("revision_id", Convert.ToInt32(InputBox2.Text));
                cmd.Parameters.AddWithValue("revision_date", DateOnly.Parse(InputBox3.Text));
                cmd.Parameters.AddWithValue("revision_result", Convert.ToBoolean(InputBox4.Text));
                cmd.Parameters.AddWithValue("fail_reason", InputBox5.Text);
                cmd.Parameters.AddWithValue("equipment_id", Convert.ToInt32(InputBox6.Text));
                cmd.ExecuteNonQuery();
            }

            catch (Exception)
            {
                MessageBox.Text = @"Input 6 parameters (string, int, date, bool, string, int)";
            }

        }

        private void ManageEmployeeButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using var cmd = new NpgsqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT manage_employee(@action, @employee_id, @employee_table_num, @employee_fullname, @employee_position)";
                cmd.Parameters.AddWithValue("action", InputBox1.Text);
                cmd.Parameters.AddWithValue("employee_id", Convert.ToInt32(InputBox2.Text));
                cmd.Parameters.AddWithValue("employee_table_num", Convert.ToInt32(InputBox3.Text));
                cmd.Parameters.AddWithValue("employee_fullname", InputBox4.Text);
                cmd.Parameters.AddWithValue("employee_position", InputBox5.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Text = @"Input 5 parameters (string, int, int, string, string)";
            }

        }

        private void ManageAreaButton_Click(object? sender, EventArgs e)
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
            catch (Exception)
            {
                MessageBox.Text = @"Input 4 parameters (string, int, int, string)";
            }

        }

        private void ManageFailureButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using var cmd = new NpgsqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT manage_failure_revision(@action, @revision_id, @revision_date, @fail_reason, @equipment_id)";
                cmd.Parameters.AddWithValue("action", InputBox1.Text);
                cmd.Parameters.AddWithValue("revision_id", Convert.ToInt32(InputBox2.Text));
                cmd.Parameters.AddWithValue("revision_date", DateOnly.Parse(InputBox3.Text));
                cmd.Parameters.AddWithValue("fail_reason", InputBox4.Text);
                cmd.Parameters.AddWithValue("equipment_id", Convert.ToInt32(InputBox5.Text));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Text = @"Input 5 parameters (string, int, date, string, int)";
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
            catch (Exception)
            {
                MessageBox.Text = @"Input 4 parameters (string, string, string, int)";
            }
        }

        private void FailedEquipmentViewButton_Click(object? sender, EventArgs e)
        {
            using var adapter = new NpgsqlDataAdapter("SELECT * FROM view_failed_equipment", _connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OutputBox.DataSource = dataTable;
        }

        private void EmployeesViewButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using var adapter =
                    new NpgsqlDataAdapter("SELECT * FROM view_technical_department_employees(@requested_date)",
                        _connection);
                adapter.SelectCommand.Parameters.AddWithValue("@requested_date", DateOnly.Parse(InputBox1.Text));
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                OutputBox.DataSource = dataTable;
            }
            catch (Exception)
            {
                MessageBox.Text = @"Input 1 parameter (Date)";
            }

        }

        private void InspectionHistoryViewButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using var adapter = new NpgsqlDataAdapter("SELECT * FROM view_equipment_inspection_history(@inventory_number)", _connection);
                adapter.SelectCommand.Parameters.AddWithValue("@inventory_number", Convert.ToInt32(InputBox1.Text));
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                OutputBox.DataSource = dataTable;
            }
            catch (Exception)
            {
                MessageBox.Text = @"Input 1 parameter (int)"; ;
            }
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            MinimumSize = new Size(1080, 1080);
            foreach (Control control in Controls)
            {
                control.Anchor = AnchorStyles.Top;
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            try
            {
                using var adapter = new NpgsqlDataAdapter($"SELECT * FROM {InputBox1.Text}", _connection);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                OutputBox.DataSource = dataTable;
            }
            catch (Exception)
            {
                MessageBox.Text = @"Input name of table.";

            }

        }

        private void ManyToManyEmployees_Click(object? sender, EventArgs e)
        {
            try
            {
                using var adapter = new NpgsqlDataAdapter($"SELECT * FROM many_to_many_revisions(@our_revision_id)", _connection);
                adapter.SelectCommand.Parameters.AddWithValue("@our_revision_id", Convert.ToInt32(InputBox1.Text));
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                OutputBox.DataSource = dataTable;
            }
            catch (Exception)
            {
                MessageBox.Text = @"Input id of revision (int)";
            }
        }

        private void ManyToManyRevision_Click(object? sender, EventArgs e)
        {
            try
            {
                using var adapter = new NpgsqlDataAdapter($"SELECT * FROM many_to_many_employees(@our_employee_id)", _connection);
                adapter.SelectCommand.Parameters.AddWithValue("@our_employee_id", Convert.ToInt32(InputBox1.Text));
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                OutputBox.DataSource = dataTable;
            }
            catch (Exception)
            {
                MessageBox.Text = @"Input id of employee (int)";
            }
        }
    }
}