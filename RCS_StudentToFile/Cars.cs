using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_CarListJson
{
    class Car
    {
        public string Type;
        public string Model;
        public string Color;
        public string Status;

        public Car(string type, string model, string color, string status)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.Status = status;
        }
    }

    //public enum CarStatus {InStock, Dispatched, Sold};
}
