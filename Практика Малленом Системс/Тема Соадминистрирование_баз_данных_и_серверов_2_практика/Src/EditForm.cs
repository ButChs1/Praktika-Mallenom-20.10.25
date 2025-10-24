using System.Data;
using Npgsql;

namespace KeramikDamageControl
{
    public partial class EditForm : Form
    {
        private string _connectionString;
        private string _tableName;
        private DataRow _row;

        public EditForm(string connectionString, string tableName, DataRow row)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _tableName = tableName;
            _row = row;
            LoadRowData();
        }

        private void LoadRowData()
        {
            try
            {
                var table = new DataTable();

                foreach (DataColumn col in _row.Table.Columns)
                {
                    table.Columns.Add(col.ColumnName, col.DataType);
                }

                table.ImportRow(_row);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                {
                    UpdateTableRecord(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void UpdateTableRecord(NpgsqlConnection conn)
        {
            var cmd = new NpgsqlCommand();
            var setClause = "";
            var whereClause = "";

            foreach (DataGridViewCell cell in dataGridView1.Rows[0].Cells)
            {
                string columnName = dataGridView1.Columns[cell.ColumnIndex].Name;
                setClause += $"{columnName} = @new_{columnName}, ";
                cmd.Parameters.AddWithValue($"@new_{columnName}", cell.Value ?? DBNull.Value);
            }
            setClause = setClause.TrimEnd(',', ' ');

            foreach (DataColumn col in _row.Table.Columns)
            {
                whereClause += $"{col.ColumnName} = @old_{col.ColumnName} AND ";
                cmd.Parameters.AddWithValue($"@old_{col.ColumnName}", _row[col]);
            }
            whereClause = whereClause.Remove(whereClause.Length - 5);

            cmd.CommandText = $"UPDATE {_tableName} SET {setClause} WHERE {whereClause}";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}