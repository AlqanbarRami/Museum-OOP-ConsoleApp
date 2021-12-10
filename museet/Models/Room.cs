using System;
using System.Collections.Generic;

namespace Museet.Models
{
    // TODO: Needs further work
    public class Room : Museum
    {
        private string nameOfRoom;
        public string NameOfRoom { get => nameOfRoom; set => nameOfRoom = value; }

        public Room()
        {

        }
        public Room(string nameOfRoom)
        {
            this.NameOfRoom = nameOfRoom;
        }


        public override string ToString()
        {
            return "Name Of Room : " + NameOfRoom;
        }
    }
}

