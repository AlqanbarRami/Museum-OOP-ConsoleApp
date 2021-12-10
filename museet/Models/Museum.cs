using System;
using System.Collections.Generic;


namespace Museet.Models
{
    public class Museum : MuseumsManagement
    {
        private string nameOfMesuem;
        public string NameOfMesuem { get => nameOfMesuem; set => nameOfMesuem = value; }
        public Museum()
        {

        }
        public Museum(string nameOfMesuem)
        {
            this.nameOfMesuem = nameOfMesuem;
        }

        public void AddNewMuseum(Museum museum)
        {
            ListofMuseum.Add(museum);

        }
        public void getArtsInsideRoom(string nameOfRoom)
        {
            foreach (KeyValuePair<Room, List<Art>> kAndV in ArtIntoRoom)
            {
                if (kAndV.Key.NameOfRoom == nameOfRoom)
                {
                    foreach (Art item in ArtIntoRoom[kAndV.Key])
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }

        }



        public void prinRoomAndArts()
        {

            foreach (KeyValuePair<Room, List<Art>> arts in ArtIntoRoom)
            {
                Console.WriteLine(arts.Key);
                foreach (Art item2 in arts.Value)
                {

                    Console.WriteLine(item2.ToString());
                }
            }

        }
        public void addArIntoMuseum(Museum museum, List<Art> arts)
        {
            if (ListOfArtsInsideMesuem.ContainsKey(museum))
            {
                foreach (Art item in arts)
                {
                    ListOfArtsInsideMesuem[museum].Add(item);
                }

            }
            else
            {
                ListOfArtsInsideMesuem.Add(museum, arts);
            }

        }
    }
}