namespace amethyst.Data.DataBase
{
    public class AppealRepository : IAllAppeals
    {
        private readonly DBContent con;

        public AppealRepository(DBContent cont)
        {
            con = cont;
        }

        public IEnumerable<appeals> Appeals => con.appeals.ToList();
    }

    public class UsersRepository : IAllUsers
    {
        private readonly DBContent cont;
        public UsersRepository(DBContent cont)
        {
            this.cont = cont;
        }
        public IEnumerable<users> Users => cont.users.ToList();

        public bool checkUser(users user)
        {
            foreach (users db_user in cont.users.ToList())
            {
                if (db_user.login == user.login && db_user.password == user.password) return true;
            }
            return false;
        }
    }

    public class RegisterRepository : IRegisterNewUser
    {
        private readonly DBContent cont;
        public RegisterRepository(DBContent cont)
        {
            this.cont = cont;
        }

        public IEnumerable<employee> Employees => cont.employee.ToList();


        public void RegisterNewUser(employee empl)
        {

            cont.employee.Add(empl);
            cont.SaveChanges();
        }

    }

    public class NewAccount : INewAccount
    {
        private readonly DBContent con;

        public string UIE { get => UIE; set => UIE = value;} 
        public string Login { get => Login; set => Login = value;}
        public string Password  { get => Password; set => Password = value;}

        public NewAccount(DBContent con)
        {
            this.con = con;
        }

        public void RegisterNewAccount()
        {
            con.users.Add(new users { person_id = con.employee.FirstOrDefault(e => e.uie == UIE).id, admission_id = 1, login = Login, password = Password });
            con.SaveChanges();
        }
    }

}
