using System.Data;
using System.Text;
using Npgsql;

namespace KeramikDamageControl
{
    public partial class TablesForm : Form
    {
        private string _connectionString;
        private DataTable _currentTable;
        private string _currentTableName;

        public TablesForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            listBoxTables.SelectedIndexChanged += listBoxTables_SelectedIndexChanged;
            LoadTables();
        }

        private void LoadTables()
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                var tables = new DataTable();
                using var cmd = new NpgsqlCommand(
                    "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public' ORDER BY table_name", conn);
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(tables);

                listBoxTables.DataSource = tables;
                listBoxTables.DisplayMember = "table_name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки таблиц: {ex.Message}");
            }
        }

        private void LoadTableData(string tableName)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                _currentTable = new DataTable();
                using var cmd = new NpgsqlCommand($"SELECT * FROM {tableName} LIMIT 1000", conn);
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(_currentTable);

                _currentTableName = tableName;
                dataGridViewTables.DataSource = _currentTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных таблицы {tableName}: {ex.Message}");
            }
        }

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedItem is DataRowView rowView)
            {
                string tableName = rowView["table_name"].ToString();
                LoadTableData(tableName);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var usersForm = new UsersForm(_connectionString);
            this.Close();
            usersForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTables.CurrentRow?.DataBoundItem is DataRowView rowView && !string.IsNullOrEmpty(_currentTableName))
            {
                var editForm = new EditForm(_connectionString, _currentTableName, rowView.Row);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTableData(_currentTableName);
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите таблицу и запись для редактирования");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTables.CurrentRow?.DataBoundItem is not DataRowView rowView)
            {
                MessageBox.Show("Сначала выберите запись для удаления");
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DeleteRecord(rowView.Row);
                    LoadTableData(_currentTableName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}");
                }
            }
        }

        private void DeleteRecord(DataRow row)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var whereClause = new StringBuilder();
            var parameters = new List<NpgsqlParameter>();

            foreach (DataColumn column in _currentTable.Columns)
            {
                if (whereClause.Length > 0)
                    whereClause.Append(" AND ");

                whereClause.Append($"{column.ColumnName} = @{column.ColumnName}");
                parameters.Add(new NpgsqlParameter($"@{column.ColumnName}", row[column] ?? DBNull.Value));
            }

            using var cmd = new NpgsqlCommand($"DELETE FROM {_currentTableName} WHERE {whereClause}", conn);
            cmd.Parameters.AddRange(parameters.ToArray());
            cmd.ExecuteNonQuery();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTableName))
            {
                MessageBox.Show("Сначала выберите таблицу");
                return;
            }

            var addForm = new AddForm(_connectionString, _currentTableName);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadTableData(_currentTableName);
            }
        }

        private void ShowMainForm()
        {
            var mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault() ?? new MainForm();
            mainForm.Show();
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
            base.OnFormClosed(e);
        }
    }
}