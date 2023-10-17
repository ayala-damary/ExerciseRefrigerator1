using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseRefrigerator
{
    public class Refrigerator
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        private int _numShelves;
        public List<Shelf> Shelves { get; set; }
        public Refrigerator() { 
        
        }
        public Refrigerator(int id, string model, string color, int numShelves)
        {
            Id = id;
            Model = model;
            Color = color;
            NumShelves = numShelves;
            Shelves = new List<Shelf>();
        }
        public int NumShelves
        {
            get
            { return _numShelves; }

            set
            {
                if (value <= 0) throw new Exception("invalide size");
                _numShelves = value;
            }
        }

        //2
        public int GetFreeSpace()
        {
            int freeSpace = 0;
            for (int i = 0; i < NumShelves; i++)
            {
                freeSpace += Shelves[i].FreeSpace;
            }
            return freeSpace;
        }

        //3
        public bool AddItem(Item item)
        {

            if (item.Size > Shelves[item.ShelfId].FreeSpace)
            {
                return false;
            }

            Shelves[item.ShelfId].Items.Add(item);
            Shelves[item.ShelfId].FreeSpace -= item.Size;
            return true;
        }

        //4
        public Item RemoveItem(int itemId)
        {
            Item item = null;

            for (int i = 0; i < Shelves.Count; i++)
            {
                for (int j = 0; j < Shelves[i].Items.Count; j++)
                    if (Shelves[i].Items[j].Id == itemId)
                    {
                        item = Shelves[i].Items[j];
                        break;
                    }
                if (item != null)
                    break;
            }


            if (item != null)
            {
                Shelves[item.ShelfId].Items.Remove(item);
                Shelves[item.ShelfId].FreeSpace += item.Size;
            }

            return item;
        }


        //5*
        public void CleanExpired()
        {
            Item item = null;
            DateTime currentTime = DateTime.Now;
            for (int i = 0; i < Shelves.Count; i++)
            {
                for (int j = 0; j < Shelves[i].Items.Count; j++)
                    if (Shelves[i].Items[j].ExpirationDate < currentTime)
                    {
                        item = Shelves[i].Items[j];
                        Shelves[item.ShelfId].Items.Remove(item);
                        Shelves[item.ShelfId].FreeSpace += item.Size;
                    }
            }

        }

        //6
        public List<Item> FindItemsByTypeAndKashrut(Kashrut kashrut ,Type type)
        {
            List<Item> items = new List<Item>();
            for (int i = 0; i < Shelves.Count; i++)
            {
                for (int j = 0; j < Shelves[i].Items.Count; j++)
                {
                    if (Shelves[i].Items[j].Type == type && Shelves[i].Items[j].Kashrut == kashrut &&
                        Shelves[i].Items[j].ExpirationDate >= DateTime.Now)
                    {
                        items.Add(Shelves[i].Items[j]);
                    }
                }
            }

            return items;
        }



        public override string ToString()
        {
            return $"Warehouse number: {Id}\nModel: {Model}\nColor: {Color}\nNumber of shelves: {NumShelves}\n";
        }



    }
}
