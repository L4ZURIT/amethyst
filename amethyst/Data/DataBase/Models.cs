using System.ComponentModel.DataAnnotations;
namespace amethyst.Data.DataBase
{

    public class users
    {
        public int person_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int admission_id { get; set; }

    }

    public class employee
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string fio { get; set; }

        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string uie { get; set; }
    }

    public class claim
    {
        public int appeal_id { get; set; }
    }


    public class sources
    {
        public int id { get; set; }
        public string source_name { get; set; }
    }

    public class phones
    {
        public int id { get; set; }
        public int person_id { get; set; }
        public string phone { get; set; }
        public string note { get; set; }
    }

    public class emails
    {
        public int id { get; set; }
        public int person_id { get; set; }
        public string email { get; set; }
        public string note { get; set; }

    }


    public class webs
    {
        public int id { get; set; }
        public int person_id { get; set; }
        public string web { get; set; }
        public string note { get; set; }

    }


    public class customer
    {
        public int id { get; set; }
        public string fio { get; set; }
        public DateTime appear_date { get; set; }
        public string desc { get; set; }
        public int employee_id { get; set; }
        public int? checked_manager_id { get; set; }
        public int source_id { get; set; }

    }


    public class admission
    {
        public int id { get; set; }
    }

    public class appeals
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public int employee_id { get; set; }
        public int status { get; set; }
        public string content { get; set; }
        public string price { get; set; }
        public DateOnly date { get; set; }
    }

    public class appeal_statuses
    {
        public int id { get; set; }
        public string status { get; set; }
    }

}


