using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CsvHelper.Configuration.Attributes;
using House23.Logic.DataBase;

namespace House23.Logic.Utils
{
    public class FlatConvert
    {
        [Name("Identifier")]
        [Index(0)]
        public int IdFlat { get; set; }
        [Index(1)]
        public int BuildingNumberOfRoom { get; set; }
        [Index(2)]
        public decimal Price { get; set; }
        [Index(3)]
        public int NumberOfRooms { get; set; }
        [Index(4)]
        public int Area { get; set; }
        [Index(5)]
        public int FloorNumber { get; set; }
        [Index(6)]
        public int EntranceNumber { get; set; }
        [Index(7)]
        public string SkyscraperName{ get; set; }

        public FlatConvert(Flat flat)
        {
            IdFlat = flat.IdFlat;
            BuildingNumberOfRoom = flat.BuildingNumberOfRoom;
            Price = flat.Price;
            NumberOfRooms = flat.NumberOfRooms;
            Area = flat.Area;
            FloorNumber = flat.FloorNumber;
            EntranceNumber = flat.EntranceNumber;
            SkyscraperName = flat.Skyscraper.Name;
        }
    }
}