using Microsoft.AspNetCore.Mvc;
using CRM_BETON.Models;

namespace CRM_BETON.Controllers;

public class HomeController : Controller
{

    // Метод загрузки стартовой страницы
    public IActionResult Index()
    {
        return View();
    }


    // Метод открывает страницу добавления пользователя
    public IActionResult AddUser()
    {
        return View("AddUser");

    }

    // Метод открывает страницу оформления заявки
    public IActionResult Orders()
    {
        return View("Orders");

    }




    // Метод проверки введенных данных пользователя на наличие таких
    // данных в базе данных
    [HttpPost]
    public IActionResult Сheck(string login, string password)
    {

        // Открыт поток соединения с базой данных
        using (ApplicationContext db = new ApplicationContext())
        {
            // Заполняю данные пользователя из формы httpPost
            string userLogin = login;
            string userPassword = password;

            // Извлекаю данные пользователей и базы данных
            var users = db.Users.ToList();

            // Перибираю данные базы на поиск совпадений
            foreach (User u in users)
            {
                // если логин из формы httpPost и пароль из формы httpPost
                // соответствуют такой паре в базе данных то переходим на страницу,
                // если нет открываю снова стартовую страницу
                if (userLogin == u.Login & userPassword == u.Password)
                {
                    return View("Verification");
                }
                else
                {
                    return View("Index");

                }
            }
        }
        return View("Index");
    }


    // Метод добавления пользователя в базу данных
    [HttpPost]
    public IActionResult Registration (string login, string password)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Login = login,
                Password = password

            };

            db.Users.AddRange(user);
            db.SaveChanges();

        }

        return View("Index");

    }

    // Метод добавления заказа в базу данных
    [HttpPost]
    public IActionResult AddNewOrder(string brand, string filler, string amount, DateTime dateDelivery, DateTime timeDelivery, string adressDelivery, int sellingPrice, int priceDelivery, string customer, long contact, string driver, string numberCar)
    {
        int number = new BaseLength().СalculateLength()+1; // Получение длины базы данных и увеличивается значение на один

        using (ApplicationContext db = new ApplicationContext())
        {
            // Создаю новый экземпляр класса
            Order order = new Order
            {
                
                Id = Guid.NewGuid(),            // Создание идентификатора заявки                
                Number = number,
                DateTime = DateTime.Now,        // создание текущей даты оформления заявки
                Brand = brand,
                Filler = filler,
                Amount = amount,
                DateDelivery = dateDelivery,
                TimeDelivery = timeDelivery,
                AdressDelivery = adressDelivery,
                SellingPrice = sellingPrice,
                PriceDelivery = priceDelivery,
                Customer = customer,
                Contact = contact,
                Driver = driver,
                NumberCar = numberCar
            };

            db.Orders.AddRange(order);
            db.SaveChanges();
           
        }

        return View("SentOrder");
        
    }
}

