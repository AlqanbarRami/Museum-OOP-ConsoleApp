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
            museum.addArtIntoRoom(firstRoom, SomeArt1);
            museum.addArtIntoRoom(secondRoom, SomeArt3);
            // FIXME: Continue with your program here
            //	Console.WriteLine("Verb: \"{0}\", Options: \"{1}\"", verb, String.Join(',',options));
            switch (verb)
            {
                case "listarts":
                    museum.prinRoomAndArts();
                    break;
                case "getart":
                    museum.getArtsInsideRoom(options[0]);
                    break;
                case "newart":
                    Art artfromUser = new Art(options[0], options[1], options[2]);
                    Console.WriteLine(museum.addArtIntoRoom(secondRoom, artfromUser));  // print true 
                    break;
                case "removeroom":
                    Console.WriteLine(museum.RemoveRoom(options[0]));
                    break;
                case "addnewroom":
					Room roomFromUser = new Room(options[0]);
					listOfUserRoom.Add(roomFromUser);
					Console.WriteLine("done");
                    break;
                case "removeart":
					Console.WriteLine(museum.RemoveArtFromRoom(options[0],options[1]));
					museum.prinRoomAndArts();
                    break;
			
 
			}
            
				/*
			   "Commands"
				mu listarts : list of rooms with arts
				mu getart [Name of room as string]   : get art from room
				mu newart [title] [description] [Author] : add new art
			    mu removeroom [Name Of Room]   : remove room
                mu removeart [name Of Room] [Title for art]
				
		      */

    }
}
}
