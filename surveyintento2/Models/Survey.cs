using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace surveyintento2.Models
{
    public class Survey
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate {  get; set; }
        public string FavoriteTeam { get; set; }
        public override string ToString()
        {
            return $"{Name} | {Birthdate}| {FavoriteTeam}";
        }
    }
}
