using API;
using Microsoft.EntityFrameworkCore;

namespace GUI
{


    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string date = calendar.SelectionStart.ToString("yyyy-MM-dd");
                textBoxDate.Text = date;
                string currency = textBoxCurrency.Text.ToUpper();

                using (var currencies = new Currencies())
                {
                    var existingCurrency = await currencies.Kantor.FirstOrDefaultAsync(c => c.Name == currency && c.Date == date);
                    if (existingCurrency != null)
                    {
                        listBoxCurrencyInfo.Items.Clear();
                        listBoxCurrencyInfo.Items.Add(existingCurrency.ToString());
                        MessageBox.Show("Currency was in database");
                        return;
                    }
                    else
                    {
                        Converter converter = new Converter();
                        Currency currencyInfo = await converter.GetCurrencyInfo(date, currency);
                        if (currencyInfo != null)
                        {
                            listBoxCurrencyInfo.Items.Clear();
                            listBoxCurrencyInfo.Items.Add(currencyInfo.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Currency data not found.");
                        }
                    }
                }
                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void buttonDownloadFromDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                using (var currencies = new Currencies())
                {
                    if (!await currencies.Database.CanConnectAsync())
                    {
                        await currencies.Database.MigrateAsync();
                    }

                    var data = await currencies.Kantor.ToListAsync();
                    if (data.Any())
                    {
                        listBoxCurrencyInfo.Items.Clear();
                        foreach (var currency in data)
                        {
                            listBoxCurrencyInfo.Items.Add(currency.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("No currency data found in the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            calendar.SetDate(DateTime.Today);
            comboBox1.Items.Add("Name");
            comboBox1.Items.Add("Value");
            comboBox1.Items.Add("Date");
            comboBox1.SelectedIndex = 0;
        }
        private async void AddToBase(object sender, EventArgs e)
        {
            try
            {
                string date = calendar.SelectionStart.ToString("yyyy-MM-dd");
                string currency = textBoxCurrency.Text.ToUpper();

                Converter converter = new Converter();
                Currency currencyInfo = await converter.GetCurrencyInfo(date, currency);

                if (currencyInfo != null)
                {
                    using (var currencies = new Currencies())
                    {
                        currencies.Kantor.Add(currencyInfo);
                        await currencies.SaveChangesAsync();
                    }
                    MessageBox.Show("Currency added to the database.");
                }
                else
                {
                    MessageBox.Show("Currency data not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void SortButton(object sender, EventArgs e)
        {
            try
            {
                string sortBy = comboBox1.SelectedItem.ToString();

                using (var currencies = new Currencies())
                {
                    List<Currency> sortedCurrencies = null;

                    switch (sortBy)
                    {
                        case "Name":
                            sortedCurrencies = currencies.GetSortedCurrenciesByName();
                            break;
                        case "Value":
                            sortedCurrencies = currencies.GetSortedCurrenciesByValue();
                            break;
                        case "Date":
                            sortedCurrencies = currencies.GetSortedCurrenciesByDate();
                            break;
                        default:
                            MessageBox.Show("Something went wrong");
                            break;
                    }

                    if (sortedCurrencies != null)
                    {
                        listBoxCurrencyInfo.Items.Clear();
                        foreach (var currency in sortedCurrencies)
                        {
                            listBoxCurrencyInfo.Items.Add(currency.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
