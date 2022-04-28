namespace amethyst.Data.DataBase
{
    public class MockAllAppeals : IAllAppeals
    {
        public IEnumerable<appeals> Appeals
        {
            get
            {
                return new List<appeals>()
                {
                    new appeals { content = "First"},
                    new appeals { content = "Second"}
                };


            }
            set { }
        }
    }
}
