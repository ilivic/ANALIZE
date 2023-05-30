using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using SalesManApp.ADOApp;

namespace SalesManApp.ClassApp
{
    public class ClassAllMethod
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
                var SelCorr = App.Connection.UsersPM.Where(z=>z.User_id == corrUser.id_User).First();
                if (corrUser.Role_id == 2 && SelCorr.IsBlock == false)
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
