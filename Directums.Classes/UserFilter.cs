using System;
using System.Linq;
using System.Collections.Generic;

namespace Directums.Classes
{
    public class UserFilter
    {
        private List<int> id = new List<int>();
        private bool[] status = new bool[3];

        public UserFilter()
        {
            Clear();
        }

        public void Clear()
        {
            Id.Clear();
            Login = "";
            Email = "";
            Surname = "";
            Name = "";
            Patronymic = "";
            Status[0] = Status[1] = Status[2] = true;
            BornDateFrom = null;
            BornDateTo = null;
        }

        public bool IsEmpty()
        {
            return Id.Count() == 0 && string.IsNullOrWhiteSpace(Login) && string.IsNullOrWhiteSpace(Email) &&
                string.IsNullOrWhiteSpace(Surname) && string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(Patronymic) &&
                Status.Count(x => x) == Status.Length && !BornDateFrom.HasValue && !BornDateTo.HasValue;
        }

        public bool ParseId(string id)
        {
            Id.Clear();

            var result = id.Split(',').Select(x => x.Trim());
            int tmp = 0;

            if (result.Count(x => string.IsNullOrEmpty(x) || !int.TryParse(x, out tmp)) > 0)
            {
                return false;
            }

            foreach (string item in result)
            {
                Id.Add(int.Parse(item));
            }

            return true;
        }

        public string IdToStr()
        {
            return string.Join(", ", Id.ToArray());
        }

        public List<int> Id
        {
            get { return id; }
        }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public bool[] Status
        {
            get { return status; }
        }
        public DateTime? BornDateFrom { get; set; }
        public DateTime? BornDateTo { get; set; }
    }
}