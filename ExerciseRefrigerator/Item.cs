using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseRefrigerator
{
    public enum Kashrut
    {
        meet,
        parve,
        deary
    }
    public enum Type
    {
        drink,
        eat
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ShelfId { get; set; }
        public Type Type { get; set; }
        public Kashrut Kashrut { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Size { get; set; }

        public Item(int id, string name, int shelfId, Type type, Kashrut kashrut, DateTime expirationDate, int size)
        {
            Id = id;
            Name = name;
            ShelfId = shelfId;
            Type = type;
            Kashrut = kashrut;
            ExpirationDate = expirationDate;
            Size = size;
        }




        public override string ToString()
        {
            return $"Item Number: {Id}\nName: {Name}\nShelf: {ShelfId}\nType: {Type}\nKosher: {Kashrut}\nExpiration Date: {ExpirationDate}\nSize: {Size}\n";
        }


    }
}
