using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    class World
    {
        private List<Location> _locations {get; set;}
        private Location _currentLocation {get; set;}

        public World()
        {
            this._locations = new List<Location>();
        }

        public void AddLocation(Location location)
        {
            this._locations.Add(location);
        }

        public void ChangeLocation(Location location)
        {
            if(_locations.Contains(location))
                this._currentLocation = location;
        }

        public Location CheckCurrentLocation()
        {
            return this._currentLocation;
        }
    }
}