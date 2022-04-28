namespace amethyst.Data.DataBase
{
    public interface IAllAppeals
    {
        IEnumerable<appeals> Appeals { get; }
    }

    public interface IAllUsers
    {
        IEnumerable<users> Users { get; }

        public bool checkUser(users user);
    }

    public interface IRegisterNewUser
    {
        IEnumerable<employee> Employees { get; }

        public void RegisterNewUser(employee empl);
    }


    public interface INewAccount
    {
        public string UIE { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public void RegisterNewAccount();
    }
}
