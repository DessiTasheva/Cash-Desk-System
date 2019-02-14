using CashDeskApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CashDeskApi.Models.DbModels;

namespace CashDeskApi.Repositories
{
    public class EventRepository
    {
        CashDesksContext _ctx = new CashDesksContext();

        public EventDto GetAllEvents()
        {
            
            //Take all events for the current day from database
            var events = _ctx.Events.Where(e => e.UTCTimestamp.Day == DateTime.UtcNow.Day).ToList();
            //Group all events by cameraId
            var eventsGroups = events.GroupBy(e => e.CameraId);
            
            //Dictionary where we keep all of the cameras by id and number for the total
            //of customers for each camera
            var cameraEventDict = new Dictionary<int, int>();
            
            //Property where we will keep current camera id
            int currentCameraId = 0;

            //Properties where we will keep total number of people for the store
            int TotalPeopleIn = 0;
            int TotalPeopleOut = 0;
            
            foreach (var eventGroup in eventsGroups)
            {
                //Properties where we will keep total number of people for the camera
                int peopleInCamera = 0;
                int peopleOutCamera = 0;

                foreach (var element in eventGroup)
                {
                    currentCameraId = element.CameraId;

                    //We check what the event was (AddPerson/RemovePerson) and
                    //Increment both number for camera and store
                    if (element.PeopleIn == 1)
                    {
                        peopleInCamera++;
                        TotalPeopleIn++;
                    }

                    if (element.PeopleOut == 1)
                    {
                        peopleOutCamera++;
                        TotalPeopleOut++;
                    }
                }

                //Add the total(peopleIn - peopleOut) people for current camera)
                cameraEventDict.Add(currentCameraId, peopleInCamera - peopleOutCamera);
                
            }

            //Initialize the object which will be returned
            var eventDto = new EventDto();
            eventDto.PeopleIn = TotalPeopleIn;
            eventDto.PeopleOut = TotalPeopleOut;
            eventDto.cameraTotal = cameraEventDict;

            //Return the object
            return eventDto;
        }

        public void AddPeopleEvent(int id)
        {
            EventDb eventDb = new EventDb();

            //It is AddPeopleEvent => PeopleIn = 1
            eventDb.PeopleIn = 1;
            eventDb.PeopleOut = 0;
            eventDb.CameraId = id;
            eventDb.UTCTimestamp = DateTime.UtcNow;

            _ctx.Events.Add(eventDb);
            _ctx.SaveChanges();
        }

        public void RemovePeopleEvent(int id)
        {
            EventDb eventDb = new EventDb();

            //It is RemovePeopleEvent => PeopleOut = 1
            eventDb.PeopleIn = 0;
            eventDb.PeopleOut = 1;
            eventDb.CameraId = id;
            eventDb.UTCTimestamp = DateTime.UtcNow;

            _ctx.Events.Add(eventDb);
            _ctx.SaveChanges();
        }
    }
}