/// <summary>
/// Класс Order содержит структуру данных о заказе
/// </summary>
namespace CRM_BETON.Models
{
    public class Order
    {
        // Идентификатор заказа
        public Guid Id { get; set; }

        // Номер заказа
        public int Number { get; set; }

        // Дата приема заявки
        public DateTime DateTime { get; set; }

        // Марка бетона
        public string? Brand { get; set; }

        // Инертный заполнитель бетона
        public string? Filler { get; set; }

        // Заказанное кол-во бетона
        public string? Amount { get; set; }

        // Дата поставки бетона
        public DateTime? DateDelivery { get; set; }

        // Время поставки бетона
        public DateTime? TimeDelivery { get; set; }

        // Адрес доставки
        public string? AdressDelivery { get; set; }

        // Цена реализации бетона за один м3
        public int? SellingPrice { get; set; }

        // Цена доставки бетона за один рейс
        public int? PriceDelivery { get; set; }

        // Заказчик
        public string? Customer { get; set; }

        // Телефон заказчика
        public long? Contact { get; set; }

        // Водитель
        public string? Driver { get; set; }

        // Номер автомобиля
        public string? NumberCar { get; set; }

    }

}


