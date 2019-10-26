using System;

namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {
        private bool _Locked;
        private Location _Location;

        public Path(string[] ids, Location location, bool locked) : base(ids)
        {
            _Location = location;
            _Locked = locked;
        }

        public bool Locked
        {
            get
            {
                return _Locked;
            }
            set
            {
                _Locked = value;
            }
        }

        public Location Location
        {
            get
            {
                return _Location;
            }
        }
    }
}
