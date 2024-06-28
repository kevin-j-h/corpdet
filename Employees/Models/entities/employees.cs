namespace Employees.Models.entities
{
    public class employees
    {
        public Guid Id { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string date_of_birth { get; set; }
        public string date_of_hire { get; set; }

        public int deptid { get; set; }
        public string position { get; set; }


    }
}
