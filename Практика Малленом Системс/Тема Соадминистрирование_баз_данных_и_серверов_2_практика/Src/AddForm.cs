using System.Data;
using Npgsql;

namespace KeramikDamageControl
{
    public partial class AddForm : Form
    {
        private string _connectionString;
        private string _tableName;

        public AddForm(string connectionString, string tableName)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _tableName = tableName;
            LoadTableStructure();
        }

        private void LoadTableStructure()
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                var table = new DataTable();
                using var cmd = new NpgsqlCommand($"SELECT * FROM {_tableName} LIMIT 0", conn);
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(table);

                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = true;

                if (dataGridView1.Rows.Count == 0)
                {
                    dataGridView1.Rows.Add();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                {
                    AddTableRecord(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void AddTableRecord(NpgsqlConnection conn)
        {
            if (dataGridView1.Rows.Count == 0) return;

            var row = dataGridView1.Rows[0];
            var cmd = new NpgsqlCommand();
            var query = $"INSERT INTO {_tableName} (";
            var values = "VALUES (";
            bool hasData = false;

            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString())) continue;

                string columnName = dataGridView1.Columns[cell.ColumnIndex].Name;
                query += $"{columnName}, ";
                values += $"@{columnName}, ";
                cmd.Parameters.AddWithValue($"@{columnName}", cell.Value);
                hasData = true;
            }

            if (!hasData)
            {
                MessageBox.Show("Нет данных для добавления!");
                return;
            }

            query = query.TrimEnd(',', ' ') + ") " + values.TrimEnd(',', ' ') + ")";
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}