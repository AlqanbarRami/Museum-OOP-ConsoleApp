using System;
using Simulator;
using Museet.Models;
using System.Collections.Generic;

namespace Museet
{
    internal class VirtualMuseumProgram : IApplication
    {
        Museum museum = new Museum("Rami");
        List<Room> listOfUserRoom = new List<Room>();
        List<Art> listOfUserArts = new List<Art>();
        Room firstRoom = new Room("first");
        Room secondRoom = new Room("second");
        Art SomeArt1 = new Art("rami", "Description1", "Author1");
        Art SomeArt2 = new Art("mueen", "Description2", "Author2");
        Art SomeArt3 = new Art("hameed", "Description3", "Author3");

        public void printArtAndRooms()
        {
            foreach (var roomItem in museum.GetRoomsArts())
            {
                Console.WriteLine(roomItem);
            }
        }
        public void Run(string verb, string[] options)
        {

            museum.AddNewMuseum(museum);
            // adding rooms and arts create by user into user lists
            listOfUserRoom.Add(firstRoom);
            listOfUserRoom.Add(secondRoom);
            listOfUserArts.Add(SomeArt1);
            listOfUserArts.Add(SomeArt2);
            listOfUserArts.Add(SomeArt3);
            //Adding list of art inside museum
            museum.addArIntoMuseum(museum, listOfUserArts);
            // adding list of rooms inside Museum	
            museum.ListOfRoomInsideMuseum.Add(museum, listOfUserRoom);
            museum.addArtIntoRoom(firstRoom, SomeArt1);
            museum.addArtIntoRoom(firstRoom, SomeArt2);
            museum.addArtIntoRoom(firstRoom, SomeArt3);
            museum.addArtIntoRoom(secondRoom, SomeArt3);
            // FIXME: Continue with your program here
            //	Console.WriteLine("Verb: \"{0}\", Options: \"{1}\"", verb, String.Join(',',options));
            switch (verb)
            {
                case "list":
                    if (options[0] == "all")
                    {
                        printArtAndRooms();

                    }
                    break;
                case "get":
                    if (options[0] == "art")
                    {
                        museum.getArtsInsideRoom(options[1]);
                    }
                    break;
                case "new":
                    if (options[0] == "art" && options[1] == "add")
                    {
                        Art artfromUser = new Art(options[2], options[3], options[4]);
                        Console.WriteLine(museum.addArtIntoRoom(secondRoom, artfromUser));  // print true 
                    }
                    break;
                case "remove":
                    if (options[0] == "room")
                    {
                        Console.WriteLine(museum.RemoveRoom(options[1])); 
                    }
                    break;
                case "add":
                    if (options[0] == "new" && options[1] == "room")
                    {
                        Room roomFromUser = new Room(options[2]);
                        listOfUserRoom.Add(roomFromUser);
                        Console.WriteLine("done");
                    }
                    break;
                case "art":
                   if(options[0] == "remove"){
                    Console.WriteLine(museum.RemoveArtFromRoom(options[1], options[2]));
                    printArtAndRooms();
                   }
                    break;


            }

            /*
           "Commands"
            mu list all : list of rooms with arts
            mu get art [Name of room as string]   : get art from room
            mu new art add [title] [description] [Author] : add new art
            mu add new room [name of room]
            mu remove room [Name Of Room]   : remove room
            mu art remove [name Of Room] [Title for art]

          */

        }
    }
}
