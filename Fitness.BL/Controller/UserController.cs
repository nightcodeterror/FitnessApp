using Fitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController (string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            // TODO: Проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }

        public UserController()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: Что делать, если пользователя не прочитали?
            }
        }

        /// <summary>
        /// Сохранить данные пользователяю.
        /// </summary>
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using(FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns> Пользователь приложения. </returns>
        
    }
}
