using System.Data;
using Npgsql;

namespace KeramikDamageControl
{
    public partial class UsersForm : Form
    {
        private string _connectionString;

        public UsersForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                var usersTable = new DataTable();

                using var cmd = new NpgsqlCommand(
                    "SELECT rolname as usename, rolsuper as usesuper, rolcreatedb as usecreatedb, " +
                    "rolreplication as userepl, oid as usesysid FROM pg_roles " +
                    "WHERE rolname !~ '^pg_' ORDER BY rolname", conn);
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(usersTable);

                dataGridView1.DataSource = usersTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}");
            }
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            var tablesForm = new TablesForm(_connectionString);
            this.Hide();
            tablesForm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is not DataRowView selectedRow)
            {
                MessageBox.Show("Сначала выберите пользователя для удаления");
                return;
            }

            string username = selectedRow["usename"].ToString();

            if (MessageBox.Show($"Вы уверены, что хотите удалить пользователя {username}?",
                "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using var conn = new NpgsqlConnection(_connectionString);
                    conn.Open();
                    using var cmd = new NpgsqlCommand($"DROP USER {username}", conn);
                    cmd.ExecuteNonQuery();
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления пользователя: {ex.Message}");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm(_connectionString, "pg_user");
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is DataRowView selectedRowView)
            {
                var editForm = new EditForm(_connectionString, "pg_user", selectedRowView.Row);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите пользователя для редактирования");
            }
        }

        private void ShowMainForm()
        {
            var mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault() ?? new MainForm();
            mainForm.Show();
            this.Close();
        }
    }
}