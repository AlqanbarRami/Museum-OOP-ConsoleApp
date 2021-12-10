using System;
using Xunit;
using Museet.Models;
using System.Collections.Generic;


namespace tests
{
    public class UnitTest1
    {
        //-> Enhetstesterna bevisar att reglerna i krav 10 & 11 alltid efterföljs <-\\
        [Fact]
        public void AddingArtsIntoRoomTest()  // Rooms should contains max three arts
        {
            Art art1 = new Art("title1", "description1", "alqanbar1");
            Art art2 = new Art("title2", "description2", "alqanbar2");
            Art art3 = new Art("title3", "description3", "alqanbar3");
            Art art4 = new Art("title4", "description4", "alqanbar4");
            Room firstRoom = new Room("firstRoom");
            Room secondRoom = new Room("secondRoom");

            // adding into the first room 4 arts
            bool addingFirstArt = firstRoom.addArtIntoRoom(firstRoom, art1);  // true
            bool addingSecondArt = firstRoom.addArtIntoRoom(firstRoom, art2); // true
            bool addingThirdArt = firstRoom.addArtIntoRoom(firstRoom, art3);  // true
            bool addingFourthArt = firstRoom.addArtIntoRoom(firstRoom, art4);  // *False*
            // let's try to add the fourth art into second room , should be true 
            bool addingIntoSecondRoom = secondRoom.addArtIntoRoom(secondRoom, art4);  // *True Now*

            Assert.Equal(true, addingFirstArt);
            Assert.Equal(true, addingSecondArt);
            Assert.Equal(true, addingThirdArt);
            Assert.Equal(false, addingFourthArt);  // should be false now cuz Max are three art
            Assert.Equal(true, addingIntoSecondRoom);  // True now Cuz We add it into the Second room

        }

        [Fact]
        public void RemoveRoomsTest()    // can't remove a room if there is any art inside
        {
            Museum museum = new Museum("Rami");
            List<Room> roomListTomuseum = new List<Room>();
            Art art1 = new Art("title1", "description1", "alqanbar1");
            Art art2 = new Art("title1", "description1", "alqanbar1");
            Room firstRoom = new Room("firstRoom");
            Room secondRoom = new Room("second");
            roomListTomuseum.Add(firstRoom);
            roomListTomuseum.Add(secondRoom);
            //We should add rooms to the museum, sometimes there are rooms in the museum but they are empty.
            museum.ListOfRoomInsideMuseum.Add(museum, roomListTomuseum); 
            museum.addArtIntoRoom(firstRoom, art1);  //adding arts into the first room and the second room empty
            bool removeFirstRoom = museum.RemoveRoom("firstRoom"); // should be false 
            bool removeSecondRoom = museum.RemoveRoom("second"); // should be true

            Assert.Equal(false, removeFirstRoom);
            Assert.Equal(true, removeSecondRoom);

        }


          [Fact]
        public void MultiMuseums()    // Multi Museum
        {
            // Addin 2 Museums 1 with rooms and Arts and second empty
            Museum rami = new Museum("Rami");
            Museum mueen = new Museum("mueen");
            List<Room> listOfRooms = new List<Room>();
            List<Art> listOfArts = new List<Art>();
            Art ar1 = new Art("title1", "description1", "alqanbar1");
            Room room = new Room("room");
            rami.ListofMuseum.Add(rami); // adding into our museum
            rami.addArIntoMuseum(rami,listOfArts); // adding all arts inside museum
            rami.ListOfRoomInsideMuseum.Add(rami,listOfRooms); // adding all rooms inside museum
            // Arrange 
            bool checkMusuem = rami.ListofMuseum.Contains(rami); // true
            bool checkRooms = rami.ListOfRoomInsideMuseum.ContainsKey(rami); // true 
            bool checkArts = rami.ListOfArtsInsideMesuem.ContainsKey(rami); // true
            bool checkSecondMuseum = mueen.ListofMuseum.Contains(mueen); // false
            bool checkSecondMuseumRooms = mueen.ListOfRoomInsideMuseum.ContainsKey(mueen); // false 
            bool checkSecondMuseumArts = mueen.ListOfArtsInsideMesuem.ContainsKey(mueen); // false
            // First Museum
            Assert.Equal(true,checkMusuem);
            Assert.Equal(true,checkRooms);
            Assert.Equal(true,checkArts);
            //Second Empty Museum
            Assert.Equal(false,checkSecondMuseum);
            Assert.Equal(false,checkSecondMuseumRooms);
            Assert.Equal(false,checkSecondMuseumArts);
            
        }



    }
}
