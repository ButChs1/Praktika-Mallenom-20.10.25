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

                if (_tableName == "pg_user")
                {
                    UpdateUser(conn);
                }
                else
                {
                    UpdateTableRecord(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void UpdateUser(NpgsqlConnection conn)
        {
            string oldUsername = _row["usename"].ToString();
            string newUsername = oldUsername;
            bool isSuperuser = false;
            bool canCreateDB = false;
            bool canReplicate = false;

            if (dataGridView1.Rows.Count > 0)
            {
                var row = dataGridView1.Rows[0];

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null) continue;

                    string columnName = dataGridView1.Columns[cell.ColumnIndex].Name;
                    string value = cell.Value.ToString();

                    switch (columnName)
                    {
                        case "usename": newUsername = value; break;
                        case "usesuper": bool.TryParse(value, out isSuperuser); break;
                        case "usecreatedb": bool.TryParse(value, out canCreateDB); break;
                        case "userepl": bool.TryParse(value, out canReplicate); break;
                    }
                }
            }

            try
            {
                if (oldUsername != newUsername && !string.IsNullOrEmpty(newUsername))
                {
                    using var cmdRename = new NpgsqlCommand($"ALTER USER {oldUsername} RENAME TO {newUsername}", conn);
                    cmdRename.ExecuteNonQuery();
                }

                string sqlPrivileges = $"ALTER USER {newUsername} WITH ";
                sqlPrivileges += isSuperuser ? "SUPERUSER " : "NOSUPERUSER ";
                sqlPrivileges += canCreateDB ? "CREATEDB " : "NOCREATEDB ";
                sqlPrivileges += canReplicate ? "REPLICATION" : "NOREPLICATION";

                using var cmd = new NpgsqlCommand(sqlPrivileges, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Данные пользователя изменены!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка изменения пользователя: {ex.Message}");
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