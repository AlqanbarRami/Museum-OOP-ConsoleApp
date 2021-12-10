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
        public List<string> getArtsInsideRoom(string nameOfRoom)
        { 
            var templist = new List<string>();
            foreach (KeyValuePair<Room, List<Art>> kAndV in ArtIntoRoom)
            {
                if (kAndV.Key.NameOfRoom == nameOfRoom)
                {
                    foreach (Art item in ArtIntoRoom[kAndV.Key])
                    {
                        templist.Add(item.Title + " " + item.Description + " " + item.Author);
                    }
                }
            }
            return templist;

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