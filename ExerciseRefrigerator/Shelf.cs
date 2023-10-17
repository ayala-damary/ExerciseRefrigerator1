using System;
using System.Collections.Generic;
using System.Text;


namespace ExerciseRefrigerator
{
   public class Shelf
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int FreeSpace { get; set; }
        public List<Item> Items { get; set; }
        public Shelf(int id, int floor, int freeSpace)
        {
            Id = id;
            Floor = floor;
            FreeSpace = freeSpace;
            Items = new List<Item>();
        }
  


        public override string ToString()
        {
            return $"Shelf number: {Id}\nFloor: {Floor}\nFree space: {FreeSpace}\n";
        }

    }
}
