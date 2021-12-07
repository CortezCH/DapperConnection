using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperConnection.Models
{
/*    ID int NOT NULL auto_increment primary key,
--     `Name` nvarchar(20) NOT NULL,
--     Price float NOT NULL,
--     IsVegetarian bit,
--     IsHealthy bit,
--     we want it to be a number between 1 and 10, we need to remember that mysql doesn't enfore max
--     SpiceLevel int*/
    public class Dish
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(20, ErrorMessage = "Title must be less than 20 characters")]
        public string Name { get; set; }

        public float Price { get; set; }

        public bool IsVegetarian { get; set; }

        public bool IsHealthy { get; set; }

        //Range works only on numbers and only allows numbers inclusivlet between it's
        //min and max
        [Range(1,10, ErrorMessage = "Spice level needs to be between 1 and 10")]
        public int SpiceLevel { get; set; }
    }
}
