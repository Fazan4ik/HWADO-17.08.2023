using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO_17._08._2023_1_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private SqlConnection connection;
        public ObservableCollection<String> columns { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            connection = null!;
            this.DataContext = this;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new(App.ConnectionString);
                connection.Open();
                LoadGroups();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

        }

        private void LoadGroups()
        {
            using SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT [id], [name], [price] FROM TableProducts";
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    float price = (float)reader.GetDouble(2); 
                    columns.Add($"Id: {id}, Name: {name}, Price: {price}\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Query error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connection?.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using SqlCommand command = new();
            command.Connection = connection;
            command.CommandText =
                 @"CREATE TABLE TableProducts(
	[id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[category] [nvarchar](50) NULL,
	[price] [float] NULL,
	[discount] [float] NULL,
	[quantity] [int] NULL,
	[measurement] [nvarchar](50) NULL,
	[producer] [nvarchar](50) NULL,
	[country] [nvarchar](50) NULL,
	[supplier] [nvarchar](50) NULL,
	[date_of_delivery] [nvarchar](50) NULL,
	[expire_data] [date] NULL
)";
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Table Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            using SqlCommand command = new();
            command.Connection = connection;
            command.CommandText =
                 @"INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (1, N'`МОХИТО` АРСЕНІЇВСЬКИЙ 1,0 Л', N'Соки і води', 70, 10, 100, N'од', N'АРСЕНІЇВСЬКИЙ ', N'Ukraine', N'Tavria', N'2023-06-06', CAST(N'2024-06-06' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (2, N'САНДОРА 0,95Л ГРАНАТ', N'Соки і води', 500, 10, 25, N'од', N'Сандора', N'Ukraine', N'ObjoraTM', N'2023-05-05', CAST(N'2024-05-05' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (3, N'MULTIVITAMIN CAPRI-SUN 0,2 Л', N'Соки і води', 62, 5, 25, N'од', N'Capri-Sun', N'Ukraine', N'ObjoraTM', N'2023-05-10', CAST(N'2024-05-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (4, N'IFRESH 1,5Л ВИШНЯ', N'Соки і води', 30, 25, 152, N'од', N'Я love Фреш', N'Ukraine', N'ObjoraTM', N'2023-07-07', CAST(N'2024-07-14' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (5, N'JAFFA DETOX (КІВІ ОГІРОК М`ЯТА) 0,5Л', N'Соки і води', 31, 15, 15, N'од', N'Джаффа', N'Ukraine', N'Tavria', N'2023-07-01', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (6, N'JAFFA IMMUNITY (ЛАЙМ ЛИМОН ІМБИР) 0,5Л', N'Соки і води', 32, 25, 252, N'од', N'Джаффа', N'Ukraine', N'ObjoraTM', N'2023-07-07', CAST(N'2024-07-14' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (8, N'CIDO МАНГО 1Л', N'Соки і води', 99, 25, 50, N'од', N'Cido', N'Ukraine', N'Tavria', N'2023-06-14', CAST(N'2024-06-14' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (7, N'CIDO 1,0Л АНАНАСОВИЙ НОВИНКА', N'Соки і води', 84, 10, 252, N'од', N'Cido', N'Ukraine', N'ObjoraTM', N'2023-07-07', CAST(N'2024-07-07' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (9, N'JAFFA 125МЛ MINIONS БАНАНОВО-ПОЛУНИЧНИЙ', N'Соки і води', 12, 0, 55, N'од', N'Джаффа', N'Ukraine', N'ObjoraTM', N'2023-06-20', CAST(N'2024-06-20' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (10, N'БІОЛА 0,5Л АПЕЛЬСИН', N'Соки і води', 28, 0, 60, N'од', N'БІОЛА ', N'Ukraine', N'ObjoraTM', N'2023-06-15', CAST(N'2025-06-15' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (11, N'ЛІТО 1.5Л МУЛЬТИФРУКТ', N'Соки і води', 59, 10, 60, N'од', N'Літо', N'Ukraine', N'Tavria', N'2023-06-20', CAST(N'2024-06-20' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (12, N'ОКЗДХ 0,33Л МУЛЬТИФРУКТ', N'Соки і води', 20, 25, 75, N'од', N'Наш сік', N'Ukraine', N'ObjoraTM', N'2023-06-25', CAST(N'2024-06-25' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (13, N'САДОЧОК 0,95Л АПЕЛЬСИН', N'Соки і води', 58, 10, 100, N'од', N'Садочок', N'Ukraine', N'ObjoraTM', N'2023-06-21', CAST(N'2025-06-21' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (14, N'САНДОРА 0,95Л ВИШНЯ', N'Соки і води', 66, 5, 125, N'од', N'Сандора', N'Ukraine', N'Tavria', N'2023-06-24', CAST(N'2024-11-24' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (15, N'PROTEIN BOOST JAFFA 120 Г', N'Соки і води', 34, 15, 521, N'од', N'Джаффа', N'Ukraine', N'ObjoraTM', N'2023-05-10', CAST(N'2024-05-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (16, N'БУРЯК ВАРЕНИЙ 0,5 КГ
', N'Овочі та фрукти', 49, 0, 232, N'кг', N'ОдесАгр', N'Ukraine', N'ObjoraTM', N'2023-07-11', CAST(N'2023-07-18' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (17, N'КАБАЧКИ', N'Овочі та фрукти', 29, 0, 150, N'кг', N'ОдесАгр', N'Ukraine', N'Tavria', N'2023-07-11', CAST(N'2023-07-18' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (18, N'КАРТОПЛЯ РОЖЕВА МОЛОДА', N'Овочі та фрукти', 44, 0, 100, N'кг', N'МикАгр', N'Ukraine', N'ObjoraTM', N'2023-07-11', CAST(N'2023-07-19' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (19, N'КУКУРУДЗА ЦУКРОВА', N'Овочі та фрукти', 60, 0, 50, N'кг', N'ОдесАгр', N'Ukraine', N'Tavria', N'2023-07-11', CAST(N'2023-07-26' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (20, N'ЦИБУЛЯ МОЛОДА', N'Овочі та фрукти', 45, 50, 25, N'кг', N'ДніпрАгр', N'Ukraine', N'ObjoraTM', N'2023-07-11', CAST(N'2023-08-12' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (21, N'ПЕРЕЦЬ ЧЕРВОНИЙ', N'Овочі та фрукти', 179, 20, 250, N'кг', N'ЧеркасАгр', N'Ukraine', N'Tochka', N'2023-07-11', CAST(N'2023-07-26' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (22, N'ПОМІДОР НА ГIЛЦI', N'Овочі та фрукти', 84, 15, 200, N'кг', N'ХерсонАгр', N'Ukraine', N'Kopiyka', N'2023-07-11', CAST(N'2023-07-19' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (23, N'ПОМІДОРИ СЛИВКА', N'Овочі та фрукти', 85, 0, 150, N'кг', N'ХерсонАгр', N'Ukraine', N'Tochka', N'2023-07-10', CAST(N'2023-07-17' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (24, N'РЕДИС ', N'Овочі та фрукти', 50, 50, 40, N'кг', N'ВінАгр', N'Ukraine', N'ObjoraTM', N'2023-07-11', CAST(N'2023-07-18' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (25, N'ЧАСНИК МОЛОДИЙ', N'Овочі та фрукти', 184, 19, 100, N'кг', N'ОдесАгр', N'Ukraine', N'Tavria', N'2023-06-10', CAST(N'2023-09-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (26, N'COCA-COLA 2 Л
', N'Соки і води', 53, 9, 100, N'од', N'CocaCola', N'Ukraine', N'Tochka', N'2023-05-10', CAST(N'2025-05-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (27, N'PEPSI 1.5 Л', N'Соки і води', 52, 5, 123, N'од', N'PepsiCo', N'Poland', N'Kopiyka', N'2023-04-10', CAST(N'2025-04-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (28, N'SCHWEPPES 0,75Л МОХІТО', N'Соки і води', 33, 0, 100, N'од', N'Schweppes', N'Poland', N'ObjoraTM', N'2023-07-10', CAST(N'2025-07-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (29, N' БОН БУАССОН 1Л ТАРХУН', N'Соки і води', 27, 0, 99, N'од', N'Бон Буассон', N'Ukraine', N'Tavria', N'2023-06-15', CAST(N'2025-07-15' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (30, N'7 UP 2,0Л', N'Соки і води', 58, 10, 51, N'од', N'PepsiCo', N'Poland', N'ObjoraTM', N'2023-06-20', CAST(N'2025-06-20' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (31, N'КАБАНОСИ CУШЕНI З М`ЯСА ПТИЦI CLASSIC 70 Г', N'
Ковбаси копчені', 46, 5, 123, N'од', N'Kabanosy', N'Ukraine', N'Tavria', N'2023-06-20', CAST(N'2023-12-20' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (32, N'КОВБАСА САЛЯМІ ПОКРИТА СУШЕНИМИ ТОМАТАМИ SOKOLOW', N'
Ковбаси копчені', 830, 10, 15, N'кг', N'SOKOLOW', N'Ukraine', N'ObjoraTM', N'2023-06-20', CAST(N'2024-06-20' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (33, N'КОВБАСА ГАРМАШ ІТАЛІЙСЬКА В/Г', N'
Ковбаси копчені', 546, 0, 10, N'кг', N'Гармаш', N'Ukraine', N'Tavria', N'2023-07-05', CAST(N'2024-07-05' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (34, N'КОВБАСА САЛЯМІ В СИРІ SOKOLOW
', N'
Ковбаси копчені', 811, 25, 8, N'кг', N'SOKOLOW', N'Ukraine', N'Kopiyka', N'2023-06-20', CAST(N'2024-06-20' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (35, N'КОВБАСА СПЕЦЦЕХ СЕРВЕЛАТ В/К В/С', N'
Ковбаси копчені', 808, 13, 5, N'кг', N'СПЕЦЦЕХ', N'Ukraine', N'Tochka', N'2023-06-25', CAST(N'2024-06-25' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (36, N'АБРИКОС АНАНАСОВИЙ', N'Овочі та фрукти', 110, 14, 50, N'кг', N'SpainFruits', N'Spain', N'ObjoraTM', N'2023-07-11', CAST(N'2023-07-18' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (37, N'ДИНЯ (ІМПОРТ)', N'Овочі та фрукти', 84, 5, 50, N'кг', N'AzFruits', N'Azerbaijan', N'Tavria', N'2023-07-11', CAST(N'2023-07-26' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (38, N'ПЕРСИК БІЛИЙ ЛЕБІДЬ', N'Овочі та фрукти', 140, 0, 25, N'кг', N'AzFruits', N'Azerbaijan', N'ObjoraTM', N'2023-07-11', CAST(N'2023-07-26' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (39, N'ПЕРСИК ', N'Овочі та фрукти', 70, 0, 30, N'кг', N'ОдесАгр', N'Ukraine', N'ObjoraTM', N'2023-07-11', CAST(N'2023-07-26' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (40, N'ЯБЛУКА ЧОРНИЙ ПРИНЦ', N'Овочі та фрукти', 45, 10, 50, N'кг', N'ОдесАгр', N'Ukraine', N'ObjoraTM', N'2023-07-05', CAST(N'2023-07-19' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (41, N'КОВБАСА ФУЕТ 150Г SOLA COSTA BRAVA
', N'
Ковбаси копчені', 140, 0, 49, N'од', N'Sola', N'Spain', N'Tavria', N'2023-07-10', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (42, N'КОВБАСА VENTULA САЛЯМІ ПОКРИТА ТРАВАМИ
', N'
Ковбаси копчені', 899, 10, 8, N'кг', N'Ventula', N'Italy', N'ObjoraTM', N'2023-05-10', CAST(N'2024-05-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (43, N'КОВБАСА SOLA 250Г LONGANIZA DE PAYES
', N'
Ковбаси копчені', 303, 5, 50, N'од', N'Sola', N'Spain', N'Tavria', N'2023-07-10', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (44, N'КОВБАСА VENTULA ФУЕТ ЕКСТРА З ТРЮФЕЛЕМ
', N'
Ковбаси копчені', 205, 3, 23, N'од', N'Ventula', N'Italy', N'Tochka', N'2023-05-10', CAST(N'2024-05-10' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (45, N'КОВБАСА АЛАН ПРЕЗИДЕНТСЬКА С/В В/С 1/2 В/УП
', N'
Ковбаси копчені', 551, 32, 12, N'кг', N'Алан', N'Ukraine', N'ObjoraTM', N'2023-05-15', CAST(N'2024-05-15' AS Date))

INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (46, N'АПЕЛЬСИНИ ІСПАНІЯ
', N'Овочі та фрукти', 57, 0, 52, N'кг', N'SpainFruits', N'Spain', N'ObjoraTM', N'2023-07-11', CAST(N'2023-07-25' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (47, N'БАНАНИ ВАГ. ЕКВАДОР
', N'Овочі та фрукти', 59, 12, 32, N'кг', N'EcuFruit', N'Ecuador', N'Tavria', N'2023-07-10', CAST(N'2023-07-24' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (48, N'ЛИМОНИ ІСПАНІЯ
', N'Овочі та фрукти', 89, 11, 25, N'кг', N'SpainFruits', N'Spain', N'Kopiyka', N'2023-07-01', CAST(N'2023-07-15' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (49, N'МАНДАРИНЫ ЕГИПЕТ', N'Овочі та фрукти', 79, 9, 23, N'кг', N'EgFruits', N'Egypt', N'ObjoraTM', N'2023-07-05', CAST(N'2023-07-19' AS Date))
INSERT [dbo].[TableProducts] ([id], [name], [category], [price], [discount], [quantity], [measurement], [producer], [country], [supplier], [date_of_delivery], [expire_data]) VALUES (50, N'ЧЕРЕШНЯ БІЛА', N'Овочі та фрукти', 119, 7, 28, N'кг', N'ОдесАгр', N'Ukraine', N'Tavria', N'2023-07-09', CAST(N'2024-07-23' AS Date))
";

            try
            {
                MessageBox.Show("Data inserted");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void GroupCount_Click(object sender, RoutedEventArgs e)
        {
            using SqlCommand command = new();
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(*) FROM TableProducts";
            try
            {
                int cnt = Convert.ToInt32(command.ExecuteScalar());
                MessageBox.Show($"Table has {cnt} rows");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quary error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

/*
 * IF OBJECT_ID(N'dbo.ProductGroups', N'U') IS NOT NULL  
   DROP TABLE [dbo].[ProductGroups];  
GO

 

CREATE TABLE ProductGroups (
    Id            UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Name        NVARCHAR(50)     NOT NULL,
    Description NTEXT            NOT NULL,
    Picture     NVARCHAR(50)     NULL
) ;

 

INSERT INTO ProductGroups
    ( Id, Name,    Description, Picture )
VALUES
( '089015F4-31B5-4F2B-BA05-A813B5419285', N'Інструменти',     N'Ручний інструмент для побутового використання', N'tools.png' ),
( 'A6D7858F-6B75-4C75-8A3D-C0B373828558', N'Офісні товари',   N'Декоративні товари для офісного облаштування', N'office.jpg' ),
( 'DEF24080-00AA-440A-9690-3C9267243C43', N'Вироби зі скла',  N'Творчі вироби зі скла', N'glass.jpg' ),
( '2F9A22BC-43F4-4F73-BAB1-9801052D85A9', N'Вироби з дерева', N'Композиції та декоративні твори з деревини', N'wood.jpg' ),
( 'D6D9783F-2182-469A-BD08-A24068BC2A23', N'Вироби з каменя', N'Корисні та декоративні вироби з натурального каменю', N'stone.jpg' );
*/