using System.Collections.Generic;

namespace CarObjects
{
    public class Cars : List<Car>
    {
        public Cars(string stringText)
        {
            Car car;
            car = new Car("Honda", "NSX GT", 2003, "https://www.telerik.com/images/reporting/cars/NSXGT_7.jpg"
                , new string[] { "Black", "Red", "White", "Orange" });
            this.Add(car);
            car = new Car("Nissan", "Skyline R34 GT-R", 2005, "https://www.telerik.com/images/reporting/cars/EVLR34_1.jpg"
                , new string[] { "Black", "White" });
            this.Add(car);
        }
    }
}