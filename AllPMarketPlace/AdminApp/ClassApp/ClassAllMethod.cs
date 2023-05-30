using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using AdminApp.ADOApp;
using Microsoft.Win32;

namespace AdminApp.ClassApp
{
    public  class ClassAllMethod
    {
        #region MEssage
        public static void MessageNormal(string body)
        {
            MessageBox.Show(body, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void MessageError(string body)
        {
            MessageBox.Show(body, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion

        public static Users CorrUser { get; set; }
        public static bool Authorization(string Login, string Password)
        {
            var corrUser = App.Connection.Users.Where(z => z.Login == Login && z.Password == Password).FirstOrDefault();
            if (corrUser != null)
            {
                if (corrUser.Role_id == 4)
                {
                    CorrUser = corrUser;
                    MessageNormal("Успешная авторизация");
                    return true;
                }
                else
                {
                    MessageError("Ваша Роль не имет доступа к системе");
                    return false;
                }
            }
            else
            {
                MessageError("Пользователя с подобным логином не найдено");
                return false;
            }
        }
        public static byte[] SelecktPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            byte[] image = null;
            dialog.Filter = "Image files|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
            dialog.ShowDialog();
            try
            {
                image = File.ReadAllBytes(dialog.FileName);
                return image;
            }
            catch
            {
                return null;
            }
        }
        public static BitmapImage ByteToImage(byte[] bytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                BitmapImage image = new BitmapImage(); image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; image.StreamSource = memoryStream;
                image.EndInit(); return image;
            }
        }

        public static List<SplashText> ListSplashGet()
        {
            var list = new List<SplashText>(App.Connection.SplashText.ToList());
            return list;
        }
    }
}
