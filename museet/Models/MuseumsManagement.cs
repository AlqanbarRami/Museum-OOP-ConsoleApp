using System;
using System.Collections.Generic;


namespace Museet.Models
{
    public class MuseumsManagement
    {
        private Dictionary<Room, List<Art>> artIntoRoom = new Dictionary<Room, List<Art>>();
        private Dictionary<Museum, List<Room>> listOfRoomInsideMuseum = new Dictionary<Museum, List<Room>>();
        private Dictionary<Museum, List<Art>> listOfArtsInsideMesuem = new Dictionary<Museum, List<Art>>();
        private List<Museum> listofMuseum = new List<Museum>();
        public Dictionary<Room, List<Art>> ArtIntoRoom { get => artIntoRoom; set => artIntoRoom = value; }
        public Dictionary<Museum, List<Room>> ListOfRoomInsideMuseum { get => listOfRoomInsideMuseum; set => listOfRoomInsideMuseum = value; }
        public List<Museum> ListofMuseum { get => listofMuseum; set => listofMuseum = value; }
        public Dictionary<Museum, List<Art>> ListOfArtsInsideMesuem { get => listOfArtsInsideMesuem; set => listOfArtsInsideMesuem = value; }

        public bool addArtIntoRoom(Room room, Art art)
        {
            if (ArtIntoRoom.ContainsKey(room))
            {
                // check numbers of art inside room 
                if (checkCapacityOfRoom(room))  // less than 3 arts ?
                {
                    ArtIntoRoom[room].Add(art);
                    return true; //"Added!"
                }
                else
                {
                    return false; //"Room is full!"
                }
            }
            else if (!artIntoRoom.ContainsKey(room))
            {
                List<Art> templist = new List<Art>();
                templist.Add(art);
                ArtIntoRoom.Add(room, templist);
                return true; //"Added"
            }
            else
            {
                return false; //"Max elements in list are three!"
            }
        }

        public bool RemoveRoom(string nameOfRoom)
        {
            foreach (KeyValuePair<Room, List<Art>> kAndV in ArtIntoRoom)
            {
                if (kAndV.Key.NameOfRoom == nameOfRoom)
                {
                    return false; //"Room Contains Arts"
                }
                else if (kAndV.Key.NameOfRoom != nameOfRoom)
                {
                    foreach (KeyValuePair<Museum, List<Room>> item in ListOfRoomInsideMuseum)
                    {
                        foreach (Room itemRoom in item.Value)
                        {
                            if (itemRoom.NameOfRoom == nameOfRoom)
                            {
                                ListOfRoomInsideMuseum[item.Key].Remove(itemRoom);
                                return true; //"Room remover"
                            }
                        }
                    }
                }

            }
            return false; //"Something Wrong, Did you add the room to museum?"
        }

        public bool checkCapacityOfRoom(Room nameOfRoom)
        {
            int total = ArtIntoRoom[nameOfRoom].Count;
            if (total < 3)
            {
                return true;  // Ok We can add another art into Room  :)
            }
            return false;  // Room is full :(
        }

        public string RemoveArtFromRoom(string nameRoom, string art)
        {
            foreach (KeyValuePair<Room, List<Art>> kAndV in ArtIntoRoom)
            {
                if (kAndV.Key.NameOfRoom == nameRoom)   // check if we have The room
                {
                    foreach (Art item in kAndV.Value)   // check arts inside the room
                    {
                        if (item.Title == art)
                        {
                            ArtIntoRoom[kAndV.Key].Remove(item);
                            return "art removed from the room";
                        }
                    }
                }
                else if (kAndV.Key.NameOfRoom != nameRoom) 
                {
                    continue; // keep continue and check the next room 
                }
                else
                {
                    return "Room not found";
                }
            }
            return "Error";
        }

        public List<string> GetRoomsArts()
        {
            var newRoomArtsList = new List<string>();
            foreach (KeyValuePair<Room, List<Art>> item in ArtIntoRoom)
            {

                foreach (var item2 in GetArts(item.Key.NameOfRoom))
                {
                    newRoomArtsList.Add(item.Key + " " + " [Arts inside] -> " + item2);
                }

            }
            return newRoomArtsList;
        }

        public List<string> GetArts(string nameOfRoom)
        {
            var newArtsList = new List<string>();
            foreach (KeyValuePair<Room, List<Art>> item in ArtIntoRoom)
            {
                foreach (Art artItem in item.Value)
                {
                    if (item.Key.NameOfRoom == nameOfRoom)
                    {
                        newArtsList.Add(artItem.Title + " " + artItem.Description + " " + artItem.Author);
                    }

                }
            }
            return newArtsList;
        }

    }
}