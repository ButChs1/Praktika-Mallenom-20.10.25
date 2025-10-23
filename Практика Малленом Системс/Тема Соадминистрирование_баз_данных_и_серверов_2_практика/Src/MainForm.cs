using Npgsql;

namespace KeramikDamageControl
{
    public partial class MainForm : Form
    {
        [NonSerialized]
        private string _connectionString = string.Empty; public MainForm()
        {
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы уже находитесь в настройках");
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                MessageBox.Show("Сначала подключитесь к базе данных");
                return;
            }

            var tablesForm = new TablesForm(_connectionString);
            this.Hide();
            tablesForm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                MessageBox.Show("Сначала подключитесь к базе данных");
                return;
            }

            var usersForm = new UsersForm(_connectionString);
            this.Hide();
            usersForm.Show();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _connectionString = $"Host={HostText.Text};Port={int.Parse(PortText.Text)};Database={DatabaseText.Text};Username={UsernameText.Text};Password={PasswordText.Text};Timeout=30";

                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                MessageBox.Show("Подключение успешно!");
                conn.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Порт должен быть числом!");
                _connectionString = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
                _connectionString = string.Empty;
            }
        }
    }
}