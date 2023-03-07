using SQLite;
using People.Models;
namespace People
{
    public class PersonRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        // TODO: Add variable for the SQLite connection
        
        private SQLiteConnection conn;
        private void Init()
        {
            // TODO: Add code to initialize the repository
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Person>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                // enter this line
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // enter this line
                result = conn.Insert(new Person { Name = name });

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // TODO: Insert the new person into the database
                result = 0;

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public List<Person> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }
    }
}
