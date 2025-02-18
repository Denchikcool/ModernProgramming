using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneBook;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public UAbonentList contacts;
    public MainWindow()
    {
        //this.Size = new Size(1000, 600);
        InitializeComponent();
        contacts = new UAbonentList();
        contacts.Load();
        UpdateTextBox();
    }

    private void UpdateTextBox()
    {
        richTextBox.Document.Blocks.Clear();
        foreach (KeyValuePair<String, String> kvp in contacts.contactsMap)
        {
            richTextBox.AppendText("Имя: " + kvp.Key + "; \t\t" + "Телефон: " + kvp.Value + ";\v");
        }
    }
    private void Button1_Click(object sender, RoutedEventArgs e)
    {
        contacts.Clear();
        UpdateTextBox();
    }

    private void Button2_Click(object sender, RoutedEventArgs e)
    {
        contacts.Save();
    }

    private void Button3_Click(object sender, RoutedEventArgs e)
    {
        contacts.Remove(textBox1.Text);
        UpdateTextBox();
    }

    private void Button4_Click(object sender, RoutedEventArgs e)
    {
        if (contacts.Edit(textBox1.Text, textBox2.Text))
        {
            textBox1.Clear();
            textBox2.Clear();
            UpdateTextBox();
        }
    }

    private void Button6_Click(object sender, RoutedEventArgs e)
    {
        if (contacts.Insert(textBox1.Text, textBox2.Text))
        {
            textBox1.Clear();
            textBox2.Clear();
            UpdateTextBox();
        }
    }

    private void Button7_Click(object sender, RoutedEventArgs e)
    {
        if (contacts.Find(textBox1.Text, textBox2.Text))
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}