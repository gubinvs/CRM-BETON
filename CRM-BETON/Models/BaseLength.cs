
namespace CRM_BETON.Models
{
    public class BaseLength
    {
        
        public int СalculateLength()
        {
            // Открыт поток соединения с базой данных
            using (ApplicationContext db = new ApplicationContext())
            {
                int number = db.Orders.Count();

                return number;
            }
            
        }


    }
}

