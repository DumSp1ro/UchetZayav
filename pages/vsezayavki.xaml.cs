using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
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
using UchetZayav.models;

namespace UchetZayav.pages
{
    /// <summary>
    /// Логика взаимодействия для vsezayavki.xaml
    /// </summary>
    public partial class vsezayavki : Page
    {
        private ObservableCollection<Zayavka> ZayavkaCollection;
        public vsezayavki()
        {
            InitializeComponent();
            ZayavkaCollection = new ObservableCollection<Zayavka>(uze.GetContext().Zayavka.ToList());
            AllZayav.ItemsSource = ZayavkaCollection;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            // Используем блок using для автоматического освобождения ресурсов после использования контекста
            using (var context = new uze())
            {
                // Перебираем каждый объект Zayavka в коллекции ZayavkaCollection
                foreach (var zayavka in ZayavkaCollection)
                {
                    // Пытаемся найти оригинальную сущность Zayavka в базе данных по её идентификатору
                    var originalZayavka = context.Zayavka.Find(zayavka.ID);
                    // Проверяем, была ли найдена оригинальная сущность Zayavka в базе данных
                    if (originalZayavka != null)
                    {
                        // Если комментарий объекта в коллекции ZayavkaCollection отличается от комментария
                        // оригинального объекта в базе данных, то производим обновление комментария
                        if (originalZayavka.Comment != zayavka.Comment)
                        {
                            // Обновляем комментарий оригинального объекта в базе данных значением комментария 
                            // из объекта Zayavka в коллекции ZayavkaCollection
                            originalZayavka.Comment = zayavka.Comment;
                        }
                    }
                }
                // Сохраняем все внесенные изменения в базе данных
                context.SaveChanges();
            }
        }


    }
}
